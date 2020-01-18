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

        /// <summary>
        /// for avoid random in tests
        /// </summary>
        public DiceResult? ExternalResult { get; set; } = null;

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
            if (ExternalResult != null)
            {
                LeftCubeResult = ExternalResult.Value.X;
                RightCubeResult = ExternalResult.Value.Y;
                return (DiceResult)ExternalResult;
            }
                

            LeftCubeResult = _random.Next(MIN_DICE_VALUE, MAX_DICE_VALUE + 1);
            RightCubeResult = _random.Next(MIN_DICE_VALUE, MAX_DICE_VALUE + 1);
            return new DiceResult(LeftCubeResult, RightCubeResult);
        }
    }
}
