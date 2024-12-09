namespace library
{
    class BookFileRepository
    {
        private string filePath;
        private List<Book> booksList;
        private IFileStrategy strategy;

        public BookFileRepository(string filePath, IFileStrategy strategy)
        {
            this.filePath = filePath;
            this.strategy = strategy;
            booksList = ReadAll();
        }
        public List<Book> ReadAll()
        {
            return strategy.ReadAll(filePath);
        }
        public void WriteAll(string? path = null)
        {
            string finalFilePath = path ?? filePath;
            strategy.WriteAll(finalFilePath, booksList);
        }
        //Получение объекта по ID
        public Book? GetBookById(int id)
        {
            return booksList.FirstOrDefault(b => b.IdBook == id);
        }
        // Получить список k по счету n объектов класса short
        public List<Book> GetKNShortList(int k, int n)
        {
            return booksList.Skip((k - 1) * n).Take(n).ToList();
        }
        // Сортировать элементы по выбранному полю
        public List<Book> SortByYearOfPublication()
        {
            return booksList.OrderBy(b => b.YearOfPublication).ToList();
        }
        // Добавить объект в список (сформировать новый ID)
        public void Add(Book book)
        {
            if (IsQnique(book))
            {
                int id = booksList.Count > 0 ? booksList.Max(b => b.IdBook) + 1 : 1;
                book.IdBook = id;
                booksList.Add(book);
            }
            else
                throw new Exception($"Книга с ISBN {book.Isbn} уже существует.");

        }
        // Заменить элемент списка по ID
        public void Replace(int id, Book book)
        {
            Book? bookFromList = booksList.FirstOrDefault(b => b.IdBook == id);
            if (bookFromList != null)
            {
                if (IsQnique(book))
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
                throw new Exception($"Книга с ISBN {book.Isbn} уже существует.");
            }
            else
                throw new Exception($"Книга с idBook {id} не существует.");
        }
        // Удалить элемент списка по ID
        public void Delete(int id)
        {
            Book? bookFromList = booksList.FirstOrDefault(b => b.IdBook == id);
            if (bookFromList != null)
            {
                booksList.Remove(bookFromList);
            }
        }
        // Получить количество элементов
        public int GetCount() { return booksList.Count; }

        private bool IsQnique(Book book)
        {
            return !booksList.Any(b => book.Equals(b));
        }
    }
}
