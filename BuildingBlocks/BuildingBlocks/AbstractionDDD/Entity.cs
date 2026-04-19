namespace BuildingBlocks.AbstractionDDD;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; }
}

public abstract class AuditableEntity<T>: Entity<T>
{
    public DateTime? CreateTime { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}



