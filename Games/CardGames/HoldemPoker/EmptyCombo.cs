using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker
{
    /// <summary>
    /// Combo instance that represents NO COMBINATION FOUND replaced NULL..
    /// </summary>
    public class EmptyCombo : ComboCards
    {
        public EmptyCombo() : base(Combo.HIGH_CARD, null)
        {
            
        }
    }
}
