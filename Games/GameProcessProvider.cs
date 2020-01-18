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

        //Games constants

        //times in miliseconds
        private const int HOLDEM_GAME_TIME = 25000; 
        private const int HOLDEM_PAUSE_TIME = 15000;

        private const int DICE_GAME_TIME = 10000;
        private const int DICE_PAUSE_TIME = 15000;

        private void InitializeDict()
        {
            _gameProcessDict.Add(GameType.HOLDEM_POKER, GameProcess.HoldemGameProcess(HOLDEM_GAME_TIME, HOLDEM_PAUSE_TIME));

            _gameProcessDict.Add(GameType.DICES, GameProcess.DicesGameProcess(DICE_GAME_TIME, DICE_PAUSE_TIME));
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
