using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class ViewCountry
    {
        public void getall(List<Country> countries)
        {
            Console.WriteLine("ID\tName\t\tRegion ID");
            foreach (Country country in countries)
            {
                getoutput(country);
            }
        }
        public int getbyid()
        {
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void getoutput(Country country)
        {
            {
                Console.WriteLine(
                country.Id + ")\t(" +
                country.Name + "*)\t(" +
                country.RegionId + ")"
                );
            }
            
        }
        public int menu()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("MENU TABLE COUNTRY");
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
        public Country create()
        {
            Console.Clear();

            Console.Write("Masukkan ID Country : ");
            string id = Console.ReadLine();
            Console.Write("Masukkan Nama Country : ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan ID Region : ");
            int regionid = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                Id = id,
                Name = nama,
                RegionId = regionid
            };
        }
        public Country edit()
        {
            Console.Clear();
            Console.Write("ID yang ingin di Update : ");
            string id = Console.ReadLine();
            Console.Write("Masukkan Nama Country : ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan ID Region : ");
            int regionid = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                Id = id,
                Name = nama,
                RegionId = regionid
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
