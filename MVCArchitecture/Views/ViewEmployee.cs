using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class ViewEmployee
    {
        public void getall(List<Employee> employee)
        {
            Console.WriteLine("ID " +
                            "||First Name|| " +
                            "||Last Name|| " +
                            "||Email|| " +
                            "||Phone Number|| " +
                            "||Hire Date|| " +
                            "||Salary|| " +
                            "||Commision|| " +
                            "||Manager ID|| " +
                            "||Job ID|| " +
                            "||Departement ID||");
            foreach (Employee employees in employee)
            {
                getoutput(employees);
            }
        }
        public int getbyid()
        {
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void getoutput(Employee employee)
        {
            {
                Console.WriteLine(
                employee.Id + ") (" +
                employee.FirstName + "*) ("
                + employee.LastName + "*) " +
                "(" +employee.Email + ")" +
                "(" +employee.Phone + ")" +
                "(" +employee.Hire + ")"+
                "(" +employee.Salary + ")"+
                "(" +employee.Comission + ")"+
                "(" +employee.ManagerId + ")"+
                "(" +employee.JobId + ")"+
                "(" +employee.DepartementId + ")"
                );
            }

        }
        public int menu()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("MENU TABLE EMPLOYEE");
            Console.WriteLine("**************************");
            Console.WriteLine("1) CREATE");
            Console.WriteLine("2) UPDATE");
            Console.WriteLine("3) DELETE");
            Console.WriteLine("4) GET BY ID");
            Console.WriteLine("5) GET ALL");
            Console.WriteLine("6) EXIT");
            Console.Write("CHOOSE NUMBER : ");
            int choose = Convert.ToInt32(Console.ReadLine());

            return choose;
        }
        public Employee create()
        {
            Console.Clear();

            Console.Write("Masukkan ID Employee : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Depan Employee : ");
            string fn = Console.ReadLine();
            Console.Write("Masukkan Nama Belakang Employee : ");
            string ln = Console.ReadLine();
            Console.Write("Masukkan No Telepon Employee : ");
            string phone = Console.ReadLine();
            Console.Write("Masukkan Tanggal Berabung Employee : ");
            DateTime hire = Convert.ToDateTime(Console.ReadLine()) ;
            Console.Write("Masukkan Gaji Employee : ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Komisi Employee : ");
            decimal comission = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Masukkan ID Manager : ");
            int managerid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan ID Job : ");
            int job = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan ID Departemenet : ");
            int departement = Convert.ToInt32(Console.ReadLine());

            return new Employee
            {
                Id = id,
                FirstName = fn,
                LastName = ln,
                Phone = phone,
                Hire = hire,
                Salary = salary,
                Comission = comission,
                ManagerId = managerid,
                JobId = job,
                DepartementId = departement
            };
        }
        public Employee edit()
        {
            Console.Clear();
            Console.Write("ID yang ingin di Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            string fn = Console.ReadLine();
            Console.Write("Masukkan Nama Belakang Employee : ");
            string ln = Console.ReadLine();
            Console.Write("Masukkan No Telepon Employee : ");
            string phone = Console.ReadLine();
            Console.Write("Masukkan Tanggal Berabung Employee : ");
            DateTime hire = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Gaji Employee : ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Komisi Employee : ");
            decimal comission = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Masukkan ID Manager : ");
            int managerid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan ID Job : ");
            int job = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan ID Departemenet : ");
            int departement = Convert.ToInt32(Console.ReadLine());

            return new Employee
            {
                Id = id,
                FirstName = fn,
                LastName = ln,
                Phone = phone,
                Hire = hire,
                Salary = salary,
                Comission = comission,
                ManagerId = managerid,
                JobId = job,
                DepartementId = departement
            };
        }
        public int delete()
        {
            Console.Write("ID yang ingin di Hapus : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void isempty()
        {
            Console.WriteLine("Data is Empty");
        }
        public void success()
        {
            Console.WriteLine("*** Success ***");
        }
        public void failure()
        {
            Console.WriteLine("!!! Fail, ID not found !!!");
        }
        public void error()
        {
            Console.WriteLine("XXX-- Error retrieving from database --XXX");
        }
    }
}
