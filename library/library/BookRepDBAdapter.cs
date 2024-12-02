using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class BookRepDBAdapter:IBookRepository
    {
        private BookRepDB repDB;
        public BookRepDBAdapter(string connection)
        {
            repDB = new BookRepDB(connection);
        }
        public Book? GetBookById(int id)
        {
            return repDB.GetBookById(id);
        }
        public List<Book> GetKNShortList(int k, int n)
        {
            return repDB.GetKNShortList(k, n);
        }
        public void Add(Book book)
        {
            repDB.Add(book);
        }
        public void Replace(int id, Book book)
        {
            repDB.Replace(id, book);
        }
        public void Delete(int id)
        {
            repDB.Delete(id);
        }
        public int GetCount()
        {
            return repDB.GetCount();
        }
    }
}
