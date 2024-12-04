using Npgsql;
using System.Data.Common;

namespace library
{
    class BookRepDB
    {
        private DatabaseConnection dbConn;
        public BookRepDB(string connection)
        {
            dbConn = DatabaseConnection.GetInstance(connection);
        }
        //Получение объекта по ID
        public Book? GetBookById(int id)
        {
            string sql = "select * from Books where idBook=@id";
            using (NpgsqlCommand command = dbConn.CreateCommand(sql))
            {
                command.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Book(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetInt32(6),
                        reader.GetDouble(7),
                        reader.GetDouble(8)
                        );
                }
                else return null;
            }
        }
        //Получить список k по счету n объектов класса short
        public List<Book> GetKNShortList(int k, int n)
        {
            List<Book> list = new List<Book>();

            string sql = "select * from Books limit @n offset @k";
            using (NpgsqlCommand command = dbConn.CreateCommand(sql))
            {
                command.Parameters.Add("k", NpgsqlTypes.NpgsqlDbType.Integer).Value = (k - 1) * n;
                command.Parameters.Add("n", NpgsqlTypes.NpgsqlDbType.Integer).Value = n;
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetInt32(6),
                            reader.GetDouble(7),
                            reader.GetDouble(8)
                            ));
                    }
                }
            }

            return list;
        }
        // Добавить объект в список (сформировать новый ID)
        public void Add(Book book)
        {

            string sql = "insert into Books (author, title, genre, publishingHouse, isbn, yearOfPublication, collateralValue, rentalCoast) " +
                "values (@author, @title, @genre, @publishingHouse, @isbn, @yearOfPublication, @collateralValue, @rentalCoast)";
            using (NpgsqlCommand command = dbConn.CreateCommand(sql))
            {
                command.Parameters.Add("author", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.Author;
                command.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.Title;
                command.Parameters.Add("genre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.Genre;
                command.Parameters.Add("publishingHouse", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.PublishingHouse;
                command.Parameters.Add("isbn", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.Isbn;
                command.Parameters.Add("yearOfPublication", NpgsqlTypes.NpgsqlDbType.Integer).Value = book.YearOfPublication;
                command.Parameters.Add("collateralValue", NpgsqlTypes.NpgsqlDbType.Double).Value = book.CollateralValue;
                command.Parameters.Add("rentalCoast", NpgsqlTypes.NpgsqlDbType.Double).Value = book.RentalCoast;

                command.ExecuteNonQuery();
            }

        }
        // Заменить элемент списка по ID
        public void Replace(int id, Book book)
        {

            string sql = "update Books set author=@author, title=@title, genre=@genre, publishingHouse=@publishingHouse, isbn=@isbn," +
                "yearOfPublication=@yearOfPublication, collateralValue=@collateralValue, rentalCoast=@rentalCoast where idBook=@id";
            using (NpgsqlCommand command = dbConn.CreateCommand(sql))
            {
                command.Parameters.Add("author", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.Author;
                command.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.Title;
                command.Parameters.Add("genre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.Genre;
                command.Parameters.Add("publishingHouse", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.PublishingHouse;
                command.Parameters.Add("isbn", NpgsqlTypes.NpgsqlDbType.Varchar).Value = book.Isbn;
                command.Parameters.Add("yearOfPublication", NpgsqlTypes.NpgsqlDbType.Integer).Value = book.YearOfPublication;
                command.Parameters.Add("collateralValue", NpgsqlTypes.NpgsqlDbType.Double).Value = book.CollateralValue;
                command.Parameters.Add("rentalCoast", NpgsqlTypes.NpgsqlDbType.Double).Value = book.RentalCoast;
                command.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                command.ExecuteNonQuery();
            }

        }
        // Удалить элемент списка по ID
        public void Delete(int id)
        {
            string sql = "delete from Books where idBook=@id";
            using (NpgsqlCommand command = dbConn.CreateCommand(sql))
            {
                command.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                command.ExecuteNonQuery();
            }
        }
        // Получить количество элементов
        public int GetCount()
        {
            string sql = "select count(*) from Books";
            using (NpgsqlCommand command = dbConn.CreateCommand(sql))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
