using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using XProtocol;

namespace TCPServer
{
    internal class ConnectedClient
    {
        /// <summary>
        /// Сокет, связанный с этим клиентом
        /// </summary>
        public Socket Client { get; }

        /// <summary>
        /// Событие, вызываемое при получении сырых данных от клиента (байтовый массив).
        /// Сервер может подписаться и обработать пакет (XPacket.Parse и т.п.).
        /// </summary>
        public event Action<byte[]> OnPacketReceive;

        /// <summary>
        /// Очередь исходящих пакетов, которые нужно отправить клиенту
        /// </summary>
        private readonly Queue<byte[]> _packetSendingQueue = new Queue<byte[]>();

        public ConnectedClient(Socket client)
        {
            Client = client;

            Task.Run(ProcessIncomingPackets);
            Task.Run(SendPackets);
        }

        /// <summary>
        /// Основной цикл приёма пакетов. Получает данные и вызывает событие OnPacketReceive.
        /// </summary>
        private async Task ProcessIncomingPackets()
        {
            byte[] buffer = new byte[4096];
            MemoryStream ms = new MemoryStream();
            try
            {
                while (true)
                {
                    int bytesRead = Client.Receive(buffer);
                    if (bytesRead <= 0)
                        return; // клиент отключился

                    ms.Write(buffer, 0, bytesRead);

                    // Пытаемся извлечь полный пакет, используя 4-байтовый префикс
                    while (ms.Length >= 4)
                    {
                        ms.Position = 0;
                        byte[] lengthBytes = new byte[4];
                        int read = ms.Read(lengthBytes, 0, 4);
                        if (read < 4)
                            break; // недостаточно данных для длины

                        int packetLength = BitConverter.ToInt32(lengthBytes, 0);
                        if (ms.Length - 4 >= packetLength)
                        {
                            byte[] packetData = new byte[packetLength];
                            ms.Read(packetData, 0, packetLength);

                            // Передаем полный пакет дальше для обработки
                            OnPacketReceive?.Invoke(packetData);

                            // Сохраняем оставшиеся данные
                            long remaining = ms.Length - (4 + packetLength);
                            byte[] leftover = new byte[remaining];
                            ms.Read(leftover, 0, (int)remaining);

                            ms.Dispose();
                            ms = new MemoryStream();
                            ms.Write(leftover, 0, leftover.Length);
                        }
                        else
                        {
                            ms.Position = ms.Length;
                            break;
                        }
                    }
                }
            }
            catch (SocketException)
            {
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в ProcessIncomingPackets: {ex}");
                return;
            }
        }


        /// <summary>
        /// Ставит пакет в очередь на отправку клиенту
        /// </summary>
        public void QueuePacketSend(byte[] packet)
        {
            // Формируем префикс длины (4 байта, little-endian)
            byte[] lengthPrefix = BitConverter.GetBytes(packet.Length);
            byte[] finalPacket = new byte[lengthPrefix.Length + packet.Length];
            Buffer.BlockCopy(lengthPrefix, 0, finalPacket, 0, lengthPrefix.Length);
            Buffer.BlockCopy(packet, 0, finalPacket, lengthPrefix.Length, packet.Length);

            // Проверяем общий размер, если требуется
            if (finalPacket.Length > ushort.MaxValue)
            {
                throw new Exception("Max packet size is 65535 bytes.");
            }

            _packetSendingQueue.Enqueue(finalPacket);
        }


        /// <summary>
        /// Асинхронно отправляет пакеты из очереди клиенту
        /// </summary>
        private void SendPackets()
        {
            while (true)
            {
                try
                {
                    if (_packetSendingQueue.Count == 0)
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    var packet = _packetSendingQueue.Dequeue();
                    Client.Send(packet);

                    Thread.Sleep(100);
                }
                catch (SocketException)
                {
                    // Разрыв соединения
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в SendPackets: {ex}");
                    return;
                }
            }
        }
    }
}
