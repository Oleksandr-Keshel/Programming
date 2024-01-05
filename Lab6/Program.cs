using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Oleksandr\\Desktop\\Programming2\\Lab5\\sa2_keshel.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                AuthorRepository authorRepository = new AuthorRepository(connection);
                string userChoice;
                do
                {
                    Console.WriteLine("Authors and their Articles");
                    Console.WriteLine("Select operation to execute:");
                    Console.WriteLine("  A - get all authors");
                    Console.WriteLine("  B - get authors by first characters of name");
                    Console.WriteLine("  C - get authors by topic and first chars of name");
                    Console.WriteLine("  D - get different values");
                    Console.WriteLine("  E - get author whose name is first in alphabetical order");
                    Console.WriteLine("  F - get number of authors groped by topic");
                    Console.WriteLine("  G - get authors sorted by name in Ascending/Descending order");
                    Console.WriteLine("  H - update info about author");

                    string request = Console.ReadLine().ToUpper();

                    List<Author> authors = new List<Author>();

                    if (request == "A")
                    {
                        authors = authorRepository.GetAll();
                        printAuthors(authors);
                    }
                    else if (request == "B")
                    {
                        Console.Write("Type first letter of a name: ");
                        string frstCharsOfName = Console.ReadLine();

                        authors = authorRepository.GetByFirstCharsOfName(frstCharsOfName);
                        printAuthors(authors);
                    }
                    else if (request == "C")
                    {
                        Console.Write("Enter topic: ");
                        string topic = Console.ReadLine();
                        Console.Write("Type first letter of a name: ");
                        string frstCharsOfName = Console.ReadLine();

                        authors = authorRepository.GetByTopicAndFirstCharsOfName(topic, frstCharsOfName);
                        printAuthors(authors);
                    }
                    else if (request == "D")
                    {
                        var distinctValues = new List<string>();
                        Console.Write("Enter selection: ");
                        string userSelector = Console.ReadLine();

                        distinctValues = authorRepository.GetDifferentValues(userSelector);
                        foreach (var item in distinctValues)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else if (request == "E")
                    {
                        string authorName = authorRepository.GetAuthorByFirstNameInAlphabet();
                        Console.WriteLine(authorName + " - is the first name listed alphabetically");
                    }
                    else if (request == "F")
                    {
                        Dictionary<string, int> topicNumOfAuthPairs = authorRepository.GetNumOfAuthorsGropedByTopic();
                        foreach (var item in topicNumOfAuthPairs)
                        {
                            Console.WriteLine("topic: " + item.Key + " -- " + "No of auhtors: " + item.Value);
                        }
                    }
                    else if (request == "G")
                    {
                        Console.Write("In which order you want to sort: A-(for ascending) D-(for descending):  ");
                        char userInput = Console.ReadKey().KeyChar;
                        Console.WriteLine(); //new line
                        string order = userInput == 'D' ? "DESC" : "ASC";

                        authors = authorRepository.GetAuthorsSortedByNameInAscOrDescOrder(order);
                        printAuthors(authors);
                    }
                    else if (request == "H")
                    {
                        Console.Write("ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Convert.ToString(Console.ReadLine());
                        Console.Write("Topic: ");
                        string topic = Convert.ToString(Console.ReadLine());
                        Console.Write("Title: ");
                        string title = Convert.ToString(Console.ReadLine());
                        Author author = new Author()
                        {
                            Id = id,
                            name = name,
                            topic = topic,
                            title = title,
                        };
                        int result = authorRepository.UpdateAuthor(author);
                        Console.WriteLine($"{result} row(s) affected");

                    }
                    else
                    {
                        Console.WriteLine("No such operation");
                    }

                    do
                    {
                        Console.WriteLine("\nDo you want to continue -- Yes or No?");
                        userChoice = Console.ReadLine().ToUpper();
                        if (userChoice != "YES" && userChoice != "NO")
                        {
                            Console.WriteLine("Invalid choice, please say Yes or No");
                        }

                    } while (userChoice != "YES" && userChoice != "NO");

                } while (userChoice == "YES");
                


            }

            void printAuthors(List<Author> authors)
            {
                foreach (var author in authors)
                {

                    Console.WriteLine(author);
                }
            }

        }
    }
}
