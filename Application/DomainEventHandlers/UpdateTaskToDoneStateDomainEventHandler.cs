using EnglishGrammarDayChecker.Model.DomainEvents;
using EnglishGrammarDayChecker.Model.Interfaces;
using MediatR;

namespace EnglishGrammarDayChecker.Application.DomainEventHandlers;

public class UpdateTaskToDoneStateDomainEventHandler : INotificationHandler<UpdateTaskToDoneStateDomainEvent>
{
    private readonly IGrammarTaskRepository _grammarTaskRepository;

    public UpdateTaskToDoneStateDomainEventHandler(IGrammarTaskRepository grammarTaskRepository)
    {
        _grammarTaskRepository = grammarTaskRepository;
    }

    public async Task Handle(UpdateTaskToDoneStateDomainEvent notification, CancellationToken cancellationToken)
    {
        
    }
}