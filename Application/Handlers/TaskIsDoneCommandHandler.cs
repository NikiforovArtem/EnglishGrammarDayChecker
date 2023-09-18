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
        //TODO: Need to get GrammarTask domain aggregate and work with it
        if (await _grammarTaskRepository.TaskIsAlreadyDone(request.TaskId))
        {
            return;
        }
        
        //TODO: it could be implement through DomainsEvents, and it should be at the one transaction
        // TODO: i'd like to made it with EF. Domain aggregate will has methods like setTaskIsDone and after that 
        // it will send domain event TaskIsUpdateToDone then will updated totalCounter in domainEvent Handler
        // and ofcourse these actions should be joined in UnitOfWork for one atomic operation in DB.
        await _grammarTaskRepository.UpdateTaskToDone(request.TaskId);
        await _grammarTaskRepository.UpdateTotalCompletionCount(request.TaskId);
    }
}