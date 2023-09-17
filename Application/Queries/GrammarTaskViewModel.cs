namespace EnglishGrammarDayChecker.Application.Queries;

public record GrammarTaskViewModel(
    string Id, 
    int TotalCompletionsCount,
    string Name,
    bool IsLearned,
    string URL,
    bool IsDoneToday
);