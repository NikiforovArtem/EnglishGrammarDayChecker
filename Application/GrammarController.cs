using EnglishGrammarDayChecker.Application.Commands;
using EnglishGrammarDayChecker.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnglishGrammarDayChecker.Application
{
    [ApiController]
    [Route("grammar")]
    public class GrammarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GrammarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("actual")]
        [ProducesResponseType(typeof(IReadOnlyCollection<GrammarTaskViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyCollection<GrammarTaskViewModel>>> GetActualGrammarTasks()
        {
            var actualGrammarTasks = await _mediator.Send(new GetActualGrammarTaskQuery());
            
            return Ok(actualGrammarTasks);
        }
        
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveNewGrammarTask([FromBody] CreateNewGrammarTaskCommand command)
        { 
            await _mediator.Send(command);
            
            return Ok();
        }
        
        [HttpPost]
        [Route("done")]
        public async Task<IActionResult> TasksIsDone(TaskIsDoneCommand command)
        {
            await _mediator.Send(command);
            
            return Ok();
        }
        
        /*[HttpPost]
        
        //TODO: some filtration by day, by count and etc
        [HttpPost]
        public async Task<IActionResult> GetStatistic()
        {
            throw new NotImplementedException();

        }*/
    }
}