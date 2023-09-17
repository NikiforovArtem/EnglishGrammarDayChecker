using Microsoft.AspNetCore.Mvc;

namespace EnglishGrammarDayChecker.Application
{
    [ApiController]
    [Route("grammar")]
    public class GrammarController : ControllerBase
    {
        public GrammarController()
        { 
        }
        
        [HttpGet]
        public async Task<IActionResult> GetActualGrammarTasks()
        {
            try
            {
                if (incomingMessage.Type is UpdateType.Message)
                {
                    
                    await this.messageHandler.HandleTelegramMessageAsync(incomingMessage.Message);
                }s
            }
            catch (Exception e)
            {
                // Only for debug. Chat id can use only in controller layer. Filters dont get it
                await botClient.SendTextMessageAsync(
                    chatId: incomingMessage.Message.Chat.Id,
                    text: $"Произошла ошибка при отправке сообщения '{incomingMessage.Message.Text}'. Message={e.Message};StackTrace={e.StackTrace}");
            }
            
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> SaveNewGrammarTask()
        {
        }

        [HttpPost]
        public async Task<IActionResult> TasksIsDone(IReadOnlyCollection<Guid> tasksIds)
        {
        }
        
        //TODO: some filtration by day, by count and etc
        [HttpPost]
        public async Task<IActionResult> GetStatistic()
        {
        }
    }
}