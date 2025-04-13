using System.Collections.ObjectModel;
using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class BorrowableBook : BaseEntity
{
    private readonly int _activeBorrowsCount;
    private readonly List<Borrow> _newBorrows;

    public BorrowableBook(Guid id, int activeBorrowsCount)
    {
        Id = id;
        _activeBorrowsCount = activeBorrowsCount;
        _newBorrows = new List<Borrow>();
    }

    public void AddBorrow(Borrow borrow)
    {
        _newBorrows.Add(borrow);
    }

    public int CountActiveBorrows() => _newBorrows.Count + _activeBorrowsCount;
    
    public ReadOnlyCollection<Borrow> GetActiveBorrows() => _newBorrows.AsReadOnly();
}