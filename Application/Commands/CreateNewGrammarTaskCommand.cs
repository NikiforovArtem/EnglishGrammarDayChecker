using MediatR;

namespace EnglishGrammarDayChecker.Application.Commands;

public record CreateNewGrammarTaskCommand(string Name, string URL) : IRequest;