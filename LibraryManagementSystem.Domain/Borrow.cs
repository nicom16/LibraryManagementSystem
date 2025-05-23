using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class Borrow : BaseEntity
{
    private Guid _borrowerId;
    private Guid _borrowedBookId;
    private DateTime _borrowDate;

    public Borrow(Guid borrowerId, Guid borrowedBookId)
    {
        Id = Guid.NewGuid();
        _borrowerId = borrowerId;
        _borrowedBookId = borrowedBookId;
        _borrowDate = DateTime.Now;
    }
}