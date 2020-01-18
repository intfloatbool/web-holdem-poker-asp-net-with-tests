using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.Dices
{
    public class DiceCubes
    {
        public const int MIN_DICE_VALUE = 1;
        public const int MAX_DICE_VALUE = 6;

        public struct DiceResult
        {
            public int X;
            public int Y;
            public DiceResult(int x, int y)
            {
                X = x;
                Y = y;
            }        
        }

        public int LeftCubeResult { get; private set; }
        public int RightCubeResult { get; private set; }

        private Random _random = new Random();

        public DiceResult Throw()
        {
            LeftCubeResult = _random.Next(MIN_DICE_VALUE, MAX_DICE_VALUE + 1);
            RightCubeResult = _random.Next(MIN_DICE_VALUE, MAX_DICE_VALUE + 1);
            return new DiceResult(LeftCubeResult, RightCubeResult);
        }
    }
}
