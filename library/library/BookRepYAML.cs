using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace library
{
    class BookRepYAML:BookFileRepository
    {

        public BookRepYAML(string filePath):base(filePath) { }
        public override List<Book> ReadAll() {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Данный файл не найден.");

            var deserializer = new DeserializerBuilder().Build();

            string yaml = File.ReadAllText(filePath);
            return deserializer.Deserialize<List<Book>>(yaml);
        }
        // Запись всех значений в файл
        public override void WriteAll(string path)
        {
            var serializer = new SerializerBuilder().Build();

            string yaml = serializer.Serialize(booksList);
            File.WriteAllText(path, yaml);
        }
    }
}
