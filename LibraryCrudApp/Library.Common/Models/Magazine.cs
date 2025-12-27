namespace Library.Common.Models
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }
        public string Publisher { get; set; } = "";

        // конструктор
        public Magazine() { }

        // конструктор
        public Magazine(string title, int year, int issueNumber, string publisher) : base(title, year)
        {
            IssueNumber = issueNumber;
            Publisher = publisher;
        }

        // метод
        public override string GetInfo() => $"Magazine: {Title} #{IssueNumber}, {Publisher}, {Year}";
    }
}
