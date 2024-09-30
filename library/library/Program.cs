using System;
namespace library
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования класса Книга
            Book book = new Book(1, "Джордж Оруэлл", "1984", "Антиутопия", "Эксмо", "978-5-699-56520-9", 2014, 500.00, 50.00);
            book.PrintInformation();
        }
    }
}

