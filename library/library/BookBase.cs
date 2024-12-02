using System.Text.RegularExpressions;

namespace library
{
    class BookBase
    {
        private int idBook; //код книги
        private string author = string.Empty; //автор
        private string title = string.Empty; //название
        private string isbn = string.Empty; //ISBN - международный стандартный книжный номер

        public int IdBook
        {
            get { return idBook; }
            set
            {
                if (!ValidateIdBook(value))
                    throw new ArgumentException("Неверный id.");
                idBook = value;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (!ValidateAuthor(value))
                    throw new ArgumentException("Неверный автор.");
                author = value;
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (!ValidateTitle(value))
                    throw new ArgumentException("Неверное название.");
                title = value;
            }
        }
        public string Isbn
        {
            get { return isbn; }
            set
            {
                if (!ValidateIsbn(value))
                    throw new ArgumentException("Неверный ISBN.");
                isbn = value;
            }
        }
        public BookBase() { }
        public BookBase(int idBook, string author, string title, string isbn)
        {
            IdBook=idBook;
            Author = author;
            Title = title;
            Isbn = isbn;
        }

        public BookBase( string author, string title, string isbn)
        {
            Author = author;
            Title = title;
            Isbn = isbn;
        }

        public static bool ValidateIdBook(int idBook)
        {
            return idBook >= 0;
        }

        public static bool ValidateAuthor(string author)
        {
            return !string.IsNullOrWhiteSpace(author);
        }
        public static bool ValidateTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title);
        }
        public static bool ValidateIsbn(string isbn)
        {
            //ISBN - код из 13 цифр в формате XXX-X-X*(2,5)-X*(3,6)-X
            //префикс - код страны - код издательства - номер книги в издании - контрольная цифра
            return !string.IsNullOrWhiteSpace(isbn) &&
                Regex.IsMatch(isbn, @"^\d{3}-\d-\d{2,5}-\d{3,6}-\d$") && isbn.Length == 17;
        }
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {Isbn}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Book other = (Book)obj;
            return Isbn == other.Isbn;
        }
    }
}
