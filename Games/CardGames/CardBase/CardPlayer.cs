using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.CardBase
{
    public class CardPlayer : ICardHolder
    {
        public List<Card> Cards { get; private set; }

        public CardPlayer()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void FoldCards()
        {
            Cards.Clear();
        }
    }
}
