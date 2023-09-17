namespace EnglishGrammarDayChecker.Model.Interfaces;

public interface IGrammarTaskRepository
{
    Task<string> SaveNewGrammarTask(GrammarTask grammarTask);
    
    Task TaskIsDone(string taskId);
}