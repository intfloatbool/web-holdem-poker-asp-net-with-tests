using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class TwoPairsSearcher : CardSearcherBase
    {
        public override Combo SearcingCombo => Combo.TWO_PAIR;

        protected override void SearchCards()
        {
            var searchingCardsCount = 2;
            var firstPair = HoldemHelper.GetPairsFromCollection(_cardSource)?.ToList();
            if (firstPair == null)
                return;
            if (firstPair.Count == searchingCardsCount)
            {
                var copy = _cardSource.ToList();
                firstPair.ForEach(card => copy.Remove(card));
                var secondPair = HoldemHelper.GetPairsFromCollection(copy)?.ToList();
                if (secondPair == null)
                    return;
                if(secondPair.Count == searchingCardsCount)
                {
                    _searchedCards.AddRange(firstPair);
                    _searchedCards.AddRange(secondPair);
                }
            }
        }
    }
}
