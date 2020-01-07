using EthWebPoker.Games.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games
{
    public class GameProcess
    {
        public IGame Game { get; set; }
        public int IntervalTimeMs { get; set; } = 2000;
        public int WaitTimeIntervalms { get; set; } = 2000;
        public GameResultContainer ResultContainer { get; private set; }

        public Action<GameResultContainer> OnResultUpdated = (result) => { };

        public GameProcess(IGame game)
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
            ResultContainer.MatchID++;        
            ResultContainer.GameType = Game.GameType.ToString();
            ResultContainer.GameResultJson = Game.GetJsonResult();
            ResultContainer.Winners = Game.GetWinnersByType().Select(t => t.ToString()).ToArray();

            OnResultUpdated(ResultContainer);
        }

        private void ResetResultContainer()
        {
            ResultContainer.Winners = null;
            ResultContainer.GameType = null;
            ResultContainer.GameResultJson = null;
        }
    }

}
