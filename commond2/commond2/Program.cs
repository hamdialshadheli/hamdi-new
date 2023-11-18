using System;
using System.Collections.Generic;

// تعريف واجهة IManageable التي تحتوي على الأساليب الأساسية لإدارة العناصر في المكتبة.
public interface IManageable
{
    void Add(Dictionary<string, object> parameters); // إضافة عنصر جديد
    void Update(Dictionary<string, object> parameters); // تحديث معلومات عنصر موجود
    void Delete(Dictionary<string, object> parameters); // حذف عنصر موجود
}

// تعريف الكلاس Library الذي يمثل المكتبة وينفذ واجهة IManageable.
public class Library : IManageable
{
    private List<Book> books; // قائمة تحتوي على الكتب
    private List<User> users; // قائمة تحتوي على المستخدمين
    private List<Loan> loans; // قائمة تحتوي على عمليات الإعارة

    // البناء الأساسي للكلاس Library يقوم بإعداد القوائم.
    public Library()
    {
        books = new List<Book>();
        users = new List<User>();
        loans = a List<Loan>();
    }

    // الدالة Add هي واحدة من أساليب IManageable وتُستخدم لإضافة عنصر جديد إلى المكتبة.
    public void Add(Dictionary<string, object> parameters)
    {
        Console.WriteLine("اختر عنصرًا لإضافته:");
        Console.WriteLine("1. كتاب");
        Console.WriteLine("2. مستخدم");
        Console.WriteLine("3. إعارة");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddBook(parameters); // إضافة كتاب جديد
                break;
            case 2:
                AddUser(parameters); // إضافة مستخدم جديد
                break;
            case 3:
                AddLoan(parameters); // إضافة عملية إعارة جديدة
                break;
            default:
                Console.WriteLine("اختيار غير صالح.");
                break;
        }
    }

    // الدالة AddBook تُستخدم لإضافة كتاب جديد إلى المكتبة.
    private void AddBook(Dictionary<string, object> parameters)
    {
        Console.WriteLine("أدخل معرف الكتاب:");
        int id = GetValidIntegerInput();

        Console.WriteLine("أدخل اسم الكتاب:");
        string name = Console.ReadLine();

        Console.WriteLine("أدخل اسم مؤلف الكتاب:");
        string author = Console.ReadLine();

        Book book = new Book(id, name, author);
        books.Add(book);
        Console.WriteLine("تمت إضافة الكتاب بنجاح.");
    }

    // (يتم استكمال الشرح للدوال الأخرى في الكود في الرسالة التالية)
}

// تعريف الكلاس Book الذي يمثل الكتب.
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }

    // البناء الأساسي للكلاس Book يستقبل معلومات الكتاب ويعينها إلى الخصائص.
    public Book(int id, string name, string author)
    {
        Id = id;
        Name = name;
        Author = author;
    }
}

// (تواصل الشرح مع الكلاسات والدوال الأخرى في الكود في الرسالة التالية)
// تعريف الكلاس User الذي يمثل المستخدمين.
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    // البناء الأساسي للكلاس User يستقبل معلومات المستخدم ويعينها إلى الخصائص.
    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

// تعريف الكلاس Loan الذي يمثل عمليات الإعارة.
public class Loan
{
    public int Id { get; set; }
    public Book Book { get; set; }
    public User User { get; set; }

    // البناء الأساسي للكلاس Loan يستقبل معلومات الإعارة ويعينها إلى الخصائص.
    public Loan(int id, Book book, User user)
    {
        Id = id;
        Book = book;
        User = user;
    }
}

// تعريف الكلاس Program الذي يحتوي على الدالة الرئيسية Main.
public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("حدد العملية:");
            Console.WriteLine("1. إضافة");
            Console.WriteLine("2. تحديث");
            Console.WriteLine("3. حذف");
            Console.WriteLine("4. عرض الكتب");
            Console.WriteLine("5. عرض المستخدمين");
            Console.WriteLine("6. عرض عمليات الإعارة");
            Console.WriteLine("7. الخروج");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    library.Add(null); // استدعاء دالة إضافة عنصر جديد
                    break;
                case 2:
                    library.Update(null); // استدعاء دالة تحديث معلومات عنصر موجود
                    break;
                case 3:
                    library.Delete(null); // استدعاء دالة حذف عنصر موجود
                    break;
                case 4:
                    library.DisplayBooks(); // استدعاء دالة عرض الكتب المتاحة
                    break;
                case 5:
                    library.DisplayUsers(); // استدعاء دالة عرض المستخدمين المتاحين
                    break;
                case 6:
                    library.DisplayLoans(); // استدعاء دالة عرض عمليات الإعارة المتاحة
                    break;
                case 7:
                    return; // الخروج من البرنامج
                default:
                    Console.WriteLine("اختيار غير صالح.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
using System;
using System.Collections.Generic;

// تعريف واجهة IManageable التي تحتوي على الأساليب الأساسية لإدارة العناصر في المكتبة.
public interface IManageable
{
    void Add(Dictionary<string, object> parameters); // إضافة عنصر جديد
    void Update(Dictionary<string, object> parameters); // تحديث معلومات عنصر موجود
    void Delete(Dictionary<string, object> parameters); // حذف عنصر موجود
}

// تعريف الكلاس Library الذي يمثل المكتبة وينفذ واجهة IManageable.
public class Library : IManageable
{
    private List<Book> books; // قائمة تحتوي على الكتب
    private List<User> users; // قائمة تحتوي على المستخدمين
    private List<Loan> loans; // قائمة تحتوي على عمليات الإعارة

    // البناء الأساسي للكلاس Library يقوم بإعداد القوائم.
    public Library()
    {
        books = new List<Book>();
        users = new List<User>();
        loans = new List<Loan>();
    }

    // الدالة Add هي واحدة من أساليب IManageable وتُستخدم لإضافة عنصر جديد إلى المكتبة.
    public void Add(Dictionary<string, object> parameters)
    {
        Console.WriteLine("اختر عنصرًا لإضافته:");
        Console.WriteLine("1. كتاب");
        Console.WriteLine("2. مستخدم");
        Console.WriteLine("3. إعارة");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddBook(parameters); // إضافة كتاب جديد
                break;
            case 2:
                AddUser(parameters); // إضافة مستخدم جديد
                break;
            case 3:
                AddLoan(parameters); // إضافة عملية إعارة جديدة
                break;
            default:
                Console.WriteLine("اختيار غير صالح.");
                break;
        }
    }

    // ...
    // (تواصل الشرح مع الجزء التالي من الكود في الإجابة القادمة)
}

// تعريف الكلاس Book الذي يمثل الكتب.
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }

    // البناء الأساسي للكلاس Book يستقبل معلومات الكتاب ويعينها إلى الخصائص.
    public Book(int id, string name, string author)
    {
        Id = id;
        Name = name;
        Author = author;
    }
}

// (سأكمل الشرح مع الجزء التالي من الكود في الإجابة القادمة)

