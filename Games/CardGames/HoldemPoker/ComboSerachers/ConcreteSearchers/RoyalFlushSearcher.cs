using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class RoyalFlushSearcher : StraightFlashSearcher
    {
        public override Combo SearcingCombo => Combo.ROYAL_FLUSH;

        private const Rank HIGHEST_RANK = Rank.ACE;
        private const Rank LOWEST_RANK = Rank.TEN;

        protected override void SearchCards()
        {
            base.SearchCards();

            if(_searchedCards.Any())
            {
                var firstCard = _searchedCards.FirstOrDefault();
                var lastCard = _searchedCards.LastOrDefault();
                
                if(firstCard == null || lastCard == null)
                {
                    _searchedCards.Clear();
                    return;
                }

                if(firstCard.Rank == LOWEST_RANK && lastCard.Rank == HIGHEST_RANK)
                {
                    return;
                } 
                else
                {
                    _searchedCards.Clear();
                }

            }
           
        }
    }
}
