using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.CardBase
{
    public interface ICardHolder
    {
        public List<Card> Cards { get; }
        public void AddCard(Card card);
        public void FoldCards();
    }
}
