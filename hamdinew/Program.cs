using System;
using System.Collections.Generic;

// واجهة IManageable تحتوي على العمليات الأساسية للإدارة (إضافة، تحديث، حذف).
public interface IManageable
{
    void Add(Dictionary<string, object> parameters);
    void Update(Dictionary<string, object> parameters);
    void Delete(Dictionary<string, object> parameters);
}

// الفئة Library هي مكتبة تنفذ واجهة IManageable وتدير الكتب، المستخدمين، والإعارات.
public class Library : IManageable
{
    private List<Book> books;
    private List<User> users;
    private List<Loan> loans;

    public Library()
    {
        books = new List<Book>();
        users = new List<User>();
        loans = new List<Loan>();
    }

    // تنفيذ عملية الإضافة.
    public void Add(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Select an item to add:");
        Console.WriteLine("1. Book");
        Console.WriteLine("2. User");
        Console.WriteLine("3. Loan");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddBook(parameters);
                break;
            case 2:
                AddUser(parameters);
                break;
            case 3:
                AddLoan(parameters);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // تنفيذ عملية إضافة كتاب.
    private void AddBook(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Enter book ID:");
        int id = GetValidIntegerInput();

        Console.WriteLine("Enter book name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter book author:");
        string author = Console.ReadLine();

        Book book = new Book(id, name, author);
        books.Add(book);
        Console.WriteLine("Book added successfully.");
    }

    // تنفيذ عملية إضافة مستخدم.
    private void AddUser(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Enter user ID:");
        int id = GetValidIntegerInput();

        Console.WriteLine("Enter user name:");
        string name = Console.ReadLine();

        User user = new User(id, name);
        users.Add(user);
        Console.WriteLine("User added successfully.");
    }

    // تنفيذ عملية إضافة إعارة.
    private void AddLoan(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Enter loan ID:");
        int id = GetValidIntegerInput();

        Console.WriteLine("Enter book ID to loan:");
        int bookId = GetValidIntegerInput();

        Console.WriteLine("Enter user ID for the borrower:");
        int userId = GetValidIntegerInput();

        Book book = books.Find(b => b.Id == bookId);
        User user = users.Find(u => u.Id == userId);

        if (book != null && user != null)
        {
            Loan loan = new Loan(id, book, user);
            loans.Add(loan);
            Console.WriteLine("Loan added successfully.");
        }
        else
        {
            Console.WriteLine("Book or user not found.");
        }
    }

    // تنفيذ عملية التحديث.
    public void Update(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Select an item to update:");
        Console.WriteLine("1. Book");
        Console.WriteLine("2. User");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                UpdateBook(parameters);
                break;
            case 2:
                UpdateUser(parameters);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // تنفيذ عملية تحديث الكتاب.
    private void UpdateBook(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Enter book ID to update:");
        int id = GetValidIntegerInput();

        Book book = books.Find(b => b.Id == id);
        if (book != null)
        {
            Console.WriteLine("Enter new book name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter new book author:");
            string author = Console.ReadLine();

            book.Name = name;
            book.Author = author;

            Console.WriteLine("Book updated successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // تنفيذ عملية تحديث المستخدم.
    private void UpdateUser(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Enter user ID to update:");
        int id = GetValidIntegerInput();

        User user = users.Find(u => u.Id == id);
        if (user != null)
        {
            Console.WriteLine("Enter new user name:");
            string name = Console.ReadLine();

            user.Name = name;

            Console.WriteLine("User updated successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    // تنفيذ عملية الحذف.
    public void Delete(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Select an item to delete:");
        Console.WriteLine("1. Book");
        Console.WriteLine("2. User");
        Console.WriteLine("3. Loan");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                DeleteBook(parameters);
                break;
            case 2:
                DeleteUser(parameters);
                break;
            case 3:
                DeleteLoan(parameters);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // تنفيذ عملية حذف الكتاب.
    private void DeleteBook(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Enter book ID to delete:");
        int id = GetValidIntegerInput();

        Book book = books.Find(b => b.Id == id);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine("Book deleted successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // تنفيذ عملية حذف المستخدم.
    private void DeleteUser(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Enter user ID to delete:");
        int id = GetValidIntegerInput();

        User user = users.Find(u => u.Id == id);
        if (user != null)
        {
            users.Remove(user);
            Console.WriteLine("User deleted successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    // تنفيذ عملية حذف الإعارة.
    private void DeleteLoan(Dictionary<string, object> parameters)
    {
        Console.WriteLine("Enter loan ID to delete:");
        int id = GetValidIntegerInput();

        Loan loan = loans.Find(l => l.Id == id);
        if (loan != null)
        {
            loans.Remove(loan);
            Console.WriteLine("Loan deleted successfully.");
        }
        else
        {
            Console.WriteLine("Loan not found.");
        }
    }

    // عرض الكتب المتاحة.
    public void DisplayBooks()
    {
        Console.WriteLine("Books:");
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
        }
        else
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Author: {book.Author}");
            }
        }
    }

    // عرض المستخدمين المتاحين.
    public void DisplayUsers()
    {
        Console.WriteLine("Users:");
        if (users.Count == 0)
        {
            Console.WriteLine("No users available.");
        }
        else
        {
            foreach (User user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}");
            }
        }
    }

    // عرض الإعارات المتاحة.
    public void DisplayLoans()
    {
        Console.WriteLine("Loans:");
        if (loans.Count == 0)
        {
            Console.WriteLine("No loans available.");
        }
        else
        {
            foreach (Loan loan in loans)
            {
                Console.WriteLine($"ID: {loan.Id}, Book: {loan.Book.Name}, User: {loan.User.Name}");
            }
        }
    }

    // دالة للحصول على إدخال صحيح من المستخدم.
    private int GetValidIntegerInput()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer:");
        }
        return number;
    }
}

// الفئة Book تمثل الكتب.
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }

    public Book(int id, string name, string author)
    {
        Id = id;
        Name = name;
        Author = author;
    }
}

// الفئة User تمثل المستخدمين.
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

// الفئة Loan تمثل الإعارات.
public class Loan
{
    public int Id { get; set; }
    public Book Book { get; set; }
    public User User { get; set; }

    public Loan(int id, Book book, User user)
    {
        Id = id;
        Book = book;
        User = user;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Display Books");
            Console.WriteLine("5. Display Users");
            Console.WriteLine("6. Display Loans");
            Console.WriteLine("7. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    library.Add(null);
                    break;
                case 2:
                    library.Update(null);
                    break;
                case 3:
                    library.Delete(null);
                    break;
                case 4:
                    library.DisplayBooks();
                    break;
                case 5:
                    library.DisplayUsers();
                    break;
                case 6:
                    library.DisplayLoans();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
