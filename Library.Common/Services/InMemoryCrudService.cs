using System.Text.Json;

namespace Library.Common.Services
{
    public class InMemoryCrudService<T> : ICrudService<T> where T : class
    {
        private readonly Dictionary<Guid, T> _storage = new();

        private static Guid GetId(T element)
        {
            var idProp = element.GetType().GetProperty("Id");
            if (idProp == null || idProp.PropertyType != typeof(Guid))
                throw new Exception("Element must have Guid Id property");

            return (Guid)(idProp.GetValue(element) ?? Guid.Empty);
        }

        public void Create(T element)
        {
            var id = GetId(element);
            _storage[id] = element;
        }

        public T Read(Guid id) => _storage[id];

        public IEnumerable<T> ReadAll() => _storage.Values;

        public void Update(T element)
        {
            var id = GetId(element);
            _storage[id] = element;
        }

        public void Remove(T element)
        {
            var id = GetId(element);
            _storage.Remove(id);
        }

        // додаткове завдання: Save/Load через JSON
        public void Save(string filePath)
        {
            var list = _storage.Values.ToList();
            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void Load(string filePath)
        {
            if (!File.Exists(filePath)) return;

            var json = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();

            _storage.Clear();
            foreach (var el in list)
            {
                var id = GetId(el);
                _storage[id] = el;
            }
        }
    }
}
