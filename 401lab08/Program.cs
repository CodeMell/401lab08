using System;
using System.Collections;


// Book class to hold properties of a book
public class Book
{
    public string Title { get; }
    public string Author { get; }
    public int NumberOfPages { get; }

    public Book(string title, string author, int numberOfPages)
    {
        Title = title;
        Author = author;
        NumberOfPages = numberOfPages;
    }
}

// Interface for the Library
public interface ILibrary : IReadOnlyCollection<Book>
{
    void Add(string title, string author, int numberOfPages);
    Book Borrow(string title);
    void Return(Book book);
}

// Library class that implements the ILibrary interface
public class Library : ILibrary
{
    private Dictionary<string, Book> books; 

    public Library()
    {
        books = new Dictionary<string, Book>();
    }

    public int Count => books.Count; // Count of books in the library

    public void Add(string title, string author, int numberOfPages)
    {
        Book book = new Book(title, author, numberOfPages);
        books[title] = book;
    }

    public Book Borrow(string title)
    {

        if (books.TryGetValue(title, out Book book))
        {
            books.Remove(title);
            return book;
        }
        return null;
    }

    public void Return(Book book)
    {
        if (book != null)
        {
            books[book.Title] = book;
        }
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return books.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Interface for the Backpack
public interface IBag<T> : IEnumerable<T>
{
    void Pack(T item);
    T Unpack(int index);
}

// Backpack class that implements the IBag<T> interface
public class Backpack<T> : IBag<T>
{
    private List<T> items;

    public Backpack()
    {
        items = new List<T>();
    }

    public void Pack(T item)
    {
        if (item != null)
        {
            items.Add(item);
        }
    }

    public T Unpack(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            T item = items[index];
            items.RemoveAt(index);
            return item;
        }
        return default(T);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new library and add some books
        ILibrary library = new Library();
        library.Add("Title 1", "Author 1", 200);
        library.Add("Title 2", "Author 2", 300);

        // Display books in the library
        Console.WriteLine("Books in the library:");
        foreach (Book book in library)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Pages: {book.NumberOfPages}");
        }

        // Borrow a book from the library
        Book borrowedBook = library.Borrow("Title 1");
        Console.WriteLine($"Borrowed Book: Title: {borrowedBook.Title}, Author: {borrowedBook.Author}, Pages: {borrowedBook.NumberOfPages}");

        // Display books in the library after borrowing
        Console.WriteLine("Books in the library after borrowing:");
        foreach (Book book in library)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Pages: {book.NumberOfPages}");
        }

        // Create a new backpack and pack the borrowed book
        IBag<Book> backpack = new Backpack<Book>();
        backpack.Pack(borrowedBook);

        // Display books in the backpack
        Console.WriteLine("Books in the backpack:");
        foreach (Book book in backpack)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Pages: {book.NumberOfPages}");
        }

        // Return the borrowed book to the library from the backpack
        Book returnedBook = backpack.Unpack(0);
        library.Return(returnedBook);

        // Display books in the library after returning
        Console.WriteLine("Books in the library after returning:");
        foreach (Book book in library)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Pages: {book.NumberOfPages}");
        }
    }
}
