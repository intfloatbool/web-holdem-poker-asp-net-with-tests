using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class OnePairSearcher : CardSearcherBase
    {
        public override Combo SearcingCombo => Combo.ONE_PAIR;

        protected override void SearchCards()
        {
            var searchingCardsCount = 2;
            var searchingPairs = HoldemHelper.GetPairsFromCollection(_cardSource)?.ToList();
            if (searchingPairs == null)
                return;
            if(searchingPairs.Count == searchingCardsCount)
            {
                _searchedCards.AddRange(searchingPairs);
            }
        }
    }
}
