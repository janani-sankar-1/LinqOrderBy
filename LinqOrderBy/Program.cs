using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQexample
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }
        public string City { get; set; }
        public double Salary{ get; set; }
    }
    class Person
    {
        public string PersonName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){EmpID=101,EmpName="Henry",Job="Designer",City="Boston",Salary=20000},
                new Employee(){EmpID=102,EmpName="Jack",Job="Developer",City="NewYork",Salary=24000},
                new Employee(){EmpID=103,EmpName="Gabriel",Job="Analyst",City="NewDelhi",Salary=30000},
                new Employee(){EmpID=104,EmpName="William",Job="Manager",City="Tokyo",Salary=35000},
                new Employee(){EmpID=105,EmpName="Henry",Job="Manager",City="NewYork",Salary=25000}
            };

            //where

            IEnumerable<Employee> res = employees.Where(emp => emp.City == "NewYork");
            foreach (Employee item in res)
            {
                Console.WriteLine(item.EmpID + " " + item.EmpName + " " + item.Job + " " + item.City+","+item.Salary);
            }

            //orderBy

            //IOrderedEnumerable<Employee> sortedEmployees = employees.OrderByDescending(emp => emp.City);
            IOrderedEnumerable<Employee> sortedEmployees = employees.OrderBy(emp => emp.City);
            foreach(Employee item in sortedEmployees)
            {
                Console.WriteLine(item.EmpID + "," + item.EmpName + "," + item.Job + "," + item.City+","+item.Salary);
            }

            //IOrderedEnumerable<Employee> sortedEmployees = employees.OrderBy(emp => emp.City).ThenBy(emp=>emp.Job);
            //If both city are same then second priority will be given for job.

            //First
            //return exception when no matching value found
            Employee firstManager = employees.First(emp => emp.Job == "Manager");
            Console.WriteLine(firstManager.EmpID + "," + firstManager.EmpName);

            //Firstordefault
            //return null if no matching value found
            Employee firstManager2 = employees.FirstOrDefault(emp => emp.Job == "Clerk");
            if (firstManager2 != null)
            {
                Console.WriteLine(firstManager2.EmpID + "," + firstManager2.EmpName);
            }
            else
            {
                Console.WriteLine("not found");
            }

            //Last

            Employee lastManager = employees.Last(emp => emp.Job == "Manager");
            Console.WriteLine(lastManager.EmpID + "," + lastManager.EmpName);

            //LastOrDefault
            Employee lastManager2 = employees.LastOrDefault(emp => emp.Job == "Manager");
            if (lastManager2 != null)
            {
                Console.WriteLine(lastManager2.EmpID + "," + lastManager2.EmpName);
            }
            else
            {
                Console.WriteLine("not found");
            }

            //ElementAt

            Employee resultEmp = employees.Where(emp => emp.Job == "Manager").ElementAt(1);
            Console.WriteLine(resultEmp.EmpID + "," + resultEmp.EmpName);

            //ElementAtOrDefault

            Employee resultEmp2 = employees.Where(emp => emp.Job == "Manager").ElementAtOrDefault(1);
            if (resultEmp2 != null)
            {
                Console.WriteLine(resultEmp2.EmpID + "," + resultEmp2.EmpName);
            }
            else
            {
                Console.WriteLine("not found");
            }

            //Single
            //There should be only one matching element else raises exception
            Employee singleManager = employees.Single(emp => emp.EmpName == "Jack");
            Console.WriteLine(singleManager.EmpID + "," + singleManager.EmpName);

            //SingleOrDefault
            Employee singleManager2 = employees.SingleOrDefault(emp => emp.EmpName == "Jack");
            if (singleManager2 != null)
            {
                Console.WriteLine(singleManager2.EmpID + "," + singleManager2.EmpName);
            }
            else
            {
                Console.WriteLine("Not found");
            }

            //select
            List<Person> result = employees.Select(emp => new Person() { PersonName = emp.EmpName }).ToList();
            foreach(Person i in result)
            {
                Console.WriteLine(i.PersonName);
            }

            //Min,Max,Sum,Avg,Count

            double min = employees.Min(emp => emp.Salary);
            double max = employees.Max(emp => emp.Salary);
            double sum=employees.Sum(emp => emp.Salary);
            double avg = employees.Average(emp => emp.Salary);
            double cnt=employees.Count();
            Console.WriteLine("Min:" + min + "\nMax:" + max+"\nSum:"+sum+"\nAverage:"+avg+"\nCount:"+cnt);

            Console.ReadKey();
        }
    }
}

