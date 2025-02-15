using TCPServer;

namespace TCPServerApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.Title = "CringeGame Server";
            Console.ForegroundColor = ConsoleColor.White;

            var server = new CringeGameServer();
            server.Start();

            Console.WriteLine("CringeGame Server запущен. Нажмите ENTER для выхода...");
            Console.ReadLine();
        }
    }
}