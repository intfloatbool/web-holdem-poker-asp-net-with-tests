using EthWebPoker.Games.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.CardBase
{
    public class DeckOfCards
    {
        public static DeckOfCards CreateDefault()
        {
            return new DeckOfCards(Rank.TWO);
        }
        public static DeckOfCards Create(Rank minRank)
        {
            return new DeckOfCards(minRank);
        }


        private Rank _minRank;

        public List<Card> DeckCards { get; private set; } = new List<Card>();

        private DeckOfCards(Rank minRank)
        {
            _minRank = minRank;
        }

        public void RefershDeck(bool isShuffle = true)
        {
            DeckCards.Clear();
            GenerateCards();
            if(isShuffle)
                ShuffleCards();          
        }

        private void GenerateCards()
        {
            var suitNames = Enum.GetNames(typeof(Suit));
            var rankNames = Enum.GetNames(typeof(Rank));

            for(int i = 0; i < suitNames.Length; i++)
            {
                var suit = (Suit)i;
                for(int j = 0; j < rankNames.Length; j++)
                {
                    var rank = (Rank) j;
                    if (rank < _minRank)
                        continue;
                    var card = new Card(rank, suit);
                    DeckCards.Add(card);
                }
            }
        }

        public void ShuffleCards(int shufflesAmount = 10)
        {
            IEnumerable<Card> shuffled = null;
            var random = new Random();
            for ( int i = 0; i < shufflesAmount; i++)
            {
                shuffled = DeckCards.Shuffle(random);
            }

            if(shuffled != null)
                DeckCards = shuffled.ToList();
        }
    }
}
