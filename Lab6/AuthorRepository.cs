using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab5
{
    internal class AuthorRepository 
    {
        protected SqlConnection _connection;
        public AuthorRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        //TaskA простий запит на вибірку;
        public List<Author> GetAll()
        {
            var authors = new List<Author>();
            string query = "SELECT * FROM [Authors&Articles]";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Author author = new Author()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            name = Convert.ToString(reader["name"]),
                            topic = Convert.ToString(reader["topic"]),
                            title = Convert.ToString(reader["title"]),
                        };
                        authors.Add(author);
                    }
                }
            }
            return authors;
        }

        //TaskB  запит на вибірку з використанням спеціальних функцій: LIKE, IS NULL, IN, BETWEEN;
        public List<Author> GetByFirstCharsOfName(string frstCharsOfName)
        {
            var authors = new List<Author>();

            string query = $"SELECT id, name, topic, title FROM [Authors&Articles] WHERE name LIKE '{frstCharsOfName}%'";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Author author = new Author()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            name = Convert.ToString(reader["name"]),
                            topic = Convert.ToString(reader["topic"]),
                            title = Convert.ToString(reader["title"]),
                        };
                        authors.Add(author);
                    }
                }
            }
            return authors;

        }

        //TaskC  запит зі складним критерієм;
        public List<Author> GetByTopicAndFirstCharsOfName(string topic, string frstCharsOfName )
        {
            var authors = new List<Author>();


            string query = $"SELECT id, name, topic, title FROM [Authors&Articles] WHERE topic LIKE '{topic}' AND name LIKE '{frstCharsOfName}%'";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Author author = new Author()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            name = Convert.ToString(reader["name"]),
                            topic = Convert.ToString(reader["topic"]),
                            title = Convert.ToString(reader["title"]),
                        };
                        authors.Add(author);
                    }
                }
            }
            return authors;

        }

        //TaskD  запит з унікальними значеннями;
        public List<string> GetDifferentValues(string userSelector)
        {
            var distinctValues = new List<string>();

            string query = $"SELECT DISTINCT {userSelector} FROM [Authors&Articles];";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string value = Convert.ToString(reader[$"{userSelector}"]);
                        distinctValues.Add(value);
                    }
                }
            }
            return distinctValues;
        }

        //TaskE запит з використанням обчислювального поля;
        public string GetAuthorByFirstNameInAlphabet()
        {
            string authorName = " ";
            string query = $"SELECT MIN(name) AS first_name_in_alphabet FROM [Authors&Articles];";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        authorName = Convert.ToString(reader["first_name_in_alphabet"]);
                        return authorName;
                    }
                }
            }
            return authorName;
        }

        //TaskF  запит з групуванням по заданому полю, використовуючи умову групування;
        public Dictionary<string, int> GetNumOfAuthorsGropedByTopic()
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            string query = $"SELECT COUNT(id) AS 'number_of_authors', topic FROM [Authors&Articles] GROUP BY topic;";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string topic = Convert.ToString(reader["topic"]);
                        int numOfAuthors = Convert.ToInt32(reader["number_of_authors"]);
                        keyValuePairs.Add(topic, numOfAuthors);
                    }
                }
            }
            return keyValuePairs;

        }

        //TaskG запит із сортування по заданому полю в порядку зростання та спадання значень;
        public List<Author> GetAuthorsSortedByNameInAscOrDescOrder(string order)
        {
            var authors = new List<Author>();


            string query = $"SELECT * FROM [Authors&Articles] ORDER BY name {order};";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Author author = new Author()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            name = Convert.ToString(reader["name"]),
                            topic = Convert.ToString(reader["topic"]),
                            title = Convert.ToString(reader["title"]),
                        };
                        authors.Add(author);
                    }
                }
            }
            return authors;

        }

        //TaskH запит з використанням дій по модифікації записів.
        public int UpdateAuthor(Author author)
        {

            string query = $"UPDATE [Authors&Articles] SET name = '{author.name}', topic = '{author.topic}', title = '{author.title}' WHERE id = '{author.Id}';";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                return command.ExecuteNonQuery();
            }

        }


    }
}
