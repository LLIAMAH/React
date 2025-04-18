﻿using React.DB.Entities;

namespace React.DB.Reps.Interfaces;

public interface IRepProjects : IRep<Project>;
public interface IRepTickets: IRep<Ticket>;
public interface IRepStatuses: IRep<Status>;
public interface IRepTags: IRep<Tag>;