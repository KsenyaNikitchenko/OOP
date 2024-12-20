﻿using System.Text.Json;
namespace library
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(1, "Джордж Оруэлл", "1984", "Антиутопия", "Эксмо", "978-5-699-56520-9", 2014, 500.00, 50.00);
            //Console.WriteLine(book1.Genre);
            //Console.WriteLine(Book.ValidateIsbn(book1.Isbn));
            //book1.Genre = "aaaa";
            //Console.WriteLine(book1.Genre);

            Book book2 = new Book("Агата Кристи", "Десять негритят", "Детектив", "Эксмо", "978-5-04-103497-9", 2022, 300.00, 30.00);
            //Console.WriteLine(book2.IdBook);

            string jsonString = """
                {"IdBook":2,
                "Author":"Агата Кристи",
                "Title":"Убийства по алфавиту",
                "Genre":"Детектив",
                "PublishingHouse":"Эксмо",
                "Isbn":"978-5-98765-210-3",
                "YearOfPublication":2021,
                "CollateralValue":300.0,
                "RentalCoast":25.0}
                """;
            JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;
            Book book3 = Book.FromJson(jsonElement);
            //Console.WriteLine(book3.ToFullString());
            //Console.WriteLine("Проверка на равенство: " + book2.Equals(book3));

            //string bookinfo = "1; Author; Title; Genre; PublishingHouse; 123-4-56789-012-3; 2020; 100,3; 10";
            //Book book4 = Book.FromString(bookinfo);
            //Console.WriteLine(book4.CollateralValue);

            
            string jsonFilePath1 = "C:\\Users\\Kseniya Nikitchenko\\Documents\\GitHub\\OOP\\booksList.json";
            //BookRepJSON repJson =new BookRepJSON(jsonFilePath1);
            //string jsonFilePath2 = "C:\\Users\\Kseniya Nikitchenko\\Documents\\GitHub\\OOP\\booksListWrite.json";
            //List<Book> books = repJson.GetKNShortList(3, 2);
            //repJson.Replace(5, book3);
            //repJson.Add(book2);
            //repJson.Remove(5);
            //Console.WriteLine(repJson.GetCount());
            //Console.WriteLine(repJson.GetBookById(2)?.ToString());
            //repJson.WriteAll(jsonFilePath2);

            //string yamlFilePath1 = "C:\\Users\\Kseniya Nikitchenko\\Documents\\GitHub\\OOP\\booksList.yaml";
            //string yamlFilePath2 = "C:\\Users\\Kseniya Nikitchenko\\Documents\\GitHub\\OOP\\booksListWrite.yaml";
            //BookRepYAML repYAML = new BookRepYAML(yamlFilePath1);
            //repYAML.WriteAll(yamlFilePath2);
            //BookRepYAML repYAML1 = new BookRepYAML(yamlFilePath2);

            BookFileRepository fileRep = new BookFileRepository(jsonFilePath1, new BookRepJSON());
            //fileRep.Add(book3);
            //List<Book> books=fileRep.GetKNShortList(3,2);
            //fileRep.WriteAll();
            
            string connect = "Server=localhost; Port=5432; UserID=postgres; Password=postpass; Database=Library";
            BookRepDB repDB = new BookRepDB(connect);
            //List<Book> books = repDB.GetKNShortList(2, 2);
            repDB.Add(book2);
            //repDB.Replace(2, book3);
            Console.WriteLine(repDB.GetCount());
        }
    }
}

