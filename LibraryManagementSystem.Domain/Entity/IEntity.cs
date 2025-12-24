namespace LibraryManagementSystem.Domain.Entity;

public interface IEntity
{
    int? Id { get; set; }
    Guid Guid { get; set; }
}