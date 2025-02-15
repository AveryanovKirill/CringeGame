using XProtocol.Serializator;

namespace XProtocol
{
    public class XPacketHandshake
    {
        [XField(1)]
        public int MagicHandshakeNumber;
    }

    public class CringeGameHandshake
    {
        [XField(1)]
        public string Username;
    }

    // Пакет для передачи действий игрока:
    // "SelectCard" – стандартный игрок выбирает карту (поле CardIndex),
    // "JudgeAffirmation" – судья выбирает карту утверждения,
    // "JudgeWinner" – судья выбирает победителя.
    

    // Пакет состояния игры – сервер рассылает его клиентам
    public class CringeGameState
    {
        // Например, список имён игроков и их очки:
        [XField(1)]
        public List<string> PlayerNames;
        [XField(2)]
        public List<int> Scores;
        // Можно передавать и другую нужную информацию (например, текущий раунд, выбранные карты и т.д.)
    }

    public class PlayerInfo
    {
        [XField(1)]
        public string Username;
        [XField(2)]
        public string Role; // "Judge" или "Default"
        [XField(3)]
        public int Score;
        [XField(4)]
        public int SelectedCardIndex; // если стандартный игрок (например, -1, если не выбран)
        [XField(5)]
        public bool JudgeHasChosenAffirmation; // если судья
        [XField(6)]
        public bool JudgeHasChosenWinner;      // если судья
    }
}
