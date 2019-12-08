using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject
{
    class Program
    {

        static void Main(string[] args)
        {
            //UserInterface.Start();
            var repo = new ProfessionistRepository();
            var allProf = repo.All();
            //var NameProf = repo.AllByLastname("e");
            foreach (var item in allProf)

            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            try
            {
                // repo1.DeleteByID(8);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            //Insert\\
            Professionists pro1 = new Professionists("Franconi", "Alessio", "Doctor", "1963/09/02", "12 Ave", "Los Angeles", "", "22334", 2, "344-3455324", "ale@doc.com", "2 Weeks", "2 Month");
            repo.InsertNewProfessionist(pro1);

            //Delete\\
            //repo.DeleteProfessionistByID(11);






            //var employees = repo.AllByLastname("e");

            // foreach (var item in employees)
            // {
            //     Console.WriteLine(item.FirstName + " " + item.LastName);
            // }

            // var repo1 = new EmployeeRepository();

            //throw = new DateTime(2003-10-17);
            // Employee emp = new Employee("Di Qualcuno", "Amico", "Super Esperto", "Mr.", new DateTime(1973, 07, 02), new DateTime(2003, 10, 17), "3456 Coventry House, Miner Rd.", "London", "NULL", "10005", "UK", "(71) 345-6789", 5);
            //repo1.InsertNewEmp(emp);



            // foreach (var item in allEmp)
            // {
            //     Console.WriteLine(item.FirstName + " " + item.LastName);
            // }
            // try
            // {
            //     // repo1.DeleteByID(8);
            // }
            // catch (Exception e)
            // {

            //     System.Console.WriteLine(e.Message);
            // }
            // var empByTitle = repo1.SearchByTitle("ceo");
            // foreach (var item in empByTitle)
            // {
            //     Console.WriteLine(item.Title + " " + item.FirstName + " " + item.LastName);
            // }
            
            //Insert\\
            // Professionists req1 = new Professionists("Franconi", "Alessio", "Doctor", "1963/09/02", "12 Ave", "Los Angeles", "", "22334", 2, "344-3455324", "ale@doc.com", "2 Weeks", "2 Month");
            // repo.InsertNewProfessionist(pro1);

        }
    }
}
