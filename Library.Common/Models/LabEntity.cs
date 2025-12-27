namespace Library.Common.Models
{
    public class LabEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Можете додати свої поля, якщо треба
        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Desc: {Description}";
        }
    }
}