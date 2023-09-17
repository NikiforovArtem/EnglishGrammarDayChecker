namespace EnglishGrammarDayChecker.Model;

public class GrammarTask
{
    public string Id { get; set; }
    
    public bool IsDoneToday { get; set; }
    
    public string URL { get; set; }
    
    public bool IsLearned { get; set; }
    
    public string Name { get; set; }
    
    public DateTimeOffset CreatedDateTime { get; set; }
    
    public DateTimeOffset LastCompletionDateTime { get; set; }
    
    public int TotalCompletionsCount { get; set; }
}