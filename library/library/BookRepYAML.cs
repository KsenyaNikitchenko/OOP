using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace library
{
    class BookRepYAML
    {
        private string filePath;
        private List<Book> books;

        public BookRepYAML(string filePath)
        {
            this.filePath = filePath;
            books= ReadAll(filePath);
        }
        public static List<Book> ReadAll(string filePath) {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Данный файл не найден.");

            var deserializer = new DeserializerBuilder().Build();

            string yaml = File.ReadAllText(filePath);
            return deserializer.Deserialize<List<Book>>(yaml);
        }
        // Запись всех значений в файл
        public void WriteAll(string path)
        {
            var serializer = new SerializerBuilder().Build();

            string yaml = serializer.Serialize(books);
            File.WriteAllText(path, yaml);
        }
        //Получение объекта по ID
        public Book? GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.IdBook == id);
        }
        // Получить список k по счету n объектов класса short
        public List<Book> GetKNShortList(int k, int n)
        {
            return books.Skip(k).Take(n).ToList();
        }
        // Сортировать элементы по выбранному полю
        public List<Book> SortByYearOfPublication()
        {
            return books.OrderBy(b => b.YearOfPublication).ToList();
        }
        // Добавить объект в список (сформировать новый ID)
        public void Add(Book book)
        {
            int id = books.Count > 0 ? books.Max(b => b.IdBook) + 1 : 1;
            book.IdBook = id;
            books.Add(book);
        }
        // Заменить элемент списка по ID
        public void Replace(int id, Book book)
        {
            Book? bookFromList = books.FirstOrDefault(b => b.IdBook == id);
            if (bookFromList != null)
            {
                bookFromList.Author = book.Author;
                bookFromList.Title = book.Title;
                bookFromList.Genre = book.Genre;
                bookFromList.PublishingHouse = book.PublishingHouse;
                bookFromList.Isbn = book.Isbn;
                bookFromList.YearOfPublication = book.YearOfPublication;
                bookFromList.CollateralValue = book.CollateralValue;
                bookFromList.RentalCoast = book.RentalCoast;
            }
        }
        // Удалить элемент списка по ID
        public void Remove(int id)
        {
            Book? bookFromList = books.FirstOrDefault(b => b.IdBook == id);
            if (bookFromList != null)
            {
                books.Remove(bookFromList);
            }
        }
        // Получить количество элементов
        public int GetCount() { return books.Count; }
    }
}
