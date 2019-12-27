using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.Cards
{
    public class PairOfCardsByRank
    {
        public static PairOfCardsByRank CreatePair(Card card1, Card card2)
        {
            if (card1.Rank == card2.Rank)
                return new PairOfCardsByRank(card1, card2);

            return null;
        }

        public Card Card1 { get; private set; }
        public Card Card2 { get; private set; }

        public IEnumerable<Card> CardsCollection => new Card[]
        {
            Card1,
            Card2
        };

        private PairOfCardsByRank(Card card1, Card card2)
        {
            this.Card1 = card1;
            this.Card2 = card2;
        }
    }
}
