using System.Data.SQLite;
using Dapper;
using EnglishGrammarDayChecker.Application.Queries;
using EnglishGrammarDayChecker.Model;
using EnglishGrammarDayChecker.Model.Interfaces;

namespace EnglishGrammarDayChecker.Infrastructure;

internal class GrammarTaskRepository : IGrammarTaskRepository
{
    private readonly string _connectionString;

    public GrammarTaskRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SqlLite") ?? throw new ArgumentNullException();
    }

    public async Task<bool> TaskIsAlreadyDone(string taskId)
    {
        await using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        var result = await connection.QuerySingleOrDefaultAsync<string>(
            @"select Id from GrammarTask where Id = @Id and IsDoneToday = 1 LIMIT 1", new {Id = taskId}
        );

        return result != null;
    }

    public async Task<string> SaveNewGrammarTask(GrammarTask grammarTask)
    {
        await using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        var sql =
            "INSERT INTO GrammarTask (Id, Name, URL, CreatedDateTime, IsDoneToday, IsLearned, TotalCompletionsCount ) VALUES (@Id, @Name, @URL, @CreatedDateTime, @IsDoneToday, @IsLearned, @TotalCompletionsCount)";

        var grammarTaskParamsValues = new
            { grammarTask.Id, grammarTask.URL, grammarTask.Name, grammarTask.CreatedDateTime, grammarTask.IsDoneToday, grammarTask.IsLearned, grammarTask.TotalCompletionsCount };
        var rowsAffected = await connection.ExecuteAsync(sql, grammarTaskParamsValues);
        Console.WriteLine($"{rowsAffected} row(s) inserted.");

        return grammarTask.Id;
    }

    public async Task UpdateTaskToDone(string taskId)
    {
        await using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
            
        var sql = @"UPDATE GrammarTask SET IsDoneToday = 1 where Id = @taskId";
        await connection.ExecuteAsync(sql, new { taskId });
    }

    public async Task UpdateTotalCompletionCount(string taskId)
    {
        await using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
            
        var sql = @"UPDATE GrammarTask SET TotalCompletionsCount = TotalCompletionsCount + 1 where Id = @taskId";
        await connection.ExecuteAsync(sql, new { taskId });
    }
}