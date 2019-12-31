using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class FlushSearcher : CardSearcherBase
    {
        public override Combo SearcingCombo => Combo.FLUSH;

        protected override void SearchCards()
        {
            var suitedCards = HoldemHelper.GetSuitedCards(_cardSource);

            if(suitedCards != null)
            {
                _searchedCards = suitedCards.Item2;
            }
        }
    }
}
