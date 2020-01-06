using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthWebPoker.Games.CardGames.HoldemPoker.Gameplay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EthWebPoker
{
    public class HoldemApiModel : PageModel
    {
        private readonly HoldemGame _holdemGame;
        public HoldemApiModel(HoldemGame holdemGame)
        {
            _holdemGame = holdemGame;
        }
        public JsonResult OnGet()
        {
            //FOR TEST
            _holdemGame.Start();
            var result = _holdemGame.GetResult();
            return new JsonResult(result);
        }
    }
}