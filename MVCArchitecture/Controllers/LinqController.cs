using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    internal class LinqController
    {
        private Employee _employee; 
        private Departement _departement; 
        private Location _location; 
        private Country _country; 
        private Region _region;
        private Job _job;

        public LinqController(Employee employee, Departement departement, Location location, Country country, Region region, Job job)
        {
            _employee = employee;
            _departement = departement;
            _location = location;
            _country = country;
            _region = region;
            _job = job;
        }
        public void employeeadvance()
        {
            var getemployee = _employee.getall();
            var getdepartement = _departement.getall();
            var getlocation = _location.getall();
            var getcountry = _country.getall();
            var getregion = _region.getall();

            var queryemployee = (from e in getemployee
                                 join d in getdepartement on e.DepartementId equals d.Id
                                 join l in getlocation on d.LocationId equals l.Id
                                 join c in getcountry on l.CountryId equals c.Id
                                 join r in getregion on c.RegionId equals r.Id
                                 select new 
                                 { 
                                     Id = e.Id,
                                     fullname = e.FirstName +" " + e.LastName,
                                     email = e.Email,
                                     phone = e.Phone,
                                     salary = e.Salary,
                                     departement = d.Name,
                                     address = l.StreetAddress,
                                     country = c.Name,
                                     region = r.Name
                                 }).ToList();

            foreach(var employee in queryemployee)
            {
                Console.WriteLine("ID\t\t = "+ employee.Id);
                Console.WriteLine("Fullname\t = "+ employee.fullname);
                Console.WriteLine("Email\t\t = "+ employee.email);
                Console.WriteLine("Phone\t\t = "+ employee.phone);
                Console.WriteLine("Salary\t\t = "+ employee.salary);
                Console.WriteLine("Departement\t = "+ employee.departement);
                Console.WriteLine("Address\t\t = "+ employee.address);
                Console.WriteLine("Country\t\t = "+ employee.country);
                Console.WriteLine("Region\t\t = "+ employee.region);
                Console.WriteLine("===============================");

            }
        }
        public void countemployeeperdepart()
        {
            var getemployee = _employee.getall();
            var getdepartement = _departement.getall();
            var getjob = _job.getall();

            getemployee.Count(getemployee,

            var countemployee = (from e in getemployee
                                 join d in getdepartement on e.DepartementId equals d.Id
                                 join j in getjob on e.JobId equals j.Id group d.Name
                                 select new
                                 {
                                     departement = d.Name,
                                 }).ToList();

            foreach (var print  in countemployee)
            {
                Console.WriteLine("Departement Name : "+print.departement);
                Console.WriteLine("Total Employee : "+print.employee);
            }
        }
    }
}
