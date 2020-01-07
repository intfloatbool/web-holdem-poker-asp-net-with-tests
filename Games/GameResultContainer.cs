using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games
{
    [Serializable]
    public class GameResultContainer
    {
        public ulong MatchID { get; set; } = 0;
        public string[] Winners { get; set; }
        public string GameType { get; set; }
        public string GameResultJson { get; set; }
    }
}
