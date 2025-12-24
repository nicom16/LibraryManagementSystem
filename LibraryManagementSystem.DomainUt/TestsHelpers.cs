using System.Reflection;
using LibraryManagementSystem.Domain;

namespace LibraryManagementSystem.DomainUt;

public class TestsHelpers
{
    public static Borrower CreateBorrowerByReflection(BorrowerCategory category, int activeBorrows)
    {
        Type type = typeof(Borrower);
        ConstructorInfo? constructor = 
            type.GetConstructor(bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic, types: []);
        if (constructor is null) 
            throw new InvalidOperationException("There is no parameterless Borrower constructor");
        
        Borrower borrower = (Borrower)constructor.Invoke(parameters: []);
        borrower.GetType().GetProperty(nameof(Borrower.Guid))?.SetValue(borrower, Guid.NewGuid(), null);
        borrower.GetType().GetProperty(nameof(Borrower.Category))?.SetValue(borrower, category, null);
        borrower.GetType().GetProperty(nameof(Borrower.ActiveBorrowsCount))?.SetValue(borrower, activeBorrows, null);
        
        return borrower;
    }
    
}