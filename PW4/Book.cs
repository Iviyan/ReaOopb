namespace ConsoleApp1PW4;

public class Book
{
    private string _title = null!;
    private string[] _authors = null!;
    private uint _year;
    private string _publisher = null!;
    private uint _pageCount;

    public Book(string title, string[] authors, uint year, string publisher, uint pageCount)
    {
        Title = title;
        Authors = authors;
        Year = year;
        Publisher = publisher;
        PageCount = pageCount;
    }

    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Title cannot be null or empty.");
            _title = value;
        }
    }

    public string[] Authors
    {
        get => _authors;
        set
        {
            if (value == null || value.Length == 0)
                throw new ArgumentException("Authors cannot be null or empty.");
            _authors = value;
        }
    }

    public uint Year
    {
        get => _year;
        set => _year = value;
    }

    public string Publisher
    {
        get => _publisher;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Publisher cannot be null or empty.");
            _publisher = value;
        }
    }

    public uint PageCount
    {
        get => _pageCount;
        set
        {
            if (value <= 0)
                throw new ArgumentException("PageCount must be a positive number.");
            _pageCount = value;
        }
    }
}