namespace LibraryManagementSystem.Domain;

public struct BorrowerCategory
{
    public BorrowerCategoryType Type { get; set; }
    public int MaxBorrows { get; set; }
    public int DaysPerBorrow { get; set; }
}