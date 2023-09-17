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
        //TODO: Need to make counter + 1, when it is done
        // Also need to support when u're trying to press "IsDone" a lot of times and counter will update only 1 time.
        await _grammarTaskRepository.TaskIsDone(request.TaskId);
    }
}