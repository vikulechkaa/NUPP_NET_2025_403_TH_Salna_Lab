namespace Library.Common.Models
{
    public class Book : LibraryItem
    {
        public string Author { get; set; } = "";
        public int Pages { get; set; }

        // конструктор
        public Book() { }

        // конструктор
        public Book(string title, int year, string author, int pages) : base(title, year)
        {
            Author = author;
            Pages = pages;
        }

        // метод
        public override string GetInfo() => $"Book: {Title} by {Author}, {Year}, {Pages} pages";
    }
}
