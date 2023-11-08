using System.Collections;
using System.Globalization;
using System.Linq;


class Program
{
    static List<Factory> allEmployees = Data.GetEmployees();
    static List<Premium> allPremiums = Data.GetPremiums();
    public static void Main(string[] args)
    {
        // GetNumOfPositionsWithPremium(); //TaskA

        // Array femaleEmpSurnames = GetFemEmpWithHighNetProfit(); //TaskB 
        
        GetNumOfEmpWithTwoBonusesDuringOneYear(); //TaskC
        

    }
    static void GetNumOfPositionsWithPremium() 
    {
        var numOfPositionsWithPremium = allPremiums
        .Join(allEmployees,
            premium => premium.Code,
            employee => employee.Id,
            (prem,emp) => new{
                emp.Id,
                emp.Surname,
                emp.Position,
                prem.Code,
                prem.Date,
                prem.Bonus
            }
        )
        .DistinctBy(emp => emp.Position)
        .Count();

        Console.WriteLine("Number of positions of employees with bonuses: " + numOfPositionsWithPremium);  
    }

    static Array GetFemEmpWithHighNetProfit(){
        double tax = 0.2;   //20% tax
        int retirementAge = 60;
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        var oldEmps = allEmployees
        .Where(emp => emp.DateOfBirth.AddYears(retirementAge) <= today)
        .Select(emp => emp); 

        var oldEmpsAvrSalary = oldEmps
        .Select(emp => emp.Salary)
        .Average();
        System.Console.WriteLine(oldEmpsAvrSalary);


        var femaleEmps = allEmployees
        .Where(femaleEmp =>  femaleEmp.Sex == "Female" )
        .GroupJoin(allPremiums,
        emp => emp.Id,
        prem => prem.Code,
        (e,prGroup) => new { e, prGroup })
        .Where(obj => obj.prGroup.Any())
        .Select(obj => new{
            obj.e,
            prGroup = obj.prGroup.OrderByDescending(prem => prem.Date) // newer dates first, then older ones
        })
        .Select(obj => new{
            obj.e,
            newerPrem = obj.prGroup.First()
        })
        .Select(obj => new{
            Id = obj.e.Id,
            Surname = obj.e.Surname,
            netProfit = (obj.e.Salary + obj.newerPrem.Bonus) * (1 - tax)  // (salary + bonus) * 80%  == (salary + bonus) - 20%
        });
       

        var result = femaleEmps
        .Where(femEmp => femEmp.netProfit > oldEmpsAvrSalary)
        .Select(femEmp =>  femEmp.Surname )
        .ToArray();

        Console.WriteLine("Female employees with high net profit:");
        foreach (var surname in result)
        {
            Console.WriteLine(surname);
        }
        
        return result;
    }

    static void GetNumOfEmpWithTwoBonusesDuringOneYear(){
        
        var groupedPremiums = allPremiums
        .GroupBy(prem => prem.Code)
        .Select(obj => new {     
            Key = obj.Key,      // premium.Code
            premGroup = obj     // group of premiums
        })
        .Select(obj => new {
            KeyCode = obj.Key,  // premium.Code
            prWithKeyGroup = obj.premGroup.GroupBy(pr => pr.Date.Year)   // group of objects which have Key(premium.Date.Year) and group of premiums
        });

        var empCodesWithTwoPrems = groupedPremiums
        .Select(
            obj =>  new {
                obj.KeyCode,
                prWithKeyGroup = obj.prWithKeyGroup.Where( prWithKey => prWithKey.Count() >= 2 )  
            }
        )
        .Where( obj => obj.prWithKeyGroup.Any())
        .Select(obj => new {
            empCode = obj.KeyCode
        }) ;

        var groupedEmps = allEmployees
        .GroupBy(emp => emp.WorkshopNum)
        .Select(obj => new{
            workshopNum = obj.Key,
            empGroup =  obj.Join(
                            empCodesWithTwoPrems,
                            emp => emp.Id,
                            codes => codes.empCode,
                            (e,code) => new{
                                e
                            }
                        ).Select(emp => emp.e)
        });

        var result = groupedEmps
        .Select(obj => new{
            obj.workshopNum,
            numOfEmps = obj.empGroup.Count()
        });

        foreach (var item in result)
        {
            Console.WriteLine("Workshop " + item.workshopNum);
                Console.WriteLine("   " + item.numOfEmps + " employee(s) received at least 2 bonuses within one year");
        }
        
    }
  

}
        
