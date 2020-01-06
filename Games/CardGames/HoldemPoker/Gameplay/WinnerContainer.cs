using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.Gameplay
{
    public class WinnerContainer
    {
        public List<ICardHolder> Players { get;  set; }
        public Combo? Combination { get; set; }
    }
}
