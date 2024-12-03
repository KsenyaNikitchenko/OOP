using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    interface IFileStrategy
    {
        List<Book> ReadAll(string path);
        void WriteAll(string path, List<Book> booksList);
    }
}
