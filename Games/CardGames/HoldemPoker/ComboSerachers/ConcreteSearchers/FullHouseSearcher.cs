using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class FullHouseSearcher : CardSearcherBase
    {
        public override Combo SearcingCombo => Combo.FULL_HOUSE;
        protected override void SearchCards()
        {
            //full house is 3 of kind + pair
            var neededValues = new ValueTuple<int, int>(3, 2);
            var tableCardsCopy = _cardSource.ToList();
            var threeOfKindCards = HoldemHelper.GetPairsFromCollection(tableCardsCopy, neededValues.Item1)?.ToList();
            if (threeOfKindCards == null)
                return;

            if(threeOfKindCards.Count() > 0)
            {
                threeOfKindCards.ForEach(card => tableCardsCopy.Remove(card));
                var pairOFCards = HoldemHelper.GetPairsFromCollection(tableCardsCopy);
                if (pairOFCards == null)
                    return;
                if(pairOFCards.Count() == neededValues.Item2)
                {
                    _searchedCards.AddRange(threeOfKindCards);
                    _searchedCards.AddRange(pairOFCards);
                }
            }
        }
    }
}
