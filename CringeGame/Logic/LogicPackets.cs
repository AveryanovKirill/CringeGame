using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProtocol.Serializator;

namespace CringeGame.Logic
{
    public class PlayerStateForUpdate
    {
        [XField(1)]
        public string Name;
        [XField(2)]
        public Role Role;
        [XField(3)]
        public int Score;
        [XField(4)]
        public Card[] Cards;            // массив карт, полученных игроком
        [XField(5)]
        public int SelectedCardIndex;   // индекс выбранной карты игроком (-1 если не выбрана)
        [XField(6)]
        public int SelectedPlayerIndex; // для судьи: индекс выбранного игрока, например, в массиве _players (-1 если не выбран)
        [XField(7)]
        public bool IsReady;
    }

    public class CringeGameFullState
    {
        [XField(1)]
        public List<PlayerStateForUpdate> Players;
        [XField(2)]
        public int RoundNumber;
    }

    public class CringeGameActionPacket
    {
        [XField(1)]
        public string ActionType; // "JudgeApproval", "PlayerCards", "PlayerAnswer", "JudgeSelectWinner"

        [XField(2)]
        public int CardIndex; // выбранный индекс карты или индекс выбранного игрока

        [XField(3)]
        public Card[] Cards;  // если отправляется полный набор карт (для PlayerCards)

        [XField(4)]
        public string Username; // имя игрока, отправляющего действие
    }
}
