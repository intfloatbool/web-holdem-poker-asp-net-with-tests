using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker
{
    public static class HoldemHelper
    {
        private static List<Combo> _combinations;
        public static List<Combo> GetCombinations()
        {
            if(_combinations == null)
            {
                var comboNames = Enum.GetNames(typeof(Combo));
                _combinations = new List<Combo>();
                for(int i = 0; i < comboNames.Length; i++)
                {
                    _combinations.Add((Combo)i);
                }
               
            }
            return _combinations;
        }

        private static List<Suit> _suits;
        public static List<Suit> GetSuits()
        {
            if (_suits == null)
            {
                var suitNames = Enum.GetNames(typeof(Suit));
                _suits = new List<Suit>();
                for (int i = 0; i < suitNames.Length; i++)
                {
                    _suits.Add((Suit)i);
                }

            }
            return _suits;
        }

        public static IEnumerable<PairOfCardsByRank> GetPairsFromCollection(List<Card> tableCards,
            int cardsCount = 2)
        {
            var tableRanks = tableCards.Select(card => card.Rank);
            var tableCardsCopy = tableCards.ToList();
            foreach (var rank in tableRanks)
            {
                var anotherCardsWithThisRank =
                    tableCardsCopy.Where(card => card.Rank == rank)
                    .ToArray();
                var searchedCount = anotherCardsWithThisRank.Length;
                if (searchedCount == cardsCount)
                {
                    var firstCard = anotherCardsWithThisRank[0];
                    var secondCard = anotherCardsWithThisRank[1];

                    var pair = PairOfCardsByRank.CreatePair(
                        firstCard,
                        secondCard);
                    tableCardsCopy.Remove(firstCard);
                    tableCardsCopy.Remove(secondCard);
                    yield return pair;
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableCards">cards from table</param>
        /// <param name="suitsCount"> cout to search same suits</param>
        /// <returns>Tuple<Suit = SearchedSuit, bool = isHaveSame></returns>
        public static Tuple<Suit, List<Card>> GetSuitedCards(List<Card> tableCards, int suitsCount = 5)
        {
            foreach(var suit in GetSuits())
            {
                var suitableCards = tableCards.Where(card => card.Suit == suit);
                if(suitableCards.Count() == suitsCount)
                {
                    var resultTuple = new Tuple<Suit, List<Card>>(Suit.CLUBS, suitableCards.ToList());
                    return resultTuple;
                }
            }

            return null;
        }
    }
}
