using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace tcpServer_2_
{
    public partial class ServerForm : Form
    {
        private TcpListener _server;
        private Thread _listenThread;
        private volatile bool _isRunning;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Запуск сервера на порту 8081
                _server = new TcpListener(IPAddress.Loopback, 8081);
                _server.Start();
                LogMessage("Сервер запущен. Ожидание подключений...");

                // Вывод сообщения об успешном запуске сервера
                MessageBox.Show("Сервер успешно запущен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Принятие подключения в отдельном потоке
                _isRunning = true;
                _listenThread = new Thread(ListenForClients);
                _listenThread.Start();
            }
            catch (SocketException ex)
            {
                LogMessage("Ошибка сокета: " + ex.Message);
                MessageBox.Show("Не удалось запустить сервер: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogMessage("Ошибка запуска сервера: " + ex.Message);
                MessageBox.Show("Не удалось запустить сервер: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenForClients()
        {
            while (_isRunning)
            {
                try
                {
                    // Принять новое подключение
                    TcpClient client = _server.AcceptTcpClient();
                    LogMessage("Новый клиент подключен.");

                    // Обработка клиента в отдельном потоке
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                }
                catch (SocketException ex)
                {
                    LogMessage("Ошибка сокета: " + ex.Message);
                }
                catch (Exception ex)
                {
                    LogMessage("Ошибка: " + ex.Message);
                }
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            try
            {
                // Чтение данных от клиента
                byte[] buffer = new byte[1024];
                while (_isRunning)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Клиент отключился

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    LogMessage("Получено от клиента: " + message);

                    // Отправка ответа клиенту
                    string response = "Сервер получил: " + message;
                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                LogMessage("Ошибка обработки клиента: " + ex.Message);
            }
            finally
            {
                client.Close();
                LogMessage("Клиент отключен.");
            }
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

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Остановка сервера при закрытии формы
            _isRunning = false;

            // Завершение потока
            if (_listenThread != null && _listenThread.IsAlive)
            {
                _listenThread.Join(TimeSpan.FromSeconds(5)); // Ожидание завершения потока в течение 5 секунд
            }

            // Освобождение ресурсов
            _server?.Stop();
            LogMessage("Сервер остановлен.");
        }
    }
}
