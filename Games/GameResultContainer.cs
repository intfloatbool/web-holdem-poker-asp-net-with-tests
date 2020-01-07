using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games
{
    public class GameResultContainer
    {
        public ulong MatchID { get; set; } = 0;
        public PlayerType[] Winners { get; set; }
        public GameType? GameType { get; set; }
        public string GameResultJson { get; set; }
    }
}
