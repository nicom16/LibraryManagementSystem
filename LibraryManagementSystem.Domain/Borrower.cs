using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class Borrower : BaseEntity
{
    private List<Guid> _borrowedBooks;

    public Borrower(Guid id, List<Guid> borrowedBooks)
    {
        Id = id;
        _borrowedBooks = borrowedBooks;
    }

    public Borrow BorrowBook(BorrowableBook borrowableBook)
    {
        Borrow borrow = new Borrow(this.Id, borrowableBook.Id, DateTime.Now);
        borrowableBook.AddBorrow(borrow);
        return borrow;
    }
}