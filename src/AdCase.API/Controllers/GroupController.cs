using AdCase.Application.Features.Commands.DrawGroup;
using AdCase.Application.Features.Queries.GetGroup;
using AdCase.Domain.Helpers;
using AdCase.Domain.Rules;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace AdCase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

     

        [HttpPost("Draw")]
        public async Task<IActionResult> DrawGroups([FromBody] DrawGroupsCommand drawGroupsCommand)
        {
            //RULES CONTROL
            LeagueRuleModel leagueRuleModel = new() { GroupCount = drawGroupsCommand.GroupCount, DrawnBy = drawGroupsCommand.DrawnBy };
            var (valid, errMessage) = RuleHelper.CheckRules(leagueRuleModel);

            if (valid == false)
            {
                return BadRequest(errMessage);
            }

            // Start Command
            var result = await _mediator.Send(drawGroupsCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var query = new GetGroupsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
