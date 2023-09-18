namespace EnglishGrammarDayChecker.Model.Interfaces;

public interface IGrammarTaskRepository
{
    Task<bool> TaskIsAlreadyDone(string taskId);
    
    Task<string> SaveNewGrammarTask(GrammarTask grammarTask);
    
    Task UpdateTaskToDone(string taskId);
    
    Task UpdateTotalCompletionCount(string taskId);
}