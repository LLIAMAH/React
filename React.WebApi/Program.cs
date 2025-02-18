using Microsoft.EntityFrameworkCore;
using React.DB;
using React.DB.Entities;
using React.DB.Reps;
using React.DB.Reps.Interfaces;
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
        var data = await unitOfWork.RepProjects.Get().ToListAsync();
        return new Result<IList<Project>>(data);
    })
    .WithName("Projects");

app.MapGet("/tickets", async (IUnitOfWork unitOfWork) =>
    {
        var data = await unitOfWork.RepTickets.Get().ToListAsync();
        return new Result<IList<Ticket>>(data);
    })
    .WithName("Tickets");

app.Run();
