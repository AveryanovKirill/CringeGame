using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CringeGame.Logic
{
    public class Card
    {
        private readonly Role _role;
        private readonly string _text;
        public Role Role { get { return _role; } }
        public string Text { get { return _text; } }

        public Card(Role role, string text)
        {
            _role = role;
            _text = text;
        }

        public static List<Card> GetRandomCards(string filePath)
        {
            var cards = GetAllCards(filePath);

            if (cards == null || cards.Count < 4)
            {
                Console.WriteLine("Недостаточно карт для выбора 4 случайных.");
                return null;
            }

            Random random = new Random();
            return cards.OrderBy(x => random.Next()).Take(4).ToList();
        }

        private static List<Card> GetAllCards(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Card>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении JSON-файла: {ex.Message}");
                return null;
            }
        }
    }
}
