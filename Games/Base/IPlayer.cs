using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.Base
{
    public interface IPlayer
    {
        PlayerType PlayerType { get; set; }
    }
}
