using EthWebPoker.Games.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.Dices
{
    public class DiceGame : IGame
    {
        public GameType GameType => GameType.DICES;

        private Dictionary<PlayerType, DicePlayer> _playersDict = new Dictionary<PlayerType, DicePlayer>()
        {
            {PlayerType.PLAYER_1, new DicePlayer(PlayerType.PLAYER_1) },
            {PlayerType.PLAYER_2, new DicePlayer(PlayerType.PLAYER_2) }
        };

        public IEnumerable<DicePlayer> Winners { get; private set; }
        private IEnumerable<PlayerType> _currentWinners;
        
        private readonly JsonConverter _converter = new StringEnumConverter();

        [Serializable]
        private class DiceGameResult
        {
            public int Player1_LeftDiceResult;
            public int Player1_RightDiceResult;
            public int Player1_DiceSum;

            public int Player2_LeftDiceResult;
            public int Player2_RightDiceResult;
            public int Player2_DiceSum;      

            public PlayerType[] Winners;

            public DiceGameResult(DicePlayer p1, DicePlayer p2, IEnumerable<PlayerType> winners)
            {
                Player1_LeftDiceResult = p1.DiceCubes.LeftCubeResult;
                Player1_RightDiceResult = p1.DiceCubes.RightCubeResult;
                Player1_DiceSum = p1.GetSum();

                Player2_LeftDiceResult = p2.DiceCubes.LeftCubeResult;
                Player2_RightDiceResult = p2.DiceCubes.RightCubeResult;
                Player2_DiceSum = p2.GetSum();

                Winners = winners.ToArray();
            }
        }

        public DicePlayer GetPlayerByType(PlayerType playerType)
        {
            return _playersDict[playerType];
        }

        public string GetJsonResult()
        {
            var result = new DiceGameResult(
                GetPlayerByType(PlayerType.PLAYER_1),
                GetPlayerByType(PlayerType.PLAYER_2),
                _currentWinners
                );
            string output = JsonConvert.SerializeObject(result, _converter);
            return output;
        }

        public IEnumerable<PlayerType> GetWinnersByType()
        {
            return _currentWinners;
        }

        public void Start()
        {
            var lastSum = 0;
            foreach(var playerType in _playersDict.Keys)
            {
                var player = _playersDict[playerType];
                player.DiceCubes.Throw();
                var playerSum = player.GetSum();
                if(playerSum >= lastSum)
                {
                    lastSum = playerSum;
                }
            }

            Winners = _playersDict.Values.Where(p => p.GetSum() == lastSum);
            _currentWinners = Winners.Select(p => p.PlayerType);
        }
    }
}
