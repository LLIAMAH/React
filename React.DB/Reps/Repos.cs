using React.DB.Entities;
using React.DB.Reps.Interfaces;

namespace React.DB.Reps;

public class RepProjects(AppDbCtx ctx) : Rep<Project>(ctx), IRepProjects;
public class RepTickets(AppDbCtx ctx) : Rep<Ticket>(ctx), IRepTickets;