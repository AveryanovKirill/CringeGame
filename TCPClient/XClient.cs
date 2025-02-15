using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPClient
{
    public class XClient
    {
        private Socket _socket;
        public event Action<byte[]> OnPacketReceive;

        public void Connect(string ip, int port)
        {
            _socket = new Socket(System.Net.Sockets.AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(ip, port);
            Task.Run(ReceivePackets);
        }

        public void QueuePacketSend(byte[] packet)
        {
            // Формируем пакет с префиксом длины (4 байта, little-endian)
            byte[] lengthPrefix = BitConverter.GetBytes(packet.Length);
            byte[] finalPacket = new byte[lengthPrefix.Length + packet.Length];
            Buffer.BlockCopy(lengthPrefix, 0, finalPacket, 0, lengthPrefix.Length);
            Buffer.BlockCopy(packet, 0, finalPacket, lengthPrefix.Length, packet.Length);
            // Отправляем пакет
            _socket.Send(finalPacket);
        }

        private async Task ReceivePackets()
        {
            byte[] buffer = new byte[4096];
            MemoryStream ms = new MemoryStream();
            try
            {
                while (true)
                {
                    int bytesRead = await Task.Factory.FromAsync(
                        _socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, null, null),
                        _socket.EndReceive);
                    if (bytesRead <= 0)
                        break; // соединение закрыто

                    // Записываем прочитанные данные в общий буфер
                    ms.Write(buffer, 0, bytesRead);

                    // Обрабатываем накопленные данные
                    while (ms.Length >= 4)
                    {
                        ms.Position = 0;
                        byte[] lengthBytes = new byte[4];
                        int read = ms.Read(lengthBytes, 0, 4);
                        if (read < 4)
                            break; // недостаточно данных для длины

                        int packetLength = BitConverter.ToInt32(lengthBytes, 0);
                        // Если накоплено достаточно данных для полного пакета
                        if (ms.Length - 4 >= packetLength)
                        {
                            byte[] packetData = new byte[packetLength];
                            ms.Read(packetData, 0, packetLength);

                            // Вызываем обработчик полученного полного пакета
                            OnPacketReceive?.Invoke(packetData);

                            // Извлекаем оставшиеся данные
                            long remaining = ms.Length - (4 + packetLength);
                            byte[] leftover = new byte[remaining];
                            ms.Read(leftover, 0, (int)remaining);

                            ms.Dispose();
                            ms = new MemoryStream();
                            ms.Write(leftover, 0, leftover.Length);
                        }
                        else
                        {
                            // Недостаточно данных для полного пакета – сбрасываем позицию и ждем новых данных
                            ms.Position = ms.Length;
                            break;
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"[CLIENT] SocketException в ReceivePackets: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CLIENT] Exception в ReceivePackets: {ex.Message}");
            }
        }
    }
}
