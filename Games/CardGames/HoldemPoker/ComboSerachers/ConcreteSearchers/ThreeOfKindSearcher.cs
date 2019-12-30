using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class ThreeOfKindSearcher : CardSearcherBase
    {
        public override Combo SearcingCombo => Combo.THREE_OF_A_KIND;

        protected override void SearchCards()
        {
            var searchingPairsCount = 1;
            var sameCardsCount = 3;
            var searchingPairs = HoldemHelper.GetPairsFromCollection(_cardSource, sameCardsCount).ToList();
            if (searchingPairs.Count == searchingPairsCount)
            {
                searchingPairs.ForEach(pair => _searchedCards.AddRange(pair.CardsCollection));
            }
        }
    }
}
