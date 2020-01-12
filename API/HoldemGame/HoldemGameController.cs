using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthWebPoker.Games;
using EthWebPoker.Games.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EthWebPoker.API.HoldemGame
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoldemGameController : ControllerBase
    {

        private readonly GameProcess _holdemProcess;
        public HoldemGameController(IGameProcessProvider processProvider)
        {
            _holdemProcess = processProvider.GetGameProcessByType(GameType.HOLDEM_POKER);
        }

        // GET: api/HoldemGame
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_holdemProcess.ResultContainer);
        }
    }
}
