using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace library
{
    class Book:BookBase
    {
        private int idBook; //код книги
        private string genre = string.Empty; //жанр
        private string publishingHouse = string.Empty; //издательство
        private int yearOfPublication; //год издания
        private double collateralValue; //залоговая стоимость
        private double rentalCoast; //стоимость проката

        public int IDBook
        {
            get { return idBook; }
            set {
                if (!ValidateIdBook(value))
                    throw new ArgumentException("Неверный id.");
                idBook = value;
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
            :base(author,title,isbn)
        {
            IDBook = idBook;
            Genre = genre;
            PublishingHouse = publishingHouse;
            YearOfPublication = yearOfPublication;
            CollateralValue = collateralValue;
            RentalCoast = rentalCoast;
        }

        public Book (string author, string title, string genre, string publishingHouse,
            string isbn, int yearOfPublication, double collateralValue, double rentalCoast)
            :base(author,title,isbn)
        {
            Author = author;
            PublishingHouse = publishingHouse;
            YearOfPublication = yearOfPublication;
            CollateralValue = collateralValue;
            RentalCoast = rentalCoast;
        }

        //создание объекта из JSON
        public Book(JsonElement jsonElement) : base("a", "b", "123-4-56789-012-3")
        {
            if (jsonElement.TryGetProperty("idBook", out var idBookElement))
                IDBook = idBookElement.GetInt32();
            if (jsonElement.TryGetProperty("author", out var authorElement))
                Author = authorElement.GetString();
            if (jsonElement.TryGetProperty("title", out var titleElement))
                Title = titleElement.GetString();
            if (jsonElement.TryGetProperty("genre", out var genreElement))
                Genre = genreElement.GetString();
            if (jsonElement.TryGetProperty("publishingHouse", out var publishingHouseElement))
                PublishingHouse = publishingHouseElement.GetString();
            if (jsonElement.TryGetProperty("isbn", out var isbnElement))
                Isbn = isbnElement.GetString();
            if (jsonElement.TryGetProperty("yearOfPublication", out var yearOfPublicationElement))
                YearOfPublication = yearOfPublicationElement.GetInt32();
            if (jsonElement.TryGetProperty("collateralValue", out var collateralValueElement))
                CollateralValue = collateralValueElement.GetDouble();
            if (jsonElement.TryGetProperty("rentalCoast", out var rentalCoastElement))
                RentalCoast = rentalCoastElement.GetDouble();
        }

        //Создание объекта из строки формата "1; Author; Title; Genre; PublishingHouse; 123-4-56789-012-3; 2020; 100,0; 10,0"
        public Book(string bookString):base("a","b", "123-4-56789-012-3")
        {
            var parts = bookString.Split(';');
            if (parts.Length == 9)
            {
                try
                {
                    IDBook = int.Parse(parts[0].Trim());
                    base.Author = parts[1].Trim();
                    base.Title = parts[2].Trim();
                    Genre = parts[3].Trim();
                    PublishingHouse = parts[4].Trim();
                    base.Isbn = parts[5].Trim();
                    YearOfPublication = int.Parse(parts[6].Trim());
                    CollateralValue = double.Parse(parts[7].Trim());
                    RentalCoast = double.Parse(parts[8].Trim());
                }
                catch (FormatException ex)
                {
                    throw new ArgumentException("Неверный формат данных.", ex);
                }
            }
            else
            {
                throw new ArgumentException("Неверный формат строки.");
            }
            
        }

        public static bool ValidateIdBook(int idBook)
        {
            return idBook >= 0;
        }
        public static bool ValidateGenre(string genre)
        {
            return !string.IsNullOrWhiteSpace(genre);
        }
        public static bool ValidatePublishingHouse(string publishingHouse)
        {
            return !string.IsNullOrWhiteSpace(publishingHouse);
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
        // Метод для вывода полной версии объекта
        public string ToFullString()
        {
            return $"IdBook: {IDBook}, Author: {Author}, Title: {Title}, Genre: {Genre}, PublishingHouse: {PublishingHouse}," +
                $"ISBN: {Isbn}, YearOfPublication: {YearOfPublication}, CollateralValue: {CollateralValue}, RentalCoast: {RentalCoast}";
        }

    }
}
