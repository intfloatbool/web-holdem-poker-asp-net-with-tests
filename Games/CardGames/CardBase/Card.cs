using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.CardBase
{
    [Serializable]
    public class Card
    {
        public Rank Rank;
        public Suit Suit;

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }
    }
}
