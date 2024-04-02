using ConsoleApp1PW4;
using static Utils.Utils;

const string commandsInfo = """
                            Команды:
                            f <text> - Find.
                            n - New book.
                            d <book id> - Delete book.
                            g <bool id> - Give the book to the reader.
                            r <bool id> - Return book.
                            h - Help.
                            q - Quit.
                            """;

Console.WriteLine("Библиотека");
Console.WriteLine(commandsInfo);

List<CatalogBook> books = new();

while (true)
{
    Console.Write("> ");
    string command = Console.ReadLine() ?? "";

    if (command is "h" or "help")
    {
        Console.WriteLine(commandsInfo);
    }
    else if (command.StartsWith("f "))
    {
        string query = command[2..];

        var result = books.Where(b => $"{b.Id} {b.Title} {string.Join(' ', b.Authors)}".Contains(query));

        foreach (var book in result)
        {
            Console.WriteLine($"Id: {book.Id}");
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Authors: {string.Join(", ", book.Authors)}");
            Console.WriteLine($"Year: {book.Year}");
            Console.WriteLine($"Publisher: {book.Publisher}");
            Console.WriteLine($"PageCount: {book.PageCount}");
            Console.WriteLine($"Total quantity: {book.TotalQuantity}");
            Console.WriteLine($"Available instances: {book.AvailableInstances}");
            Console.WriteLine($"Picked: ");
            foreach (var record in book.Picked)
            {
                Console.WriteLine($"- {record.ReaderName}: {record.BorrowDate} - " 
                                  + (record.ReturnDate != null ? record.ReturnDate : "..."));
            }
        }
    }
    else if (command is "n")
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter book info.");
                string title = ReadValue<string>("Enter book title: ");
                string[] authors = ReadValue<string>("Enter book authors (comma separated): ")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                uint year = ReadValue<uint>("Enter book year: ");
                string publisher = ReadValue<string>("Enter book publisher: ");
                uint pageCount = ReadValue<uint>("Enter book page count: ");
                Console.WriteLine("Enter catalog entity info.");
                uint totalQuantity = ReadValue<uint>("Enter total quantity of the book: ");
                uint availableInstances = totalQuantity;
                uint catalogId = books.LastOrDefault()?.Id + 1 ?? 1;

                CatalogBook newBook = new CatalogBook(title, authors, year, publisher, pageCount,
                    catalogId, totalQuantity, availableInstances);
                books.Add(newBook);

                Console.WriteLine($"New book id: {newBook.Id}.");
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid input. {e.Message}");
            }
        }
    }
    else if (command.StartsWith("d ") && uint.TryParse(command[2..], out var id))
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book is null)
        {
            Console.WriteLine($"Book with id {id} not found.");
        }
        else
        {
            books.Remove(book);
            Console.WriteLine($"Book with id {id} deleted.");
        }
    }
    else if (command.StartsWith("g ") && uint.TryParse(command[2..], out id))
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book is null)
        {
            Console.WriteLine($"Book with id {id} not found.");
        }
        else if (book.AvailableInstances == 0)
        {
            Console.WriteLine("There are no available copies of the book.");
        }
        else
        {
            string readerName = ReadValue<string>("Enter reader name: ");
            DateOnly borrowDate = ReadValue<DateOnly>("Enter borrow date: ");
            BorrowerInfo info = new(readerName, borrowDate);
            book.Picked.Add(info);
            book.AvailableInstances--;
            Console.WriteLine($"Book with id {id} borrowed. There are {book.AvailableInstances} copies left.");
        }
    }
    else if (command.StartsWith("r ") && uint.TryParse(command[2..], out id))
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book is null)
        {
            Console.WriteLine($"Book with id {id} not found.");
        }
        else if (book.AvailableInstances == book.TotalQuantity)
        {
            Console.WriteLine("Nobody borrowed this book.");
        }
        else
        {
            var records = book.Picked
                .Select((p, i) => (index: i, record: p))
                .Where(p => p.record.ReturnDate == null)
                .ToList();
            
            for (int i = 0; i < records.Count; i++)
            {
                var r = records[i];
                Console.WriteLine($"{i}) {r.record.BorrowDate:dd.MM.yyyy} - {r.record.ReaderName}");
            }

            int recordIndex = ReadValue<int>("Enter record number: ");
            DateOnly returnDate = DateOnly.FromDateTime(DateTime.Now);
            //DateOnly returnDate = ReadValue<DateOnly>("Enter return date: ");

            BorrowerInfo info = records[recordIndex].record with { ReturnDate = returnDate }; 
            book.Picked[records[recordIndex].index] = info;
            book.AvailableInstances++;
            Console.WriteLine($"Book with id {id} returned. There are {book.AvailableInstances} copies left");
        }
    }
    else if (command is "q" or "quit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Unknown command.");
    }

    Console.WriteLine();
}