using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers
{
    public abstract class CardSearcherBase : ICardSearcher
    {
        public abstract Combo SearcingCombo { get; }
        protected List<Card> _searchedCards = new List<Card>();
        protected List<Card> _cardSource;
        protected abstract void SearchCards();
        public virtual List<Card> SearchCards(List<Card> cardSource)
        {
            _cardSource = cardSource;
            SearchCards();
            var searchedCopy = _searchedCards.ToList();
            _searchedCards.Clear();
            return searchedCopy;
        }
    }
}
