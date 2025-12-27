// ДОДАЙТЕ ЦІ ДВА РЯДКИ ЗВЕРХУ:
using Library.Common.Models;
using Library.Common.Services;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // Тепер код знає, де шукати LabService
        var service = new LabService(); 

        Console.WriteLine("=== Lab 2: Async & Thread-Safe Storage ===");
        
        // ... (далі той самий код з попередньої відповіді для перевірки)
        
        // Приклад створення об'єкта (тепер LabEntity береться з папки Models)
        var entity = new LabEntity { Id = 1, Name = "Test", Description = "Desc" };
        await service.CreateAsync(entity);
        
        Console.WriteLine("Створено успішно.");
        Console.ReadLine();
    }
}