using EthWebPoker.Games.Base;
using EthWebPoker.Games.CardGames.HoldemPoker.Gameplay;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games
{
    public class GameProcess
    {
        public static GameProcess HoldemGameProcess()
        {
            return new GameProcess(new HoldemGame());
        }

        public IGame Game { get; set; }
        public int IntervalTimeMs { get; set; } = 20000;
        public int WaitTimeIntervalms { get; set; } = 10000;
        public GameResultContainer ResultContainer { get; private set; }

        public Action<GameResultContainer> OnResultUpdated = (result) => { };

        private GameProcess(IGame game)
        {
            this.Game = game;
            this.ResultContainer = new GameResultContainer();
        }

        public void StartGameProcess()
        {
            Task.Run(() =>
            {
                GameProcessAsync();
            });
        }

        private async void GameProcessAsync()
        {
            while(true)
            {
                Game.Start();

                UpdateResultContainer();

                await Task.Delay(IntervalTimeMs);

                ResetResultContainer();

                await Task.Delay(WaitTimeIntervalms);

            }
        }

        private void UpdateResultContainer()
        {
            var culture = new CultureInfo("en-US");
            ResultContainer.Date = DateTime.Now.ToString(culture);
            ResultContainer.MatchID++;        
            ResultContainer.GameType = Game.GameType.ToString();
            ResultContainer.GameResultJson = Game.GetJsonResult();
            ResultContainer.Winners = Game.GetWinnersByType().Select(t => t.ToString()).ToArray();

            OnResultUpdated(ResultContainer);
        }

        private void ResetResultContainer()
        {
            ResultContainer.Date = null;
            ResultContainer.Winners = null;
            ResultContainer.GameType = null;
            ResultContainer.GameResultJson = null;
        }
    }

}
