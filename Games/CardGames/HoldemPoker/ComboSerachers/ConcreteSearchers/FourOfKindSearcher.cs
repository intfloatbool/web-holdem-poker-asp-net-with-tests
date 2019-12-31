using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class FourOfKindSearcher : CardSearcherBase
    {
        public override Combo SearcingCombo => Combo.FOUR_OF_A_KIND;
        private const int SAME_COUNT = 4;
        protected override void SearchCards()
        {
            var fourCards = HoldemHelper.GetPairsFromCollection(_cardSource, SAME_COUNT);
            if (fourCards == null)
                return;
            _searchedCards.AddRange(fourCards);
        }
    }
}
