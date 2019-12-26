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
    }
}
