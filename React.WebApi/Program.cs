using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using React.DB;
using React.DB.Reps;
using React.DB.Reps.Interfaces;
using React.Dto;
using React.MongoDB.Models;
using React.MongoDB.Services;
using React.WebApi.Configs;
using Scalar.AspNetCore;
using Tag = React.MongoDB.Models.Tag;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var corsConfig = builder.Configuration.GetSection("Cors").Get<Cors>()
                 ?? throw new InvalidOperationException("Cors config not found.");

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<MongoDbService>();

// Add services to the container.
builder.Services.AddDbContext<AppDbCtx>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy(corsConfig.Name, options =>
    {
        options.WithOrigins(corsConfig.Allowed.Origins)
            .WithHeaders(corsConfig.Allowed.Headers)
            .WithMethods(corsConfig.Allowed.Methods);
    });
});

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

app.UseCors(corsConfig.Name);

app.UseHttpsRedirection();

app.MapGet("/projects", async (MongoDbService service) =>
{
    var data = await service.Projects.Find(_ => true).ToListAsync();
    return data;
}).WithName("GetProjects");
app.MapPost("/projects", async (MongoDbService service, [FromBody] Project dto) =>
{
    var tickets = Enumerable.Empty<Ticket>().ToList();
    if (dto.Tickets.Any())
    {
        tickets = dto.Tickets.Select(t => new Ticket()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Title = t.Title,
            Description = t.Description,
            Status = t.Status
        }).ToList();
        
        try
        {
            await service.Tickets.InsertManyAsync(tickets);
        }
        catch { }
    }
    
    var project = new Project()
    {
        Id = ObjectId.GenerateNewId().ToString(),
        Name = dto.Name,
        Tickets = tickets
    };
    await service.Projects.InsertOneAsync(project);
    return Results.Created($"/projects/{project.Id}", project);
    
}).WithName("CreateProjects");



app.MapGet("/tags", async (MongoDbService service) =>
    {
        var data = await service.Tags.Find(_ => true).ToListAsync();
        return data;
    })
    .WithName("Tags");

app.MapGet("/tickets", async (MongoDbService service) =>
    {
        var data = await service.Tickets.Find(_ => true).ToListAsync();
        return data;
    })
    .WithName("Tickets");

app.MapGet("/statuses", async (MongoDbService service) =>
    {
        var data = await service.Statuses.Find(_ => true).ToListAsync();
        return data;
    })
    .WithName("Statuses");

/*app.MapGet("/projects", async (IUnitOfWork unitOfWork) =>
    {
        var data = await unitOfWork.RepProjects.Get(includes:"Tags,Tickets,Tickets.Status", asNoTracking:true)
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

app.MapGet("/tags", async (IUnitOfWork unitOfWork) =>
    {
        var data = await unitOfWork.RepTags.Get(asNoTracking:true)
            .Select(o => new TagDto()
            {
                Id = o.Id,
                Name = o.Name
            })
            .ToListAsync();
        return new Result<IList<TagDto>>(data);
    })
    .WithName("Tags");

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
    .WithName("Statuses"); */

app.Run();
