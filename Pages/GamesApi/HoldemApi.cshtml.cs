using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthWebPoker.Games;
using EthWebPoker.Games.CardGames.HoldemPoker.Gameplay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EthWebPoker
{
    public class HoldemApiModel : PageModel
    {
        private readonly GameProcess _holdemGameProcess;
        public HoldemApiModel(GameProcess holdemGameProcess)
        {
            _holdemGameProcess = holdemGameProcess;
        }
        public JsonResult OnGet()
        {
            return new JsonResult(_holdemGameProcess.ResultContainer);
        }
    }
}