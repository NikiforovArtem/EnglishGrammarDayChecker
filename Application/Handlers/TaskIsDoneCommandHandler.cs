using EnglishGrammarDayChecker.Application.Commands;
using EnglishGrammarDayChecker.Model.Interfaces;
using MediatR;

namespace EnglishGrammarDayChecker.Application.Handlers;

public class TaskIsDoneCommandHandler : IRequestHandler<TaskIsDoneCommand>
{
    private readonly IGrammarTaskRepository _grammarTaskRepository;
    
    public TaskIsDoneCommandHandler(IGrammarTaskRepository grammarTaskRepository)
    {
        _grammarTaskRepository = grammarTaskRepository;
    }

    public async Task Handle(TaskIsDoneCommand request, CancellationToken cancellationToken)
    {
        await _grammarTaskRepository.TaskIsDone(request.TaskId);
    }
}