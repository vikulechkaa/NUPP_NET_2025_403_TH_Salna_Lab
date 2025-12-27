namespace Library.Common.Models
{
    // делегат
    public delegate void BorrowedEventHandler(Member member, LibraryItem item);

    public class Member
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = "";
        public int Age { get; set; }

        // статичне поле (лічильник створених читачів)
        public static int TotalMembers { get; private set; }

        // статичний конструктор
        static Member()
        {
            TotalMembers = 0;
        }

        // подія
        public event BorrowedEventHandler? Borrowed;

        // конструктор
        public Member()
        {
            Id = Guid.NewGuid();
            TotalMembers++;
        }

        // конструктор
        public Member(string fullName, int age) : this()
        {
            FullName = fullName;
            Age = age;
        }

        // метод (тут викликаємо подію)
        public void Borrow(LibraryItem item)
        {
            Borrowed?.Invoke(this, item);
        }
    }
}
