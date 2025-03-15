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
        // SetUp
        BorrowerCategory borrowerCategory = new BorrowerCategory()
        {
            Type = BorrowerCategoryType.Guest,
            DaysPerBorrow = 10,
            MaxBorrows = 5
        };
        _borrower = new Borrower(borrowerCategory);
        _borrowableBook = new BorrowableBook();
        
        int bookActiveBorrows = _borrowableBook.CountActiveBorrows();
        int borrowerActiveBorrows = _borrower.CountActiveBorrows();
        
        // Act
        _borrow = _borrower.BorrowBook(_borrowableBook);
        
        // Assert
        Assert.True(_borrow is not null);
        
        Assert.True(_borrowableBook.CountActiveBorrows() == bookActiveBorrows + 1);
        Assert.True(_borrowableBook.GetActiveBorrows().Contains(_borrow));
        
        Assert.True(_borrower.CountActiveBorrows() == borrowerActiveBorrows + 1);
        Assert.True(_borrower.GetActiveBorrows().Contains(_borrow));
    }
}