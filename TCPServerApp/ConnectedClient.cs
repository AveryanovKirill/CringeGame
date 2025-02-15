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
        private void ProcessIncomingPackets()
        {
            while (true)
            {
                try
                {
                    var buff = new byte[256];
                    int receivedBytes = Client.Receive(buff);
                    if (receivedBytes == 0)
                    {
                        // Клиент отключился
                        return;
                    }

                    // Обрезаем буфер до реально полученных данных
                    var actualData = buff.Take(receivedBytes).ToArray();

                    // Пример фильтрации до 0xFF, 0x00 (если вы используете XPacket-протокол)
                    actualData = actualData
                        .TakeWhile((b, i) =>
                        {
                            if (b != 0xFF) return true;
                            return i + 1 < actualData.Length && actualData[i + 1] != 0;
                        })
                        .Concat(new byte[] { 0xFF, 0 })
                        .ToArray();

                    // Вместо локальной обработки (как в вашем текущем коде),
                    // просто вызываем событие, чтобы сервер сам решал, что делать с данными.
                    OnPacketReceive?.Invoke(actualData);
                }
                catch (SocketException)
                {
                    // Сокет был закрыт или произошла ошибка сети
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в ProcessIncomingPackets: {ex}");
                    return;
                }
            }
        }

        /// <summary>
        /// Ставит пакет в очередь на отправку клиенту
        /// </summary>
        public void QueuePacketSend(byte[] packet)
        {
            // Разрешаем пакеты до 65,535 байт (ushort.MaxValue)
            if (packet.Length > ushort.MaxValue)
            {
                throw new Exception("Max packet size is 65535 bytes.");
            }

            _packetSendingQueue.Enqueue(packet);
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
