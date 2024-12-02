using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    abstract class BookFileRepository: IBookRepository
    {
        protected string filePath;
        protected List<Book> booksList;

        public BookFileRepository(string filePath)
        {
            this.filePath = filePath;
            booksList = ReadAll();
        }
        public abstract List<Book> ReadAll();
        public abstract void WriteAll(string path);
        //Получение объекта по ID
        public Book? GetBookById(int id)
        {
            return booksList.FirstOrDefault(b => b.IdBook == id);
        }
        // Получить список k по счету n объектов класса short
        public List<Book> GetKNShortList(int k, int n)
        {
            return booksList.Skip(k).Take(n).ToList();
        }
        // Сортировать элементы по выбранному полю
        public List<Book> SortByYearOfPublication()
        {
            return booksList.OrderBy(b => b.YearOfPublication).ToList();
        }
        // Добавить объект в список (сформировать новый ID)
        public void Add(Book book)
        {
            int id = booksList.Count > 0 ? booksList.Max(b => b.IdBook) + 1 : 1;
            book.IdBook = id;
            booksList.Add(book);
        }
        // Заменить элемент списка по ID
        public void Replace(int id, Book book)
        {
            Book? bookFromList = booksList.FirstOrDefault(b => b.IdBook == id);
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
    }
}
