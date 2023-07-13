using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class ViewDepartement
    {
        public void getall(List<Departement> departements)
        {
            Console.WriteLine("ID||Name||Location ID||Manager ID");
            foreach (Departement departement in departements)
            {
                getoutput(departement);
            }
        }
        public int getbyid()
        {
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void getoutput(Departement departement)
        {
            {
                Console.WriteLine(
                departement.Id + ") (" +
                departement.Name + "*) (" 
                +departement.LocationId + "*) (" +
                departement.ManagerId + ")"
                );
            }

        }
        public int menu()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("MENU TABLE DEPARTEMENTS");
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
        public Departement create()
        {
            Console.Clear();

            Console.Write("Masukkan ID Departement : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Departement : ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan ID Location : ");
            int locationid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan ID Manager : ");
            int managerid = Convert.ToInt32(Console.ReadLine());

            return new Departement
            {
                Id = id,
                Name = nama,
                LocationId = locationid,
                ManagerId = managerid
            };
        }
        public Departement edit()
        {
            Console.Clear();
            Console.Write("ID yang ingin di Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Departement : ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan ID Location : ");
            int locationid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan ID Manager : ");
            int managerid = Convert.ToInt32(Console.ReadLine());

            return new Departement
            {
                Id = id,
                Name = nama,
                LocationId = locationid,
                ManagerId = managerid
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
