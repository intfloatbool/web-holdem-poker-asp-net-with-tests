using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.Base
{
    public interface IGame
    {
        GameType GameType { get; }
        void Start();
        string GetJsonResult();

        IEnumerable<PlayerType> GetWinnersByType();
    }
}
