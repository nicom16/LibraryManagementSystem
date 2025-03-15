using System.Collections.ObjectModel;
using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class BorrowableBook : BaseEntity
{
    private List<Borrow> _activeBorrows;

    public BorrowableBook()
    {
        Id = Guid.NewGuid();
        _activeBorrows = new List<Borrow>();
    }

    public void AddBorrow(Borrow borrow)
    {
        _activeBorrows.Add(borrow);
    }

    public int CountActiveBorrows() => _activeBorrows.Count;
    
    public ReadOnlyCollection<Borrow> GetActiveBorrows() => _activeBorrows.AsReadOnly();
}