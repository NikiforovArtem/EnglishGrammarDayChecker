// See https://aka.ms/new-console-template for more information

using System.Data.SQLite;

if (!File.Exists(@"C:\EnglishLearningRepo\EnglishGrammarDayChecker\EnglishGrammarDayCheckerDb.sqlite"))
{
    Console.WriteLine("Just entered to create Sync DB");
    SQLiteConnection.CreateFile(@"C:\EnglishLearningRepo\EnglishGrammarDayChecker\EnglishGrammarDayCheckerDb.sqlite");
    
    using(var sqlite2 = new SQLiteConnection(@"Data Source=C:\EnglishLearningRepo\EnglishGrammarDayChecker\EnglishGrammarDayCheckerDb.sqlite"))
    {
        sqlite2.Open();
        string sql = "create table GrammarTask (Id nvarchar, TotalCompletionsCount int, Name nvarchar, IsLearned BOOLEAN, URL nvarchar, CreatedDateTime DATETIME, LastCompletionDateTime DATETIME, IsDoneToday BOOLEAN)";
        SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
        command.ExecuteNonQuery();
    }
}