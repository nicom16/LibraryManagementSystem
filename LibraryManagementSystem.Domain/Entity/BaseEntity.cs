namespace LibraryManagementSystem.Domain.Entity;

public abstract class BaseEntity : IEntity
{
    public int? Id { get; set; }
    public Guid Guid { get; set; }
}