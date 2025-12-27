namespace Library.Common.Models
{
    public abstract class LibraryItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public int Year { get; set; }

        // конструктор
        protected LibraryItem() { }

        // конструктор
        protected LibraryItem(string title, int year)
        {
            Id = Guid.NewGuid();
            Title = title;
            Year = year;
        }

        // метод
        public virtual string GetInfo() => $"{Title} ({Year})";

        // статичний метод
        public static bool IsModern(int year) => year >= 2000;
    }
}
