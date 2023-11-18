using System;
using System.Collections.Generic;

// واجهة IManageable تعرف العمليات الأساسية التي يجب تنفيذها لإدارة العناصر في المكتبة.
public interface IManageable
{
    void Add(Dictionary<string, object> parameters);
    void Update(Dictionary<string, object> parameters);
    void Delete(Dictionary<string, object> parameters);
}

// كلاس Library يمثل المكتبة وينفذ واجهة IManageable.
public class Library : IManageable
{
    private List<Book> books;   // قائمة الكتب في المكتبة
    private List<User> users;   // قائمة المستخدمين في المكتبة
    private List<Loan> loans;   // قائمة الإعارات في المكتبة

    public Library()
    {
        // تهيئة القوائم عند إنشاء كائن Library.
        books = new List<Book>();
        users = new List<User>();
        loans = new List<Loan>();
    }

    // دالة Add تسمح بإضافة كتاب أو مستخدم أو إعارة إلى المكتبة.
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
                AddBook(parameters);   // إضافة كتاب
                break;
            case 2:
                AddUser(parameters);   // إضافة مستخدم
                break;
            case 3:
                AddLoan(parameters);   // إضافة إعارة
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // دالة AddBook تقوم بإضافة كتاب جديد إلى المكتبة.
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

    // دالة AddUser تقوم بإضافة مستخدم جديد إلى المكتبة.
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

    // دالة AddLoan تقوم بإضافة إعارة جديدة إلى المكتبة.
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

    // ... (الدوال الأخرى تمتلك تعليقات مماثلة لشرحها)

    // دالة GetValidIntegerInput تقوم بالحصول على إدخال صحيح من المستخدم.
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

// ... (كلاسات الكتب والمستخدمين والإعارات تمتلك تعليقات مماثلة لشرحها)

// كلاس Program يحتوي على دالة Main والتي تبدأ تنفيذ البرنامج الرئيسي.
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
