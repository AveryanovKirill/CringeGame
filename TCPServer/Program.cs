using System;

namespace TCPServer
{
    internal class Program
    {
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
