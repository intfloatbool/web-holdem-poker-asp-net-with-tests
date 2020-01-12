using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.Base
{
    public interface IGameProcessProvider
    {
        GameProcess GetGameProcessByType(GameType type);
    }
}
