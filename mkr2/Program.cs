using mkr2.Models;

namespace mkr2
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new VstupDBContext())
            {
                AbiturientRepository abiturRepository = new AbiturientRepository(context);
                string userChoice;
                do
                {
                    Console.WriteLine("Vstup");
                    Console.WriteLine("Select operation to execute:");
                    Console.WriteLine("  A - get all abiturients");
                    Console.WriteLine("  B - get abiturients by surname");
                    Console.WriteLine("  C - get number of abiturients by year and score");

                    
                    string request = Console.ReadLine().ToUpper();


                    List<Abiturient> abiturients = new List<Abiturient>();

                    if(request == "A")
                    {
                        abiturients = abiturRepository.GetAll();
                        PrintAbiturients(abiturients);
                    }
                    else if(request == "B")
                    {
                        Console.Write("Enter abiturient's surname: ");
                        string surname = Console.ReadLine();
                        abiturients = abiturRepository.GetByName(surname);
                        PrintAbiturients(abiturients);
                    }
                    else if (request == "C")
                    {
                        Console.Write("Enter year: ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter min score: ");
                        int score = Convert.ToInt32(Console.ReadLine());
                        int numOfAbiturs = abiturRepository.GetNumOfAbiturientsByScoreAndYear(year, score);
                        Console.WriteLine($"{numOfAbiturs} abiturients graduated from school in {year} and scored at least {score} points");
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


            static void PrintAbiturients(List<Abiturient> abiturients)
            {
                foreach (var abitur in abiturients) 
                {
                    Console.WriteLine("ID: {0} | surname: {1} | sex: {2} | graduation year: {3} | total score: {4}",
                                       abitur.Id, abitur.surname, abitur.sex, abitur.graduation_year, abitur.total_score);
                }
            }
        }
    }
}