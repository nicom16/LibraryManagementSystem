using LibraryManagementSystem.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace LibraryManagementSystem.Persistence;

public class MapBorrow : ClassMapping<Borrow>
{
    public MapBorrow()
    {
        Id(x => x.Id, m => m.Generator(Generators.Native));
        Property(x => x.Guid, map => map.NotNullable(true));
        Property(x => x.StartDate, map => map.NotNullable(true));
        ManyToOne<Borrower>(x => x.Borrower, map => map.Column("BorrowerGuid"));
        ManyToOne<BorrowableBook>(x => x.BorrowedBook, map => map.Column("BookGuid"));
    }
}