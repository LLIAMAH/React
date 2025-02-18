using Microsoft.EntityFrameworkCore;
using React.DB;
using React.DB.Entities;
using React.DB.Reps;
using React.DB.Reps.Interfaces;
using React.Dto;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add services to the container.
builder.Services.AddDbContext<AppDbCtx>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.Fetch);
    });
}

app.UseHttpsRedirection();

app.MapGet("/projects", async (IUnitOfWork unitOfWork) =>
    {
        var data = await unitOfWork.RepProjects.Get(includes:"Tickets,Tickets.Status", asNoTracking:true)
            .Select(o => new ProjectDto()
            {
                Id = o.Id,
                Name = o.Name,
                Tickets = o.Tickets.Select(t => new TicketDto()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = new StatusDto() { Id = t.Status.Id, Name = t.Status.Name }
                }).ToList()
            })
            .ToListAsync();
        return new Result<IList<ProjectDto>>(data);
    })
    .WithName("Projects");

app.MapGet("/tickets", async (IUnitOfWork unitOfWork) =>
    {
        var data = await unitOfWork.RepTickets.Get(includes:"Status", asNoTracking:true)
            .Select(o=> new TicketDto()
            {
                Id = o.Id,
                Title = o.Title,
                Description = o.Description,
                Status = new StatusDto() { Id = o.Status.Id, Name = o.Status.Name }
            })
            .ToListAsync();
        return new Result<IList<TicketDto>>(data);
    })
    .WithName("Tickets");

app.MapGet("/statuses", async (IUnitOfWork unitOfWork) =>
    {
        var data = await unitOfWork.RepStatuses.Get(asNoTracking:true)
            .Select(o=> new StatusDto()
            {
                Id = o.Id,
                Name = o.Name
            })
            .ToListAsync();
        
        return new Result<IList<StatusDto>>(data);
    })
    .WithName("Statuses");

app.Run();
