using System.Runtime.CompilerServices;
using System.Threading.Channels;

public static class Data 
{

        public static List<Factory> GetEmployees(){
        List<Factory> empoyees = new List<Factory>(){
            new Factory{
                Id= 1,
                Surname = "Fredom",
                DateOfBirth = new DateOnly(1993,04,23),
                Sex = "Male",
                WorkshopNum = 1,
                Position = "Operative",
                Experience = 2,
                Salary = 1100
            },
            new Factory{
                Id= 2,
                Surname = "Smith",
                DateOfBirth = new DateOnly(1990,06,23),
                Sex = "Male",
                WorkshopNum = 2,
                Position = "Operative",
                Experience = 1,
                Salary = 1000
            },
            new Factory{
                Id= 3,
                Surname = "Race",
                DateOfBirth = new DateOnly(1993,04,23),
                Sex = "Female",
                WorkshopNum = 1,
                Position = "Sorter",
                Experience = 1,
                Salary = 1300
            },
            new Factory{
                Id= 4,
                Surname = "Gosling",
                DateOfBirth = new DateOnly(1993,04,23),
                Sex = "Male",
                WorkshopNum = 1,
                Position = "Manager",
                Experience = 2,
                Salary = 3000
            },
            new Factory{
                Id= 5,
                Surname = "Gaze",
                DateOfBirth = new DateOnly(1993,04,23),
                Sex = "Male",
                WorkshopNum = 1,
                Position = "Driver",
                Experience = 2,
                Salary = 2000
            },
            new Factory{
                Id= 6,
                Surname = "Silva",
                DateOfBirth = new DateOnly(1993,04,23),
                Sex = "Female",
                WorkshopNum = 1,
                Position = "Operative",
                Experience = 1,
                Salary = 1050
            },
            new Factory{
                Id= 7,
                Surname = "Downey",
                DateOfBirth = new DateOnly(1993,04,23),
                Sex = "Male",
                WorkshopNum = 2,
                Position = "Manager",
                Experience = 3,
                Salary = 3500
            },
            new Factory{
                Id= 8,
                Surname = "McGarden",
                DateOfBirth = new DateOnly(1993,04,23),
                Sex = "Male",
                WorkshopNum = 3,
                Position = "Driver",
                Experience = 1,
                Salary = 2100
            },
            new Factory{
                Id= 9,
                Surname = "Dock",
                DateOfBirth = new DateOnly(2004,03,01),
                Sex = "Male",
                WorkshopNum = 2,
                Position = "Operative",
                Experience = 1,
                Salary = 1000
            },
            new Factory{
                Id= 10,
                Surname = "Tilor",
                DateOfBirth = new DateOnly(1975,10,30),
                Sex = "Female",
                WorkshopNum = 2,
                Position = "Sewer",
                Experience = 2,
                Salary = 2600
            },
            new Factory{
                Id= 11,
                Surname = "Holland",
                DateOfBirth = new DateOnly(1960,10,30),
                Sex = "Male",
                WorkshopNum = 3,
                Position = "Sorter",
                Experience = 5,
                Salary = 2300
            },
            new Factory{
                Id= 12,
                Surname = "Ronan",
                DateOfBirth = new DateOnly(2005,04,29),
                Sex = "Female",
                WorkshopNum = 3,
                Position = "Cut-quality-controller",
                Experience = 1,
                Salary = 1350
            },
            new Factory{
                Id= 13,
                Surname = "Holland",
                DateOfBirth = new DateOnly(1980,05,24),
                Sex = "Female",
                WorkshopNum = 3,
                Position = "Manager",
                Experience = 4,
                Salary = 3650
            },
            new Factory{
                Id= 14,
                Surname = "O'Donnel",
                DateOfBirth = new DateOnly(2000,01,24),
                Sex = "Male",
                WorkshopNum = 2,
                Position = "Ironer",
                Experience = 2,
                Salary = 1550
            },
            new Factory{
                Id= 15,
                Surname = "O'Conner",
                DateOfBirth = new DateOnly(1962,02,24),
                Sex = "Female",
                WorkshopNum = 3,
                Position = "Cleaner",
                Experience = 2,
                Salary = 1300
            },
            new Factory{
                Id= 16,
                Surname = "Sloop",
                DateOfBirth = new DateOnly(1990,06,14),
                Sex = "Male",
                WorkshopNum = 2,
                Position = "Tailor",
                Experience = 3,
                Salary = 2400
            },
            new Factory{
                Id= 17,
                Surname = "Colly",
                DateOfBirth = new DateOnly(2005,06,14),
                Sex = "Male",
                WorkshopNum = 2,
                Position = "Cleaner",
                Experience = 0,
                Salary = 1000
            },
            new Factory{
                Id= 18,
                Surname = "Lory",
                DateOfBirth = new DateOnly(1970,06,02),
                Sex = "Female",
                WorkshopNum = 1,
                Position = "Cleaner",
                Experience = 2,
                Salary = 1200
            },
            new Factory{
                Id= 19,
                Surname = "Elizabeth",
                DateOfBirth = new DateOnly(1963,06,02),
                Sex = "Female",
                WorkshopNum = 2,
                Position = "Sewer",
                Experience = 3,
                Salary = 3000
            },
            new Factory{
                Id= 20,
                Surname = "Richel",
                DateOfBirth = new DateOnly(1996,09,12),
                Sex = "Female",
                WorkshopNum = 3,
                Position = "Operative",
                Experience = 1,
                Salary = 1150
            }
        };
        return empoyees;
    }

        public static List<Premium> GetPremiums(){
         List<Premium> premiums = new List<Premium>(){
            new Premium(){
                Code = 1,
                Bonus = 80,
                Date = new DateOnly(2023,03,21)
            },
            new Premium(){
                Code = 1,
                Bonus = 80,
                Date = new DateOnly(2023,05,31)
            },
            new Premium(){
                Code = 6,
                Bonus = 80,
                Date = new DateOnly(2023,03,21)
            },
            new Premium(){
                Code = 6,
                Bonus = 80,
                Date = new DateOnly(2023,05,31)
            },
            new Premium(){
                Code = 3,
                Bonus = 100,
                Date = new DateOnly(2023,03,21)
            },
            new Premium(){
                Code = 5,
                Bonus = 150,
                Date = new DateOnly(2022,06,22)
            },
            new Premium(){
                Code = 10,
                Bonus = 200,
                Date = new DateOnly(2022,06,05)
            },
            new Premium(){
                Code = 10,
                Bonus = 300,
                Date = new DateOnly(2022,03,30)
            },
            new Premium(){
                Code = 16,
                Bonus = 150,
                Date = new DateOnly(2021,04,11)
            },
            new Premium(){
                Code = 16,
                Bonus = 300,
                Date = new DateOnly(2021,07,23)
            },
            new Premium(){
                Code = 14,
                Bonus = 100,
                Date = new DateOnly(2023,08,25)
            },
            new Premium(){
                Code = 7,
                Bonus = 350,
                Date = new DateOnly(2021,08,09)
            },
            new Premium(){
                Code = 7,
                Bonus = 400,
                Date = new DateOnly(2021,10,09)
            },
            new Premium(){
                Code = 7,
                Bonus = 400,
                Date = new DateOnly(2023,01,25)
            },
            new Premium(){
                Code = 2,
                Bonus = 70,
                Date = new DateOnly(2023,04,15)
            },
            new Premium(){
                Code = 13,
                Bonus = 200,
                Date = new DateOnly(2021,02,28)
            },
            new Premium(){
                Code = 13,
                Bonus = 250,
                Date = new DateOnly(2022,04,01)
            },
            new Premium(){
                Code = 13,
                Bonus = 250,
                Date = new DateOnly(2023,05,11)
            },
            new Premium(){
                Code = 12,
                Bonus = 90,
                Date = new DateOnly(2023,07,30)
            },
            new Premium(){
                Code = 20,
                Bonus = 50,
                Date = new DateOnly(2023,03,30)
            },
            new Premium(){
                Code = 11,
                Bonus = 65,
                Date = new DateOnly(2019,02,10)
            }
         };
        return premiums;
    }
}