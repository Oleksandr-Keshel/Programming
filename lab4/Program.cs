using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class Abiturient
{
    [JsonProperty(PropertyName = "surname")]
    public string Surname {get;set;}

    [JsonProperty(PropertyName = "sex")]
    public string Sex {get;set;}

    [JsonProperty(PropertyName = "graduation_year")]
    public int GraduationYear {get;set;}

    [JsonProperty(PropertyName = "total_point")]
    public int TotalPoint {get;set;}
    
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "Vstup.json";
        string jsonString = File.ReadAllText(filePath);
        List<Abiturient> abiturients = JsonConvert.DeserializeObject<List<Abiturient>>(jsonString);
        
        //Read the file in console
        Console.WriteLine("Abiturients: ");
        foreach (var abiturient in abiturients)
        {
            Console.WriteLine($"Surname: {abiturient.Surname}, Sex: {abiturient.Sex}, Graduation year: {abiturient.GraduationYear}, Total points: {abiturient.TotalPoint}");
        }

        System.Console.WriteLine("--------------");

        //Select abiturient by name
        Console.Write("Type surname of abiturient:  ");
        string inputSurname = Console.ReadLine();
        var selectedAbitur = abiturients
        .Where(abtr => abtr.Surname == inputSurname);
        Console.WriteLine("Information about specified abiturient:");
        foreach (var abitur in selectedAbitur)
        {
            Console.WriteLine($"Surname: {abitur.Surname}, Sex: {abitur.Sex}, Graduation year: {abitur.GraduationYear}, Total points: {abitur.TotalPoint}");
        }

        System.Console.WriteLine("--------------");        

        //Select abiturient by graduation year and min point
        Console.Write("Type graduation year:  ");
        int inputYear = Convert.ToInt32(Console.ReadLine());
        Console.Write("Type min point:  ");
        int inputMinPoint = Convert.ToInt32(Console.ReadLine());
        var numOfSelectedAbiturs = abiturients
        .Where(abitur => abitur.GraduationYear == inputYear && abitur.TotalPoint >= inputMinPoint)
        .Count();

        Console.WriteLine("Number of abiturients: " + numOfSelectedAbiturs);

    }
}