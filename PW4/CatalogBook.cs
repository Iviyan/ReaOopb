namespace ConsoleApp1PW4;

public class CatalogBook : Book
{
    public CatalogBook(string title, string[] authors, uint year, string publisher, uint pageCount,
        uint id, uint totalQuantity, uint availableInstances)
        : base(title, authors, year, publisher, pageCount)
    {
        Id = id;
        TotalQuantity = totalQuantity;
        AvailableInstances = availableInstances;
    }

    public uint Id { get; set; }

    public uint TotalQuantity { get; set; }

    public uint AvailableInstances { get; set; }

    public List<BorrowerInfo> Picked { get; } = new();
}

public record struct BorrowerInfo(string ReaderName, DateOnly BorrowDate, DateOnly? ReturnDate = null);