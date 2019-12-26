using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.ComboSerachers
{
    public interface ICardSearcher
    {
        Combo SearcingCombo { get; }
        List<Card> SearchCards(List<Card> cardSource);

    }
}
