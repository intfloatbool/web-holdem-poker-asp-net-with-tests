using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.Player
{
    public class HoldemPlayer : CardPlayer
    {      
        public Combo? Combination { get; set; }
        public List<Card> ComboCards { get; set; }
    }
}
