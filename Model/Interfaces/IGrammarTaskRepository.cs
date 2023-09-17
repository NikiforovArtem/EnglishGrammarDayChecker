namespace EnglishGrammarDayChecker.Model.Interfaces;

public interface IGrammarTaskRepository
{
    GrammarTask GetActualGrammarTasks();

    Task TaskIsDone(Guid taskId);
}