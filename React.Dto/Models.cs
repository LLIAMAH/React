namespace React.Dto;

public class ProjectDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public IList<TicketDto> Tickets { get; set; } = [];
    public IList<TagDto> Tags { get; set; } = [];
}

public class TagDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class TicketDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public StatusDto Status { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}

public class StatusDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}