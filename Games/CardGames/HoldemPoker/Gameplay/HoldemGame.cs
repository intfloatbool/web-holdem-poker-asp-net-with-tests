using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.Gameplay
{
    public class HoldemGame
    {
        private CardDealer _dealer;
        private DeckOfCards _deck;
        private CardTable _table;
        private WinnerChecker _winnerChecker;

        private readonly PlayerType[] _playersFlags = new PlayerType[]
        {
            PlayerType.PLAYER_1,
            PlayerType.PLAYER_2
        };

        private Dictionary<PlayerType, HoldemPlayer> _playersDict = new Dictionary<PlayerType, HoldemPlayer>();   
        

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
            var winnerContainer = _winnerChecker.GetWinnerWithCombo(_playersDict.Values,
                _table);
            return winnerContainer.Players.ConvertAll(p => (HoldemPlayer) p);
        }

        public IEnumerable<Card> GetTableCards()
        {
            return _table.Cards;
        }
    }
}
