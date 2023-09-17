namespace EnglishGrammarDayChecker.Model;

public class GrammarTask
{ 
    public GrammarTask(string name, string URL)
    {
        Id = Guid.NewGuid().ToString();
        CreatedDateTime = DateTimeOffset.Now;
        Name = name;
        this.URL = URL;
        IsDoneToday = false;
        IsLearned = false;
        TotalCompletionsCount = 0;
    }
    
    public string Id { get; }
    
    public bool IsDoneToday { get; private set; } 
    
    public string URL { get; }
    
    public bool IsLearned { get; }
    
    public string Name { get; }
    
    public DateTimeOffset CreatedDateTime { get; }
    
    public DateTimeOffset? LastCompletionDateTime { get; private set; }
    
    public int TotalCompletionsCount { get; private set; }
}