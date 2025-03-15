using System.Collections.ObjectModel;
using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class Borrower : BaseEntity
{
    private List<Borrow> _activeBorrows;
    
    public Borrower()
    {
        Id = Guid.NewGuid();
        _activeBorrows = new List<Borrow>();
    }

    public Borrow BorrowBook(BorrowableBook borrowableBook)
    {
        Borrow borrow = new Borrow(borrowerId: Id, borrowedBookId: borrowableBook.Id);
        borrowableBook.AddBorrow(borrow);
        _activeBorrows.Add(borrow);
        return borrow;
    }
    
    public int CountActiveBorrows() => _activeBorrows.Count;
    
    public ReadOnlyCollection<Borrow> GetActiveBorrows() => _activeBorrows.AsReadOnly();
}