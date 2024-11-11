using System;
using System.Text.Json;
namespace library
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(1, "Джордж Оруэлл", "1984", "Антиутопия", "Эксмо", "978-5-699-56520-9", 2014, 500.00, 50.00);
            book1.PrintFullInformation();

            Book book2 = new Book( "Агата Кристи", "Десять негритят", "Детектив", "Эксмо", "978-5-04-103497-9", 2022, 300.00, 30.00);
            book2.PrintFullInformation();

            string jsonString = "{\"idBook\":2,\"author\":\"Author2\",\"title\":\"Title2\",\"genre\":\"Genre2\",\"publishingHouse\":\"PublishingHouse2\",\"isbn\":\"321-4-98765-210-3\",\"yearOfPublication\":2021,\"collateralValue\":150.0,\"rentalCoast\":15.0}";
            JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;
            Book book3 = new Book(jsonElement);
            book3.PrintFullInformation();

            string bookinfo = "1;Author;Title;Genre;PublishingHouse;123-4-56789-012-3;2020;100.5;10";
            Book book4 = new Book(bookinfo);
            book4.PrintFullInformation();
        }
    }
}

