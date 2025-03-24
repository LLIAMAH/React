using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace React.DB.Entities;

public class Ticket
{
    [Key]
    public long Id { get; set; }
    [Required, MaxLength(512)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(3096)]
    public string? Description { get; set; } = null;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [ForeignKey(nameof(Project))]
    public long ProjectId { get; set; }
    public virtual Project Project { get; set; }
    
    [ForeignKey(nameof(Status))]
    public long StatusId { get; set; }
    public virtual Status Status { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}