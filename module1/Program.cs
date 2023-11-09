// 12) Елементи колекції «Студенти» містить наступну інформацію про студентів: код, прізвище, група.
// Кожен елемент колекції «Сесія» містить код студента, назву предмета, форму контролю (залік або
// іспит), підсумковий бал, дату складання.
// a) Вивести коди студентів, прізвища яких починаються на задану літеру.
// b) Вивести назви груп, не більше двох різних студентів яких отримали двійки на іспиті у
// поточному році.
// c) Зберегти дані однієї з колекцій в xml-файлі.

using System.Runtime.CompilerServices;
using System.Xml.Linq;

public class Student
{
    public int Code {get;set;}
    public string Surname {get;set;}
    public string Group {get;set;}
}

public class Session
{
    public int StudentCode {get;set;}
    public string SubjectName {get;set;}
    public string FormOfControl {get;set;}
    public int FinalGrade {get;set;}
    public DateOnly DateOfExam {get;set;}

}

class Program
{
    static List<Student> allStudents = new List<Student>(){
        new Student {Code = 1, Surname = "Henry", Group = "CA21" },
        new Student {Code = 2, Surname = "O'Connel", Group = "CA22" },
        new Student {Code = 3, Surname = "Silva", Group = "CA22" },
        new Student {Code = 4, Surname = "Ramos", Group = "CA21" },
        new Student {Code = 5, Surname = "William", Group = "CA21" },
        new Student {Code = 6, Surname = "Shaw", Group = "CA22" }
    };

    static List<Session> allSessions = new List<Session>(){
        new Session {StudentCode = 1, SubjectName = "Web", FormOfControl = "Zalik", FinalGrade = 2, DateOfExam = new DateOnly(2023,07,05)},
        new Session {StudentCode = 1, SubjectName = "Discete Math", FormOfControl = "Exam", FinalGrade = 4, DateOfExam = new DateOnly(2023,07,08)},
        new Session {StudentCode = 1, SubjectName = "Programming", FormOfControl = "Zalik", FinalGrade = 5, DateOfExam = new DateOnly(2023,07,10)},
        new Session {StudentCode = 2, SubjectName = "Web", FormOfControl = "Zalik", FinalGrade = 3, DateOfExam = new DateOnly(2023,07,05)},
        new Session {StudentCode = 2, SubjectName = "Discete Math", FormOfControl = "Exam", FinalGrade = 3, DateOfExam = new DateOnly(2023,07,08)},
        new Session {StudentCode = 2, SubjectName = "Programming", FormOfControl = "Zalik", FinalGrade = 3, DateOfExam = new DateOnly(2023,07,10)},
        new Session {StudentCode = 3, SubjectName = "Web", FormOfControl = "Zalik", FinalGrade = 4, DateOfExam = new DateOnly(2023,07,05)},
        new Session {StudentCode = 3, SubjectName = "Discete Math", FormOfControl = "Exam", FinalGrade = 2, DateOfExam = new DateOnly(2023,07,08)},
        new Session {StudentCode = 3, SubjectName = "Programming", FormOfControl = "Zalik", FinalGrade = 4, DateOfExam = new DateOnly(2023,07,10)},
        new Session {StudentCode = 4, SubjectName = "Web", FormOfControl = "Zalik", FinalGrade = 5, DateOfExam = new DateOnly(2023,07,05)},
        new Session {StudentCode = 4, SubjectName = "Discete Math", FormOfControl = "Exam", FinalGrade = 2, DateOfExam = new DateOnly(2023,07,08)},
        new Session {StudentCode = 4, SubjectName = "Programming", FormOfControl = "Zalik", FinalGrade = 5, DateOfExam = new DateOnly(2023,07,10)},
        new Session {StudentCode = 5, SubjectName = "Web", FormOfControl = "Zalik", FinalGrade = 2, DateOfExam = new DateOnly(2023,07,05)},
        new Session {StudentCode = 5, SubjectName = "Discete Math", FormOfControl = "Exam", FinalGrade = 2, DateOfExam = new DateOnly(2023,07,08)},
        new Session {StudentCode = 5, SubjectName = "Programming", FormOfControl = "Zalik", FinalGrade = 3, DateOfExam = new DateOnly(2023,07,10)},
        new Session {StudentCode = 6, SubjectName = "Web", FormOfControl = "Zalik", FinalGrade = 4, DateOfExam = new DateOnly(2023,07,05)},
        new Session {StudentCode = 6, SubjectName = "Discete Math", FormOfControl = "Exam", FinalGrade = 3, DateOfExam = new DateOnly(2023,07,08)},
        new Session {StudentCode = 6, SubjectName = "Programming", FormOfControl = "Zalik", FinalGrade = 4, DateOfExam = new DateOnly(2023,07,10)},
        
    };
    static void Main(string[] args)
    {
        // GetStudtByFirstSurnameLetter();
        

        // GetStudGroupWithGoodGrades();
        
        // string fileName = "Students.xml";
        // SaveStudentsToXml(fileName);
    }

    //TaskA Вивести коди студентів, прізвища яких починаються на задану літеру.
    static void GetStudtByFirstSurnameLetter(){
        Console.Write("Type first letter of surname: ");
        char inputChar = Convert.ToChar(Console.ReadLine());
        var selectedStuds = allStudents
        .Where(stud => stud.Surname[0] == inputChar )
        .Select(stud => new {stud.Code});
        Console.WriteLine($"Code of students whose surnames begin with the letter '{inputChar}':  ");
        foreach (var stud in selectedStuds)
        {
            Console.WriteLine("Code: " + stud.Code);
        }
    }
    
    //TaskB Вивести назви груп, не більше двох різних студентів яких отримали двійки на іспиті у поточному році.
    static void GetStudGroupWithGoodGrades(){
        var currentYear = DateTime.Now.Year;

        var studsWithBadGrages = allStudents
        .GroupJoin(allSessions,
        stud => stud.Code,
        session => session.StudentCode,
        (st,sessGroup) => new {
            st,sessGroup
        })
        .Where(stud => stud.sessGroup.Any((sess) => sess.DateOfExam.Year == currentYear  &&  sess.FinalGrade <= 2 ))
        .Select(stud => new {
            stud.st.Code,
            stud.st.Surname,
            stud.st.Group,
            Sessions = stud.sessGroup
        });

        var result = studsWithBadGrages
        .GroupBy(stud => stud.Group)
        .Where(obj => obj.Count() <= 2)
        .Select(obj => obj.Key);
        System.Console.WriteLine("Groups of students with good grades:");
        foreach (var group in result)
        {
            System.Console.WriteLine(group);
        }
        
    }

    //TaskC  Зберегти дані однієї з колекцій в xml-файлі.
    static void SaveStudentsToXml(string fileName){
        XDocument xmlDocument = new XDocument(
            new XDeclaration("1.0","UTF-8","Yes"),
            new XElement("Students",
                allStudents
                .Select(stud => new XElement("Student", new XAttribute("Code", stud.Code),
                            new XElement("Surname", stud.Surname),
                            new XElement("Group", stud.Group) ) ) ) );


        
        xmlDocument.Save(fileName);
        System.Console.WriteLine("Information about students is saved in XML file.");
        
    }
    
}