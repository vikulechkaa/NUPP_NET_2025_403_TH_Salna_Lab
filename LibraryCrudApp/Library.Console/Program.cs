using Library.Common.Extensions;
using Library.Common.Models;
using Library.Common.Services;

Console.WriteLine("=== LAB 1: Library CRUD Demo ===");

// CRUD для книжок
var bookService = new InMemoryCrudService<Book>();

// створюємо читача (показ статичного лічильника)
var member = new Member("Ivan Petrenko", 20);
Console.WriteLine($"Members total: {Member.TotalMembers}");

// підписка на подію (делегати/події)
member.Borrowed += (m, item) =>
{
    Console.WriteLine($"[EVENT] {m.FullName} borrowed -> {item.GetInfo()}");
};

// CREATE
var b1 = new Book("Clean Code", 2008, "Robert C. Martin", 464);
var b2 = new Book("The Pragmatic Programmer", 1999, "Andrew Hunt", 352);

bookService.Create(b1);
bookService.Create(b2);

Console.WriteLine("\nCreated books:");
foreach (var b in bookService.ReadAll())
{
    Console.WriteLine($"- {b.GetInfo()} | Old<2000: {b.IsOld(2000)}"); // метод розширення
}

// READ
var loaded = bookService.Read(b1.Id);
Console.WriteLine($"\nRead by id: {loaded.GetInfo()}");

// UPDATE
b2.Pages = 400;
bookService.Update(b2);
Console.WriteLine("\nAfter update:");
foreach (var b in bookService.ReadAll())
{
    Console.WriteLine($"- {b.GetInfo()}");
}

// EVENT demo
member.Borrow(b1);

// REMOVE (по ТЗ Remove(T element))
bookService.Remove(b1);
Console.WriteLine("\nAfter remove:");
foreach (var b in bookService.ReadAll())
{
    Console.WriteLine($"- {b.GetInfo()}");
}

// Save/Load (додаткове)
var path = "books.json";
bookService.Save(path);
Console.WriteLine($"\nSaved to: {path}");

var newService = new InMemoryCrudService<Book>();
newService.Load(path);
Console.WriteLine("Loaded from file:");
foreach (var b in newService.ReadAll())
{
    Console.WriteLine($"- {b.GetInfo()}");
}

Console.WriteLine("\n=== END ===");
