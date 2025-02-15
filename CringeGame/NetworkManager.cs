using CringeGame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TCPClient;
using XProtocol;
using XProtocol.Serializator;

namespace CringeGame
{
    public class NetworkManager
    {
        private readonly XClient _client;
        public event Action<CringeGameFullState> OnGameStateReceived;

        public NetworkManager()
        {
            _client = new XClient();
            _client.OnPacketReceive += HandlePacket;
        }

        /// <summary>
        /// Подключается к серверу и отправляет handshake с именем игрока.
        /// </summary>
        public void Connect(string ip, int port, string username)
        {
            _client.Connect(ip, port);
            var handshake = new CringeGameHandshake { Username = username };
            var packet = XPacketConverter.Serialize(XPacketType.Handshake, handshake).ToPacket();
            _client.QueuePacketSend(packet);
        }

        /// <summary>
        /// Отправляет пакет с действием игрока.
        /// </summary>
        public void SendPlayerAction(CringeGameActionPacket action)
        {
            var packet = XPacketConverter.Serialize(XPacketType.PlayerAction, action).ToPacket();
            _client.QueuePacketSend(packet);
        }

        private void HandlePacket(byte[] packetBytes)
        {
            var packet = XPacket.Parse(packetBytes);
            if (packet == null) return;
            var type = XPacketTypeManager.GetTypeFromPacket(packet);
            var field = packet.GetField(1);
            if (field == null || field.Contents == null)
            {
                Console.WriteLine("[CLIENT] Поле с ID=1 отсутствует или пустое");
            }
            else
            {
                Console.WriteLine($"[CLIENT] Field[1] Size: {field.FieldSize}, Bytes: {BitConverter.ToString(field.Contents)}");
            }
            if (type == XPacketType.GameUpdate)
            {
                // Попытка десериализации строки из пакета
                string json = XPacketConverter.Deserialize<string>(packet);
                Console.WriteLine($"[CLIENT] JSON string received: '{json}'");

                if (string.IsNullOrWhiteSpace(json))
                {
                    Console.WriteLine("[CLIENT] Получена пустая JSON строка.");
                    return;
                }

                try
                {
                    var options = new JsonSerializerOptions { IncludeFields = true };
                    var state = JsonSerializer.Deserialize<CringeGameFullState>(json, options);
                    Console.WriteLine($"[CLIENT] Received GameUpdate with {state.Players.Count} players");
                    OnGameStateReceived?.Invoke(state);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[CLIENT] Ошибка десериализации JSON: {ex.Message}");
                }
            }
        }
    }
}
