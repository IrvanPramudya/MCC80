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

        public LinqController(Employee employee, Departement departement, Location location, Country country, Region region)
        {
            _employee = employee;
            _departement = departement;
            _location = location;
            _country = country;
            _region = region;
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
                Console.WriteLine();
                Console.WriteLine(employee.Id + " " + employee.fullname + " " + employee.email + " "
                    + employee.phone + " " + employee.salary + " " + employee.departement + " " + employee.address
                    + " " + employee.country + " " + employee.region);


            }
        }
    }
}
