namespace Ecosia.SearchEngine.Domain.Common;

public class AuditableEntity : IEntity
{
    public Guid Id { get; set; }
    
    public string? CreatedBy { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public string LastModifiedBy { get; set; } = string.Empty;
    
    public DateTime? LastModifiedDate { get; set; }
}