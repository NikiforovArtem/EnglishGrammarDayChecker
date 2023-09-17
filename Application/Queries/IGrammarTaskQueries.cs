namespace EnglishGrammarDayChecker.Application.Queries;

public interface IGrammarTaskQueries
{
    Task<IReadOnlyCollection<GrammarTaskViewModel>> GetActualTasks();
}