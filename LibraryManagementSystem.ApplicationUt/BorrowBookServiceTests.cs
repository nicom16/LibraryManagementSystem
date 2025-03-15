using LibraryManagementSystem.Application;

namespace LibraryManagementSystem.ApplicationUt;

public class BorrowBookServiceTests
{
    private BorrowBookService _service;
    
    [SetUp]
    public void Setup()
    {
        _service = new BorrowBookService();
    }

    [Test]
    public void OnValidBorrower_CanBorrowBook()
    {
        
        
        Assert.Pass();
    }
}