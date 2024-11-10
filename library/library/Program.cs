using System;
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

        }
    }
}

