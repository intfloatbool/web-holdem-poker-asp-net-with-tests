using EthWebPoker.Games.Base;
using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker.Player;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.Gameplay
{
    public class HoldemGame: IGame
    {
        public GameType GameType { get; } = GameType.HOLDEM_POKER;

        private CardDealer _dealer;
        private DeckOfCards _deck;
        private CardTable _table;
        private WinnerChecker _winnerChecker;
        private readonly JsonConverter _converter = new StringEnumConverter();
        private readonly PlayerType[] _playersFlags = new PlayerType[]
        {
            PlayerType.PLAYER_1,
            PlayerType.PLAYER_2
        };

        private Dictionary<PlayerType, HoldemPlayer> _playersDict = new Dictionary<PlayerType, HoldemPlayer>();

        private WinnerContainer _currentWinnerContainer;

        public HoldemGame()
        {
            InitializePlayers();

            this._winnerChecker = new WinnerChecker();
            this._table = new CardTable();
            this._deck = DeckOfCards.CreateDefault();
            this._dealer = new CardDealer(_deck, _playersDict.Values, _table);
        }

        private void InitializePlayers()
        {
            for(int i = 0; i < _playersFlags.Length; i++)
            {
                var flag = _playersFlags[i];
                var player = new HoldemPlayer();
                player.PlayerType = flag;
                _playersDict.Add(flag, player);
            }
        }

        public void Start()
        {
            this._dealer.DealCards();
        }

        public HoldemPlayer GetPlayerByType(PlayerType playerType)
        {
            if (_playersDict.ContainsKey(playerType))
                return _playersDict[playerType];
            return null;
        }

        public IEnumerable<HoldemPlayer> GetWinners()
        {
            this._currentWinnerContainer = _winnerChecker.GetWinnerWithCombo(_playersDict.Values,
                _table);
            return _currentWinnerContainer.Players.ConvertAll(p => (HoldemPlayer)p);
        }

        public IEnumerable<PlayerType> GetWinnersByType()
        {
            return _currentWinnerContainer.Players.Select(p => p.PlayerType);
        }

        public IEnumerable<Card> GetTableCards()
        {
            return _table.Cards;
        }

        [Serializable]
        public class HoldemGameResult
        {
            public HoldemPlayer Player1;
            public HoldemPlayer Player2;
            public PlayerType[] Winners;
            public CardTable CardTable;
        }

        public string GetJsonResult()
        {
            var winners = GetWinners().Select(w => w.PlayerType);
            var result = new HoldemGameResult()
            {
                Player1 = GetPlayerByType(PlayerType.PLAYER_1),
                Player2 = GetPlayerByType(PlayerType.PLAYER_2),
                Winners = winners.ToArray(),
                CardTable = _table
            };

            string output = JsonConvert.SerializeObject(result, _converter);
            return output;
        }

    }
}
