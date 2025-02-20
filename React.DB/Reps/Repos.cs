using React.DB.Entities;
using React.DB.Reps.Interfaces;

namespace React.DB.Reps;

public class RepProjects(AppDbCtx ctx) : Rep<Project>(ctx), IRepProjects;
public class RepTickets(AppDbCtx ctx) : Rep<Ticket>(ctx), IRepTickets;
public class RepStatuses(AppDbCtx ctx) : Rep<Status>(ctx), IRepStatuses;
public class RepTags(AppDbCtx  ctx) : Rep<Tag>(ctx), IRepTags;