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

        public static IEnumerable<PairOfCardsByRank> GetPairsFromCollection(List<Card> tableCards)
        {
            var countOfPair = 2;
            var tableRanks = tableCards.Select(card => card.Rank);
            var tableCardsCopy = tableCards.ToList();
            foreach (var rank in tableRanks)
            {
                var anotherCardsWithThisRank =
                    tableCardsCopy.Where(card => card.Rank == rank)
                    .ToArray();
                var searchedCount = anotherCardsWithThisRank.Length;
                if (searchedCount == countOfPair)
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
    }
}
