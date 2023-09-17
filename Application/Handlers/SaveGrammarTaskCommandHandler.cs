using EnglishGrammarDayChecker.Application.Commands;
using EnglishGrammarDayChecker.Model;
using EnglishGrammarDayChecker.Model.Interfaces;
using MediatR;

namespace EnglishGrammarDayChecker.Application.Handlers;

public class SaveGrammarTaskCommandHandler : IRequestHandler<CreateNewGrammarTaskCommand>
{
    private readonly IGrammarTaskRepository _grammarTaskRepository;
    
    public SaveGrammarTaskCommandHandler(IGrammarTaskRepository grammarTaskRepository)
    {
        _grammarTaskRepository = grammarTaskRepository;
    }
    
    public async Task Handle(CreateNewGrammarTaskCommand request, CancellationToken cancellationToken)
    {
        var grammarTask = new GrammarTask(request.Name, request.URL);

        await _grammarTaskRepository.SaveNewGrammarTask(grammarTask);
    }
}