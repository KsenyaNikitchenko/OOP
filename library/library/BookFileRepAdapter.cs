namespace library
{
    class BookFileRepAdapter:IBookRepository
    {
        private BookFileRepository fileRep;
        public BookFileRepAdapter(string filePath, IFileStrategy strategy)
        {
            fileRep=new BookFileRepository(filePath,strategy);
        }
        public Book? GetBookById(int id)
        {
            return fileRep.GetBookById(id);
        }
        public List<Book> GetKNShortList(int k, int n)
        {
            return fileRep.GetKNShortList(k, n);
        }
        public void Add(Book book) { 
            fileRep.Add(book);
            fileRep.WriteAll();
        }
        public void Replace(int id, Book book) { 
            fileRep.Replace(id, book);
            fileRep.WriteAll();
        }
        public void Delete(int id)
        {
            fileRep.Delete(id);
            fileRep.WriteAll();
        }
        public int GetCount()
        {
            return fileRep.GetCount();
        }
    }
}
