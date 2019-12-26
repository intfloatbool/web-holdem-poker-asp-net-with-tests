using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.CardBase
{
    public class CardPlayer
    {
        public List<Card> Cards { get; protected set; }
        public int CardCount => Cards.Count;

        public CardPlayer(IEnumerable<Card> cards = null)
        {
            if(cards != null)
            {
                this.Cards = cards.ToList();
            } else
            {
                this.Cards = new List<Card>();
            }
        }

        public void AddCard(Card card)
        {
            this.Cards.Add(card);
        }

        public List<Card> DropCards()
        {
            var lastCards = Cards.ToList();
            Cards.Clear();
            return lastCards;
        }
    }
}
