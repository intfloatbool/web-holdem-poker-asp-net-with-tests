using EthWebPoker.Games.Base;
using EthWebPoker.Games.CardGames.HoldemPoker.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games
{
    public class GameProcessProvider : IGameProcessProvider
    {
        private Dictionary<GameType, GameProcess> _gameProcessDict = new Dictionary<GameType, GameProcess>();
        public GameProcessProvider()
        {
            InitializeDict();
        }
        private void InitializeDict()
        {
            _gameProcessDict.Add(GameType.HOLDEM_POKER, GameProcess.HoldemGameProcess());
        }

        public void StartAllGames()
        {
            foreach(var gameKey in _gameProcessDict.Keys)
            {
                _gameProcessDict[gameKey].StartGameProcess();
            }
        }

        public GameProcess GetGameProcessByType(GameType type)
        {
            return _gameProcessDict[type];
        }
    }
}
