using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace library
{
    class Book
    {
        private int idBook; //код книги
        private string author; //автор
        private string title; //название
        private string genre; //жанр
        private string publishingHouse; //издательство
        private string isbn; //ISBN - международный стандартный книжный номер
        private int yearOfPublication; //год издания
        private double collateralValue; //залоговая стоимость
        private double rentalCoast; //стоимость проката

        public int IDBook
        {
            get { return idBook; }
            set { }
        }

        public string Author
        {
            get { return author; }
            set {
                if (!ValidateAuthor(value))
                    throw new ArgumentException("Неверный автор.");
                author = value;
            }
        }

        public string Title
        {
            get { return title; }
            set {
                if (!ValidateTitle(value))
                    throw new ArgumentException("Неверное название.");
                title = value;
            }
        }

        public string Genre
        {
            get { return genre; }
            set {
                if (!ValidateGenre(value))
                    throw new ArgumentException("Неверный жанр.");
                genre = value;
            }
        }

        public string PublishingHouse
        {
            get { return publishingHouse; }
            set {
                if (!ValidatePublishingHouse(value))
                    throw new ArgumentException("Неверное издательство.");
                publishingHouse = value;
            }
        }

        public string Isbn
        {
            get { return isbn; }
            set {
                if (!ValidateIsbn(value))
                    throw new ArgumentException("Неверный ISBN.");
                isbn = value;
            }
        }

        public int YearOfPublication
        {
            get { return yearOfPublication; }
            set {
                if (!ValidateYearOfPublication(value))
                    throw new ArgumentException("Неверный год издания.");
                yearOfPublication = value;
            }
        }

        public double CollateralValue
        {
            get { return collateralValue; }
            set {
                if (!ValidateCollateralValue(value))
                    throw new ArgumentException("Неверная залоговая стоимость.");
                collateralValue = value;
            }
        }

        public double RentalCoast
        {
            get { return rentalCoast; }
            set {
                if (!ValidateRentalCoast(value))
                    throw new ArgumentException("Неверная стоимость проката.");
                rentalCoast = value;
            }
        }

        public Book(int idBook, string author, string title, string genre, string publishingHouse,
            string isbn, int yearOfPublication, double collateralValue, double rentalCoast)
        {
            if (!ValidateIdBook(idBook))
                throw new ArgumentException("Неверный код книги.");
            if (!ValidateAuthor(author))
                throw new ArgumentException("Неверный автор.");
            if (!ValidateTitle(title))
                throw new ArgumentException("Неверное название.");
            if (!ValidateGenre(genre))
                throw new ArgumentException("Неверный жанр.");
            if (!ValidatePublishingHouse(publishingHouse))
                throw new ArgumentException("Неверное издательство.");
            if (!ValidateIsbn(isbn))
                throw new ArgumentException("Неверный ISBN.");
            if (!ValidateYearOfPublication(yearOfPublication))
                throw new ArgumentException("Неверный год издания.");
            if (!ValidateCollateralValue(collateralValue))
                throw new ArgumentException("Неверная залоговая стоимость.");
            if (!ValidateRentalCoast(rentalCoast))
                throw new ArgumentException("Неверная стоимость проката.");

            this.idBook = idBook;
            this.author = author;
            this.title = title;
            this.genre = genre;
            this.publishingHouse = publishingHouse;
            this.isbn = isbn;
            this.yearOfPublication = yearOfPublication;
            this.collateralValue = collateralValue;
            this.rentalCoast = rentalCoast;
        }

        public Book ( string author, string title, string genre, string publishingHouse,
            string isbn, int yearOfPublication, double collateralValue, double rentalCoast) : this (0, author,
                title, genre, publishingHouse, isbn, yearOfPublication, collateralValue, rentalCoast)
        { }

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
        public static bool ValidateGenre(string genre)
        {
            return !string.IsNullOrWhiteSpace(genre);
        }
        public static bool ValidatePublishingHouse(string publishingHouse)
        {
            return !string.IsNullOrWhiteSpace(publishingHouse);
        }
        public static bool ValidateIsbn(string isbn)
        {
            //ISBN - код из 13 цифр в формате XXX-X-X*(2,5)-X*(3,6)-X
            return !string.IsNullOrWhiteSpace(isbn) && 
                Regex.IsMatch(isbn, @"^\d{3}-\d-\d{2,5}-\d{3,6}-\d$") && isbn.Length==17;
        }
        public static bool ValidateYearOfPublication(int yearOfPublication)
        {
            return yearOfPublication > 0 && yearOfPublication <= DateTime.Now.Year;
        }
        public static bool ValidateCollateralValue(double collateralValue)
        {
            return collateralValue >= 0;
        }
        public static bool ValidateRentalCoast(double rentalCost)
        {
            return rentalCost >= 0;
        }

        public void PrintFullInformation()
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
