using MediatR;

namespace EnglishGrammarDayChecker.Application.Queries;

public record GetActualGrammarTaskQuery() : IRequest<IReadOnlyCollection<GrammarTaskViewModel>>;