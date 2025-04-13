using System.Collections.ObjectModel;
using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class Borrower : BaseEntity
{
    private List<Borrow> _newBorrows;
    private BorrowerCategory _borrowerCategory;
    private readonly int _activeBorrowsCount;

    public Borrower(Guid id, BorrowerCategory borrowerCategory, int activeBorrowsCount)
    {
        Id = id;
        _newBorrows = new List<Borrow>();
        _borrowerCategory = borrowerCategory;
        _activeBorrowsCount = activeBorrowsCount;
    }

    public Borrow BorrowBook(BorrowableBook borrowableBook)
    {
        if (_activeBorrowsCount >= _borrowerCategory.MaxBorrows)
            throw new InvalidOperationException("Cannot borrow more than max borrows!");
        
        Borrow borrow = new Borrow(borrowerId: Id, borrowedBookId: borrowableBook.Id);
        borrowableBook.AddBorrow(borrow);
        _newBorrows.Add(borrow);
        return borrow;
    }
    
    public int CountActiveBorrows() => _newBorrows.Count + _activeBorrowsCount;
    
    public ReadOnlyCollection<Borrow> GetActiveBorrows() => _newBorrows.AsReadOnly();
}