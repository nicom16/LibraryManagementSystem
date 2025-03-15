using LibraryManagementSystem.Domain;

namespace LibraryManagementSystem.DomainUt;

public class BorrowerTests
{
    private Borrower _borrower;
    private BorrowableBook _borrowableBook;
    private Borrow _borrow;

    [Test]
    public void OnValidRequest_CanBorrowBook()
    {
        _borrower = new Borrower(id: Guid.NewGuid(), borrowedBooks: new List<Guid>());
        _borrowableBook = new BorrowableBook(activeBorrows: new List<Borrow>());
        
        int countActiveBorrowsBeforeBorrow = _borrowableBook.CountActiveBorrows();
        _borrow = _borrower.BorrowBook(_borrowableBook);
        
        Assert.True(_borrow is not null);
        Assert.True(_borrowableBook.CountActiveBorrows() == countActiveBorrowsBeforeBorrow + 1);
    }
}