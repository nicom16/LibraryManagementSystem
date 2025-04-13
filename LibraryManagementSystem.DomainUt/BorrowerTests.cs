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
        int borrowerActiveBorrows = 3;
        _borrower = new Borrower(id: Guid.NewGuid(), borrowerCategory, borrowerActiveBorrows);
        
        int bookActiveBorrows = 1;
        _borrowableBook = new BorrowableBook(id: Guid.NewGuid(), bookActiveBorrows);
        
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