using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class Borrow : BaseEntity
{
    public Borrower Borrower { get; protected set; }
    public BorrowableBook BorrowedBook { get; protected set; }
    public DateTime StartDate { get; protected set; }
    
    protected Borrow() { }
    
    public Borrow(Borrower borrower, BorrowableBook borrowedBook)
    {
        Guid = Guid.NewGuid();
        Borrower = borrower;
        BorrowedBook = borrowedBook;
        StartDate = DateTime.Now;
    }
}