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
        
        private string genre = string.Empty; //жанр
        private string publishingHouse = string.Empty; //издательство
        private int yearOfPublication; //год издания
        private double collateralValue; //залоговая стоимость
        private double rentalCoast; //стоимость проката


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
            :base(idBook,author,title,isbn)
        {
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
        public static Book FromJson(JsonElement jsonElement)
        {
            int idBook = jsonElement.GetProperty("IdBook").GetInt32();
            string author = jsonElement.GetProperty("Author").GetString();
            string title = jsonElement.GetProperty("Title").GetString();
            string genre = jsonElement.GetProperty("Genre").GetString();
            string publishingHouse = jsonElement.GetProperty("PublishingHouse").GetString();
            string isbn = jsonElement.GetProperty("Isbn").GetString();
            int yearOfPublication = jsonElement.GetProperty("YearOfPublication").GetInt32();
            double collateralValue = jsonElement.GetProperty("CollateralValue").GetDouble();
            double rentalCoast = jsonElement.GetProperty("RentalCoast").GetDouble();

            return new Book(idBook, author, title, genre, publishingHouse, isbn, yearOfPublication, collateralValue, rentalCoast);
        }

        //Создание объекта из строки формата "1; Author; Title; Genre; PublishingHouse; 123-4-56789-012-3; 2020; 100,0; 10,0"
        public static Book FromString(string bookString)
        {
            var parts = bookString.Split(';');
            if (parts.Length == 9)
            {
                try
                {
                    int idBook = int.Parse(parts[0].Trim());
                    string author = parts[1].Trim();
                    string title = parts[2].Trim();
                    string genre = parts[3].Trim();
                    string publishingHouse = parts[4].Trim();
                    string isbn = parts[5].Trim();
                    int yearOfPublication = int.Parse(parts[6].Trim());
                    double collateralValue = double.Parse(parts[7].Trim());
                    double rentalCoast = double.Parse(parts[8].Trim());

                    return new Book(idBook, author, title, genre, publishingHouse, isbn, yearOfPublication, collateralValue, rentalCoast);
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
            return $"IdBook: {IdBook}, Author: {Author}, Title: {Title}, Genre: {Genre}, PublishingHouse: {PublishingHouse}," +
                $"ISBN: {Isbn}, YearOfPublication: {YearOfPublication}, CollateralValue: {CollateralValue}, RentalCoast: {RentalCoast}";
        }

    }
}
