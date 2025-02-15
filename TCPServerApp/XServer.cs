using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace TCPServer
{
    internal class XServer
    {
        private readonly Socket _socket;
        private readonly List<ConnectedClient> _clients;

        private bool _listening;
        private bool _stopListening;

        public XServer()
        {
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());  
            var ipAddress = ipHostInfo.AddressList[0];

            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _clients = new List<ConnectedClient>();
        }

        public event Action<ConnectedClient> OnClientConnected;

        public void Start()
        {
            if (_listening)
            {
                throw new Exception("Server is already listening incoming requests.");
            }

            if (_socket.AddressFamily == AddressFamily.InterNetworkV6)
            {
                // Включаем Dual Mode, чтобы принимать IPv4 соединения
                _socket.DualMode = true;
                _socket.Bind(new IPEndPoint(IPAddress.IPv6Any, 4910));
            }
            else
            {
                _socket.Bind(new IPEndPoint(IPAddress.Any, 4910));
            }

            _socket.Listen(10);
            _listening = true;
        }

        public void Stop()
        {
            if (!_listening)
            {
                throw new Exception("Server is already not listening incoming requests.");
            }

            _stopListening = true;
            _socket.Shutdown(SocketShutdown.Both);
            _listening = false;
        }

        public void AcceptClients()
        {
            while (true)
            {
                if (_stopListening)
                {
                    return;
                }

                Socket client;

                try
                {
                    client = _socket.Accept();
                } catch { return; }

                Console.WriteLine($"[!] Accepted client from {(IPEndPoint) client.RemoteEndPoint}");

                var c = new ConnectedClient(client);
                _clients.Add(c);
                OnClientConnected?.Invoke(c);
            }
        }
    }
}
