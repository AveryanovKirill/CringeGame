using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProtocol;
using CringeGame.Logic;

namespace CringeGame
{
    public interface IGameStateUpdatable
    {
        /// <summary>
        /// Метод для обновления состояния игры.
        /// </summary>
        /// <param name="state">Полное состояние игры, полученное с сервера.</param>
        void UpdateGameState(CringeGameFullState state);
    }
}
