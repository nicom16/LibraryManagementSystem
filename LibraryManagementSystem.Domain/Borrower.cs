using System.Collections.ObjectModel;
using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class Borrower : BaseEntity
{
    public IList<Borrow> ActiveBorrows { get; protected set; }
    public BorrowerCategory Category { get; protected set; }
    public int ActiveBorrowsCount { get; protected set; }

    protected Borrower()
    {
        ActiveBorrows = new List<Borrow>();
    }
    
    public Borrow BorrowBook(BorrowableBook borrowableBook)
    {
        if (ActiveBorrowsCount >= Category.MaxBorrows)
            throw new InvalidOperationException("Cannot borrow more than max borrows!");
        
        Borrow borrow = new Borrow(borrower: this, borrowedBook: borrowableBook);
        borrowableBook.AddBorrow(borrow);
        ActiveBorrows.Add(borrow);
        
        return borrow;
    }
    
    public int CountActiveBorrows() => ActiveBorrows.Count;
    
    public ReadOnlyCollection<Borrow> GetActiveBorrows() => ActiveBorrows.AsReadOnly();
}