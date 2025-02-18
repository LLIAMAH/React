using Microsoft.Extensions.Logging;
using React.DB.Reps.Interfaces;

namespace React.DB.Reps;

public class UnitOfWork: IUnitOfWork
{
    private readonly ILogger<UnitOfWork> _logger;
    private readonly AppDbCtx _ctx;
    
    public IRepProjects RepProjects { get; }
    public IRepTickets RepTickets { get; }
    public IRepStatuses RepStatuses { get; }

    public UnitOfWork(AppDbCtx ctx, ILogger<UnitOfWork> logger)
    {
        this._logger = logger;
        this._ctx = ctx;
        this.RepProjects = new RepProjects(ctx);
        this.RepTickets = new RepTickets(ctx);
        this.RepStatuses = new RepStatuses(ctx);
    }

    public async Task<IResultBool> SaveChangesAsync()
    {
        try
        {
            await this._ctx.SaveChangesAsync();
            return new ResultBool(true);
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, ex.Message);
            return new ResultBool(ex.Message);
        }
    }
    
    #region IDisposable
    public void Dispose()
    {
        this._ctx.Dispose();
        GC.SuppressFinalize(this);
    }
    #endregion
}