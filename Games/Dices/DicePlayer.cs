using EthWebPoker.Games.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.Dices
{
    public class DicePlayer : IPlayer
    {
        public PlayerType PlayerType { get; set; }
        public DiceCubes DiceCubes { get; }

        public DicePlayer(PlayerType playerType)
        {
            this.PlayerType = playerType;
            DiceCubes = new DiceCubes();
        }

        public int GetSum()
        {
            return DiceCubes.LeftCubeResult + DiceCubes.RightCubeResult;
        }
    }
}
