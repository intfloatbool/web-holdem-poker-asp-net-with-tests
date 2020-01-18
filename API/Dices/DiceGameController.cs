using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthWebPoker.Games;
using EthWebPoker.Games.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EthWebPoker.API.Dices
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceGameController : ControllerBase
    {
        private readonly GameProcess _diceGameProcess;
        public DiceGameController(IGameProcessProvider processProvider)
        {
            _diceGameProcess = processProvider.GetGameProcessByType(GameType.DICES);
        }

        // GET: api/HoldemGame
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_diceGameProcess.ResultContainer);
        }
    }
}
