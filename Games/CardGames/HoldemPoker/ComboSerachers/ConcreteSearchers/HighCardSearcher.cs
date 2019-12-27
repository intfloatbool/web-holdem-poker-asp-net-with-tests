using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class HighCardSearcher : CardSearcherBase
    {
        public override Combo SearcingCombo => Combo.HIGH_CARD;

        protected override void SearchCards()
        {
            var higherCard = _cardSource.OrderBy(card => card.Rank)
                .LastOrDefault();
            if (higherCard != null)
                _searchedCards.Add(higherCard);
        }
    }
}
