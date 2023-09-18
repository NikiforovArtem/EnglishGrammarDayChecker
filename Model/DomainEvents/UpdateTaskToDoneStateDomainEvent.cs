using MediatR;

namespace EnglishGrammarDayChecker.Model.DomainEvents;

public record UpdateTaskToDoneStateDomainEvent(string TaskId) : INotification;