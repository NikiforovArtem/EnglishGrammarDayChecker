using System.Data.SQLite;
using Dapper;
using EnglishGrammarDayChecker.Application.Queries;
using MediatR;

namespace EnglishGrammarDayChecker.Application.Handlers;

public class GetActualGrammarTaskQueryHandler : IRequestHandler<GetActualGrammarTaskQuery, IReadOnlyCollection<GrammarTaskViewModel>>
{
    private readonly string _connectionString;

    public GetActualGrammarTaskQueryHandler(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SqlLite") ?? throw new ArgumentNullException();
    }

    public async Task<IReadOnlyCollection<GrammarTaskViewModel>> Handle(GetActualGrammarTaskQuery request, CancellationToken cancellationToken)
    {
        await using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        SqlMapper.RemoveTypeMap(typeof(DateTimeOffset));
        SqlMapper.AddTypeHandler(DateTimeHandler.Default);

        var result = await connection.QueryAsync<GrammarTaskViewModel>(
            @"select Id, TotalCompletionsCount, Name, IsLearned, URL, IsDoneToday  from GrammarTask where IsDoneToday = 0"
        );

        return result.ToList();
    }
}