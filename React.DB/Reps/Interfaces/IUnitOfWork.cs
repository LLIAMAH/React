namespace React.DB.Reps.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepProjects RepProjects { get; }
    IRepTickets RepTickets { get; }
    IRepStatuses RepStatuses { get; }
    IRepTags RepTags { get; }
    
    Task<IResultBool> SaveChangesAsync();
}