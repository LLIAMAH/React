namespace React.DB.Reps.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepProjects RepProjects { get; }
    IRepTickets RepTickets { get; }
    
    Task<IResultBool> SaveChangesAsync();
}