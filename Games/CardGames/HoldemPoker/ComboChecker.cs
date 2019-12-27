using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker
{
    public class ComboChecker
    {
        private static ComboChecker _instance;
        public static ComboChecker Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ComboChecker();
                return _instance;
            }
        }

        //From higher to smaller
        private List<Combo> _reversedCombinations;
        public List<Combo> ReversedCombinations => _reversedCombinations;
        private ComboChecker()
        {
            _reversedCombinations = HoldemHelper.GetCombinations();
            _reversedCombinations.Reverse();
        }

        public ComboCards CheckCombo(List<Card> cards)
        {
            foreach (var combination in _reversedCombinations)
            {
                var searcher = CardSearcherFactory.GetCardSearcherByCombo(combination);
                if (searcher == null)
                    continue;

                var searchedCards = searcher.SearchCards(cards);
                var currentCombo = searcher.SearcingCombo;
                return ComboCards.Create(currentCombo, searchedCards);
            }
            return null;
        }
    }
}
