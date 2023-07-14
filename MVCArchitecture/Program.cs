using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu();
        }
        public static void menu()
        {
            bool exit = false;


            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("**************************");
                Console.WriteLine("MENU DATABASE TABLE");
                Console.WriteLine("**************************");
                Console.WriteLine("1) REGIONS");
                Console.WriteLine("2) COUNTRIES");
                Console.WriteLine("3) LOCATIONS");
                Console.WriteLine("4) DEPARTEMENTS");
                Console.WriteLine("5) EMPLOYEES");
                Console.WriteLine("6) HISTORIES");
                Console.WriteLine("7) JOBS");
                Console.WriteLine("8) LINQ");
                Console.WriteLine("9) EXIT");
                Console.WriteLine("**************************");
                Console.Write("INPUT A NUMBER : ");
                int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Regionmenu();
                        break;
                    case 2:
                        Countrymenu();
                        break;
                    case 3:
                        Locationmenu();
                        break;
                    case 4:
                        Departementmenu();
                        break;
                    case 5:
                        Employeemenu();
                        break;
                    case 6:
                        Historymenu();
                        break;
                    case 7:
                        Jobmenu();
                        break;
                    case 8:
                        menulinq();
                        break;
                    case 9:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("MENU DOES NOT EXIST");
                        break;
                }

            }
        }
        public static void Regionmenu()
        {
            Region model = new Region();
            ViewRegion view = new ViewRegion(); 
            RegionController controller = new RegionController(model,view);

            bool exit = false;
            while (!exit)
            {
                int pilih = view.menu();
                switch(pilih)
                {
                    case 1:
                        controller.insert();
                        pressanykey();
                        break;
                    case 2:
                        controller.update();
                        pressanykey();
                        break;
                    case 3:
                        controller.delete();
                        pressanykey();
                        break;
                    case 4:
                        controller.getbyid();
                        pressanykey();
                        break;
                    case 5:
                        controller.getall();
                        pressanykey();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input !!!");
                        break;
                }
            }
        }
        public static void Countrymenu()
        {
            Country model = new Country();
            ViewCountry view = new ViewCountry();
            CountryController controller = new CountryController(model, view);

            bool exit = false;
            while (!exit)
            {
                int pilih = view.menu();
                switch (pilih)
                {
                    case 1:
                        controller.insert();
                        pressanykey();
                        break;
                    case 2:
                        controller.update();
                        pressanykey();
                        break;
                    case 3:
                        controller.delete();
                        pressanykey();
                        break;
                    case 4:
                        controller.getbyid();
                        pressanykey();
                        break;
                    case 5:
                        controller.getall();
                        pressanykey();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input !!!");
                        break;
                }
            }
        }
        public static void Locationmenu()
        {
            Location model = new Location();
            ViewLocation view = new ViewLocation();
            LocationController controller = new LocationController(model, view);

            bool exit = false;
            while (!exit)
            {
                int pilih = view.menu();
                switch (pilih)
                {
                    case 1:
                        controller.insert();
                        pressanykey();
                        break;
                    case 2:
                        controller.update();
                        pressanykey();
                        break;
                    case 3:
                        controller.delete();
                        pressanykey();
                        break;
                    case 4:
                        controller.getbyid();
                        pressanykey();
                        break;
                    case 5:
                        controller.getall();
                        pressanykey();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input !!!");
                        break;
                }
            }
        }
        public static void Departementmenu()
        {
            Departement model = new Departement();
            ViewDepartement view = new ViewDepartement();
            DepartementController controller = new DepartementController(model, view);

            bool exit = false;
            while (!exit)
            {
                int pilih = view.menu();
                switch (pilih)
                {
                    case 1:
                        controller.insert();
                        pressanykey();
                        break;
                    case 2:
                        controller.update();
                        pressanykey();
                        break;
                    case 3:
                        controller.delete();
                        pressanykey();
                        break;
                    case 4:
                        controller.getbyid();
                        pressanykey();
                        break;
                    case 5:
                        controller.getall();
                        pressanykey();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input !!!");
                        break;
                }
            }
        }
        public static void Employeemenu()
        {
            Employee model = new Employee();
            ViewEmployee view = new ViewEmployee();
            EmployeeController controller = new EmployeeController(model, view);

            bool exit = false;
            while (!exit)
            {
                int pilih = view.menu();
                switch (pilih)
                {
                    case 1:
                        controller.insert();
                        pressanykey();
                        break;
                    case 2:
                        controller.update();
                        pressanykey();
                        break;
                    case 3:
                        controller.delete();
                        pressanykey();
                        break;
                    case 4:
                        controller.getbyid();
                        pressanykey();
                        break;
                    case 5:
                        controller.getall();
                        pressanykey();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input !!!");
                        break;
                }
            }
        }
        public static void Historymenu()
        {
            History model = new History();
            ViewHistory view = new ViewHistory();
            HistoryController controller = new HistoryController(model, view);

            bool exit = false;
            while (!exit)
            {
                int pilih = view.menu();
                switch (pilih)
                {
                    case 1:
                        controller.insert();
                        pressanykey();
                        break;
                    case 2:
                        controller.update();
                        pressanykey();
                        break;
                    case 3:
                        controller.delete();
                        pressanykey();
                        break;
                    case 4:
                        controller.getbyid();
                        pressanykey();
                        break;
                    case 5:
                        controller.getall();
                        pressanykey();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input !!!");
                        break;
                }
            }
        }
        public static void Jobmenu()
        {
            Job model = new Job();
            ViewJob view = new ViewJob();
            JobController controller = new JobController(model, view);

            bool exit = false;
            while (!exit)
            {
                int pilih = view.menu();
                switch (pilih)
                {
                    case 1:
                        controller.insert();
                        pressanykey();
                        break;
                    case 2:
                        controller.update();
                        pressanykey();
                        break;
                    case 3:
                        controller.delete();
                        pressanykey();
                        break;
                    case 4:
                        controller.getbyid();
                        pressanykey();
                        break;
                    case 5:
                        controller.getall();
                        pressanykey();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input !!!");
                        break;
                }
            }
        }
        public static void menulinq()
        {
            var employee = new Employee();
            var departement = new Departement();
            var location = new Location();
            var country = new Country();
            var region = new Region();

            var linq = new LinqController(employee,departement, location, country, region);

            linq.employeeadvance();
            pressanykey();
        }
        public static void pressanykey() 
        {
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();

        }
    }
}
