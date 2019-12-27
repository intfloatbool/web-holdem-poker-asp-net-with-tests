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
            var searchingPairsCount = 2;
            var searchingPairs = HoldemHelper.GetPairsFromCollection(_cardSource).ToList();
            if (searchingPairs.Count == searchingPairsCount)
            {
                searchingPairs.ForEach(pair => _searchedCards.AddRange(pair.CardsCollection));
            }
        }
    }
}
