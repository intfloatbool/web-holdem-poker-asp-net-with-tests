using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.Gameplay
{
    public class WinnerChecker
    {
        private IEnumerable<ICardHolder> _players;
        private ICardHolder _table;
        private List<PlayerWithCombo> _playersWithCombo;

        private WinnerContainer _winnerContainer = new WinnerContainer()
        {
            Players = new List<ICardHolder>()
        };

        private class PlayerWithCombo
        {
            public ICardHolder Player { get; set; }
            public Combo? Combination { get; set; }
            public Rank Kicker { get; set; }
            public List<Card> ComboCards { get; set; }
            public List<Card> TotalCards { get; set; }
        }

        private void ResetWinnerContainer()
        {
            _winnerContainer.Combination = null;
            _winnerContainer.Players?.Clear();
        }

        public WinnerContainer GetWinnerWithCombo(IEnumerable<ICardHolder> players, ICardHolder table)
        {
            ResetWinnerContainer();

            _players = players;
            _table = table;

            var playersWithCombo = new List<PlayerWithCombo>();
            
            foreach(var player in _players)
            {
                var totalCards = player.Cards.ToList();
                totalCards.AddRange(_table.Cards);
                var playerCombo = ComboChecker.Instance.CheckCombo(totalCards);
                playersWithCombo.Add(
                    new PlayerWithCombo()
                    {
                        Player = player,
                        Combination = playerCombo.Combo,
                        Kicker = totalCards.Max(c => c.Rank),
                        ComboCards = playerCombo.Cards,
                        TotalCards = totalCards
                    });
            }

            var highestCombo = playersWithCombo.OrderByDescending(p => p.Combination).ToList().FirstOrDefault()?.Combination;

            if(highestCombo != null)
            {
                var playersWithHighCombo = playersWithCombo.Where(p => p.Combination == highestCombo);

                _winnerContainer.Combination = highestCombo;
                if(playersWithHighCombo.Count() > 1)
                {
                    CorrectPlayersListBySameCombo(playersWithCombo);
                }
                foreach(var playerWithCombo in playersWithHighCombo)
                {                
                    _winnerContainer.Players.Add(playerWithCombo.Player);
                }
            }

            return _winnerContainer;
        }

        /// <summary>
        /// Runs when players have same combination and need to calculate winner
        /// </summary>
        /// <param name="playersWithCombo"></param>
        private void CorrectPlayersListBySameCombo(List<PlayerWithCombo> playersWithCombo)
        {
            var combination = playersWithCombo.FirstOrDefault()?.Combination;
            this._playersWithCombo = playersWithCombo;

            if (combination == null)
                return;
            switch(combination)
            {
                case Combo.TWO_PAIR:
                    {
                        RemovePlayersByHandStrength();
                        break;
                    }
                case Combo.FULL_HOUSE:
                    {
                        RemovePlayersByHandStrength();
                        break;
                    }
                default:
                    {
                        RemoveAllPlayersByKicker();
                        break;
                    }
            }
        }

        private void RemovePlayersByHandStrength()
        {
            List<PlayerWithCombo> weakestPlayers = null;

            var orderedbyHandStrength = _playersWithCombo.OrderByDescending(pc =>
           GetHandStrength(pc));

            var lastHandStrength = 0;
            foreach (var playerCombo in orderedbyHandStrength)
            {
                var handStrength = GetHandStrength(playerCombo);

                if (handStrength >= lastHandStrength)
                {
                    lastHandStrength = handStrength;
                    continue;
                }

                if (handStrength < lastHandStrength)
                {
                    if (weakestPlayers == null)
                        weakestPlayers = new List<PlayerWithCombo>();
                    weakestPlayers.Add(playerCombo);
                }
            }

            if (weakestPlayers != null)
            {
                weakestPlayers.ForEach(wp =>
                {
                    _playersWithCombo.Remove(wp);
                });
            }
        }

        private bool RemoveAllPlayersByKicker()
        {          
            var highestKicker = _playersWithCombo.Max(pc => pc.Kicker);
            var isSameKicker = _playersWithCombo.All(pc => pc.Kicker == highestKicker);
            if (!isSameKicker)
                _playersWithCombo.RemoveAll(pc => pc.Kicker < highestKicker);
            return isSameKicker;
        }

        private int GetHandStrength(PlayerWithCombo comboPlayer)
        {
            var cardStrength = 0;
            comboPlayer.ComboCards.ForEach(c =>
            {
                cardStrength += (int)c.Rank;
            });
            return cardStrength;
        }
    }
}
