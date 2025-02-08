using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace tcpClient_2_
{
    public partial class ClientForm : Form
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _receiveThread;
        private volatile bool _isRunning;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                LogMessage("Клиент уже подключен. Сначала отключитесь.");
                return;
            }

            try
            {
                // Подключение к серверу
                _client = new TcpClient("127.0.0.1", 8081);
                _stream = _client.GetStream();
                LogMessage("Подключено к серверу.");

                // Чтение ответов от сервера в отдельном потоке
                _isRunning = true;
                _receiveThread = new Thread(ReceiveMessages);
                _receiveThread.Start();
            }
            catch (Exception ex)
            {
                LogMessage("Ошибка подключения: " + ex.Message);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (!_isRunning)
            {
                LogMessage("Клиент не подключен. Сначала подключитесь.");
                return;
            }

            try
            {
                // Отправка сообщения серверу
                string message = MessageTextBox.Text;
                byte[] data = Encoding.UTF8.GetBytes(message);
                _stream.Write(data, 0, data.Length);
                LogMessage("Отправлено серверу: " + message);
            }
            catch (Exception ex)
            {
                LogMessage("Ошибка отправки: " + ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            while (_isRunning)
            {
                try
                {
                    int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Сервер отключился

                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    LogMessage("Ответ сервера: " + response);
                }
                catch (Exception ex)
                {
                    LogMessage("Ошибка получения данных: " + ex.Message);
                    break;
                }
            }

            CloseConnection();
            LogMessage("Соединение с сервером закрыто.");
        }

        private void CloseConnection()
        {
            _client?.Close();
            _stream?.Close();
            _isRunning = false;
        }

        private void LogMessage(string message)
        {
            if (LogListBox.InvokeRequired)
            {
                LogListBox.Invoke(new Action<string>(LogMessage), message);
            }
            else
            {
                LogListBox.Items.Add(message);
                LogListBox.TopIndex = LogListBox.Items.Count - 1; // Прокрутка к последнему элементу
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Закрытие соединения при закрытии формы
            CloseConnection();

            // Завершение потока
            if (_receiveThread != null && _receiveThread.IsAlive)
            {
                _receiveThread.Join(TimeSpan.FromSeconds(5)); // Ожидание завершения потока в течение 5 секунд
            }
        }

        // Обработчик кнопки "Отключиться"
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                // Завершение соединения
                CloseConnection();
                LogMessage("Соединение с сервером закрыто вручную.");
            }
            else
            {
                LogMessage("Клиент не подключен.");
            }
        }
    }
}
