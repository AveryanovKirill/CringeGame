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
                // ������ ������� �� ����� 8081
                _server = new TcpListener(IPAddress.Loopback, 8081);
                _server.Start();
                LogMessage("������ �������. �������� �����������...");

                // ����� ��������� �� �������� ������� �������
                MessageBox.Show("������ ������� �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // �������� ����������� � ��������� ������
                _isRunning = true;
                _listenThread = new Thread(ListenForClients);
                _listenThread.Start();
            }
            catch (SocketException ex)
            {
                LogMessage("������ ������: " + ex.Message);
                MessageBox.Show("�� ������� ��������� ������: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogMessage("������ ������� �������: " + ex.Message);
                MessageBox.Show("�� ������� ��������� ������: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenForClients()
        {
            while (_isRunning)
            {
                try
                {
                    // ������� ����� �����������
                    TcpClient client = _server.AcceptTcpClient();
                    LogMessage("����� ������ ���������.");

                    // ��������� ������� � ��������� ������
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                }
                catch (SocketException ex)
                {
                    LogMessage("������ ������: " + ex.Message);
                }
                catch (Exception ex)
                {
                    LogMessage("������: " + ex.Message);
                }
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            try
            {
                // ������ ������ �� �������
                byte[] buffer = new byte[1024];
                while (_isRunning)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // ������ ����������

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    LogMessage("�������� �� �������: " + message);

                    // �������� ������ �������
                    string response = "������ �������: " + message;
                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                LogMessage("������ ��������� �������: " + ex.Message);
            }
            finally
            {
                client.Close();
                LogMessage("������ ��������.");
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
                LogListBox.TopIndex = LogListBox.Items.Count - 1; // ��������� � ���������� ��������
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��������� ������� ��� �������� �����
            _isRunning = false;

            // ���������� ������
            if (_listenThread != null && _listenThread.IsAlive)
            {
                _listenThread.Join(TimeSpan.FromSeconds(5)); // �������� ���������� ������ � ������� 5 ������
            }

            // ������������ ��������
            _server?.Stop();
            LogMessage("������ ����������.");
        }
    }
}
