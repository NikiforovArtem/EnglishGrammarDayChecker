using MediatR;

namespace EnglishGrammarDayChecker.Application.Commands;

public record TaskIsDoneCommand(string TaskId) : IRequest;