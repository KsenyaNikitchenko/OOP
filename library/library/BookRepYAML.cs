using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace library
{
    class BookRepYAML : IFileStrategy
    {
        public List<Book> ReadAll(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Данный файл не найден.");

            var deserializer = new DeserializerBuilder().Build();

            string yaml = File.ReadAllText(filePath);
            return deserializer.Deserialize<List<Book>>(yaml);
        }
        // Запись всех значений в файл
        public void WriteAll(string path, List<Book> booksList)
        {
            var serializer = new SerializerBuilder().Build();

            string yaml = serializer.Serialize(booksList);
            File.WriteAllText(path, yaml);
        }
    }
}
