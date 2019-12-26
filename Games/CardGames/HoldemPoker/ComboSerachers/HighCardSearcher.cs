using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers
{
    public class HighCardSearcher : ICardSearcher
    {
        public Combo SearcingCombo => Combo.HIGH_CARD;

        public List<Card> SearchCards(List<Card> cardSource)
        {
            throw new NotImplementedException();
        }
    }
}
