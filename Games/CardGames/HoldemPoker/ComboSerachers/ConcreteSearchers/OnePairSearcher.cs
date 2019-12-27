using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers.ConcreteSearchers
{
    public class OnePairSearcher : ICardSearcher
    {
        public Combo SearcingCombo => Combo.ONE_PAIR;

        public List<Card> SearchCards(List<Card> cardSource)
        {
            var searchedCards = new List<Card>();
            var countOfPair = 2;
            var tableRanks = cardSource.Select(card => card.Rank);
            foreach(var rank in tableRanks)
            {
                var anotherCardsWithThisRank =
                    cardSource.Where(card => card.Rank == rank);
                var searchedCount = anotherCardsWithThisRank.Count();
                if(searchedCount == countOfPair)
                {
                    searchedCards.AddRange(anotherCardsWithThisRank);
                    break;
                }
            }

            return searchedCards;
        }
    }
}
