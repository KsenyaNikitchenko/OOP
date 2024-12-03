using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace library
{
    class BookRepJSON : IFileStrategy
    {
        //Чтение всех значений из файла
        public List<Book> ReadAll(string filePath)
        {
            if (!File.Exists(filePath))
               throw new FileNotFoundException("Данный файл не найден.");

            string json = File.ReadAllText(filePath);
            using(JsonDocument doc= JsonDocument.Parse(json))
            {
                List<Book> books = new List<Book>();
                foreach (JsonElement element in doc.RootElement.EnumerateArray())
                {
                    books.Add(Book.FromJson(element));
                }
                return books;
            }
        }
        // Запись всех значений в файл
        public void WriteAll(string path, List<Book> booksList)
        {
            var options = new JsonSerializerOptions 
            { 
                WriteIndented = true,
                Encoder=JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            string jsonString = JsonSerializer.Serialize(booksList, options);
            File.WriteAllText(path, jsonString);
        }

    }
}
