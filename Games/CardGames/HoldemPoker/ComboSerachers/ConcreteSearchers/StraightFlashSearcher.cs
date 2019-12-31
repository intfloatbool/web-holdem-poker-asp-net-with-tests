using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class StraightFlashSearcher : StraightSearcher
    {
        public override Combo SearcingCombo => Combo.STRAIGHT_FLUSH;

        protected override void SearchCards()
        {
            base.SearchCards();

            if(_searchedCards.Any())
            {
                //check that straight is flush
                var suitedCards = HoldemHelper.GetSuitedCards(_searchedCards);
                if(suitedCards != null)
                {
                    _searchedCards = suitedCards.Item2;
                } else
                {
                    _searchedCards.Clear();
                }
            }
        }
    }
}
