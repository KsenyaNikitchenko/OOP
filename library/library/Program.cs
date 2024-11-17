using System;
using System.Text.Json;
namespace library
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(1, "Джордж Оруэлл", "1984", "Антиутопия", "Эксмо", "978-5-699-56520-9", 2014, 500.00, 50.00);
            Console.WriteLine(book1.ToString());
            Console.WriteLine(Book.ValidateIsbn(book1.Isbn));

            Book book2 = new Book("Агата Кристи", "Десять негритят", "Детектив", "Эксмо", "978-5-04-103497-9", 2022, 300.00, 30.00);

            string jsonString = "{\"idBook\":2,\"author\":\"Агата Кристи\",\"title\":\"Убийства по алфавиту\",\"genre\":\"Детектив\",\"publishingHouse\":\"Эксмо\",\"isbn\":\"978-5-98765-210-3\",\"yearOfPublication\":2021,\"collateralValue\":3000.0,\"rentalCoast\":25.0}";
            JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;
            Book book3 = new Book(jsonElement);
            Console.WriteLine(book3.ToString());
            Console.WriteLine("Проверка на равенство: " + book2.Equals(book3));

            string bookinfo = "1; Author; Title; Genre; PublishingHouse; 123-4-56789-012-3; 2020; 100,3; 10";
            Book book4 = new Book(bookinfo);
            Console.WriteLine(book4.CollateralValue);
        }
    }
}

