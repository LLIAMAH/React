using System.ComponentModel.DataAnnotations;

namespace React.DB.Entities;

public class Project
{
    [Key]
    public long Id { get; set; }
    [Required, MaxLength(512)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(2048)]
    public string? Description { get; set; } = null;
    
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public virtual ICollection<Ticket> Tickets { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}