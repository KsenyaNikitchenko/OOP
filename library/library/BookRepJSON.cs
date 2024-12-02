using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace library
{
    class BookRepJSON:BookFileRepository
    {
        public BookRepJSON(string filePath):base(filePath) { }
        
        //Чтение всех значений из файла
        public override List<Book> ReadAll()
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
        public override void WriteAll(string path)
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
