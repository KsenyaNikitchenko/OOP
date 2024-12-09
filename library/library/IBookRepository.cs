using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    interface IBookRepository
    {
        Book? GetBookById(int id);
        List<Book> GetKNShortList(int k, int n);
        void Add(Book book);
        void Replace(int id,Book book);
        void Delete(int id);
        int GetCount();
    }
}
