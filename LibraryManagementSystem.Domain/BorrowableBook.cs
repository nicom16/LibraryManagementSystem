using LibraryManagementSystem.Domain.Entity;

namespace LibraryManagementSystem.Domain;

public class BorrowableBook : BaseEntity
{
    private List<Borrow> _activeBorrows;

    public BorrowableBook(List<Borrow> activeBorrows)
    {
        _activeBorrows = activeBorrows;
    }

    public void AddBorrow(Borrow borrow)
    {
        _activeBorrows.Add(borrow);
    }

    public int CountActiveBorrows()
    {
        return _activeBorrows.Count;
    }
}