using Lab7.Models;
using Microsoft.Data.SqlClient;

namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AuthorDBContext())
            {
                AuthorRepository authorRepository = new AuthorRepository(context);
                string userChoice;
                do
                {
                    Console.WriteLine("Authors and their Articles");
                    Console.WriteLine("Select operation to execute:");
                    Console.WriteLine("  A - get all authors");
                    Console.WriteLine("  B - get authors by first characters of name");
                    Console.WriteLine("  C - get authors by topic and first chars of name");
                    Console.WriteLine("  D - get different values(topics)");
                    Console.WriteLine("  E - get author whose name is first in alphabetical order");
                    Console.WriteLine("  F - get number of authors groped by topic");
                    Console.WriteLine("  G - get authors sorted by name in Ascending/Descending order");
                    Console.WriteLine("  H - update info about author");

                    string request = Console.ReadLine().ToUpper();

                    List<Author> authors = new List<Author>();

                    if (request == "A")
                    {
                        authors = authorRepository.GetAll();
                        PrintAuthors(authors);
                    }
                    else if (request == "B")
                    {
                        Console.Write("Type first letter of a name: ");
                        string frstCharsOfName = Console.ReadLine();

                        authors = authorRepository.GetByFirstCharsOfName(frstCharsOfName);
                        PrintAuthors(authors);
                    }
                    else if (request == "C")
                    {
                        Console.Write("Enter topic: ");
                        string topic = Console.ReadLine();
                        Console.Write("Type first letter of a name: ");
                        string frstCharsOfName = Console.ReadLine();

                        authors = authorRepository.GetByTopicAndFirstCharsOfName(topic, frstCharsOfName);
                        PrintAuthors(authors);
                    }
                    else if (request == "D")
                    {
                        var distinctValues = new List<string>();

                        distinctValues = authorRepository.GetDifferentValues();
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
                            Console.WriteLine("topic: " + item.Key + " -- " + "No of authors: " + item.Value);
                        }
                    }
                    else if (request == "G")
                    {
                        Console.Write("In which order you want to sort: A-(for ascending) D-(for descending):  ");
                        char userInput = Console.ReadKey().KeyChar;
                        Console.WriteLine(); //new line
                        string order = userInput == 'D' ? "DESC" : "ASC";

                        authors = authorRepository.GetAuthorsSortedByNameInAscOrDescOrder(order);
                        PrintAuthors(authors);
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
                        bool result = authorRepository.UpdateAuthor(author);
                        if (result)
                        {
                            Console.WriteLine("1 row affected.");
                        }
                        else
                        {
                            Console.WriteLine("0 rows affected.");
                        }
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

            static void PrintAuthors(List<Author> authors)
            {
                foreach (var author in authors)
                {

                    Console.WriteLine(author);
                }
            }

        }
    }
}
