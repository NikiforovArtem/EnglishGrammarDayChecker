using System.Data.SQLite;
using Dapper;
using EnglishGrammarDayChecker.Model.Interfaces;

namespace EnglishGrammarDayChecker.Infrastructure;

internal class GrammarTaskUpdaterService : IGrammarTaskUpdaterService
{
    private readonly string _connectionString;

    public GrammarTaskUpdaterService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SqlLite") ?? throw new ArgumentNullException();
    }

    public async Task UpdateGrammarTasksToUndone()
    {
        await using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        var sql = @"UPDATE GrammarTask SET IsDoneToday = 0 where IsDoneToday = 1";
        await connection.ExecuteAsync(sql);
    }
}