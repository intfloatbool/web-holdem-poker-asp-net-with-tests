using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class HighCardSearcher : ICardSearcher
    {
        public Combo SearcingCombo => Combo.HIGH_CARD;

        public List<Card> SearchCards(List<Card> cardSource)
        {
            var cardsOfCombo = new List<Card>();
            var higherCard = cardSource.OrderBy(card => card.Rank)
                .LastOrDefault();
            if (higherCard != null)
                cardsOfCombo.Add(higherCard);
            return cardsOfCombo;
        }
    }
}
