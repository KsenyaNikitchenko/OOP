using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Book
    {
        // Приватные поля
        private int idBook;
        private string author;
        private string title;
        private string genre;
        private string publishingHouse;
        private string isbn;
        private int yearOfPublication;
        private double collateralValue;
        private double rentalCoast;

        // Публичные свойства для доступа к приватным полям
        public int IDBook
        {
            get { return idBook; }
            set { idBook = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string PublishingHouse
        {
            get { return publishingHouse; }
            set { publishingHouse = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public int YearOfPublication
        {
            get { return yearOfPublication; }
            set { yearOfPublication = value; }
        }

        public double CollateralValue
        {
            get { return collateralValue; }
            set { collateralValue = value; }
        }

        public double RentalCoast
        {
            get { return rentalCoast; }
            set { rentalCoast = value; }
        }

        // Конструктор класса
        public Book(int book_id, string book_author, string book_title, string book_genre, string publ_house, string book_isbn, int year, double deposit, double rent_coast)
        {
            idBook = book_id;
            author = book_author;
            title = book_title;
            genre = book_genre;
            publishingHouse = publ_house;
            isbn = book_isbn;
            yearOfPublication = year;
            collateralValue = deposit;
            rentalCoast = rent_coast;
        }

        // Метод для вывода информации о книге
        public void PrintInformation()
        {
            Console.WriteLine("Код книги: " + idBook);
            Console.WriteLine("Автор: " + author);
            Console.WriteLine("Название: " + title);
            Console.WriteLine("Жанр: " + genre);
            Console.WriteLine("Издательство: " + publishingHouse);
            Console.WriteLine("isbn: " + isbn);
            Console.WriteLine("Год издания: " + yearOfPublication);
            Console.WriteLine("Залоговая стоимость: " + collateralValue);
            Console.WriteLine("Стоимость проката: " + rentalCoast);
        }

    }
}
