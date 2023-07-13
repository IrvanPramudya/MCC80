using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class ViewLocation
    {
        public void getall(List<Location> locations)
        {
            Console.WriteLine("ID||Address||Postal Code||City||Province||Country ID");
            foreach (Location location in locations)
            {
                getoutput(location);
            }
        }
        public int getbyid()
        {
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void getoutput(Location location)
        {
            {
                Console.WriteLine(
                location.Id + ")("
                + location.StreetAddress + ")("
                + location.PostalCode + ")("
                + location.City + ")("
                + location.StateProvince + ")("
                + location.CountryId + ")"
                );
            }

        }
        public int menu()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("MENU TABLE LOCATIONS");
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
        public Location create()
        {
            Console.Clear();

            Console.Write("Masukkan ID Location : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Alamat : ");
            string alamat = Console.ReadLine();
            Console.Write("Masukkan Kode Pos : ");
            string kodepos = Console.ReadLine();
            Console.Write("Masukkan Kota : ");
            string kota = Console.ReadLine();
            Console.Write("Masukkan Provinsi : ");
            string provinsi = Console.ReadLine();
            Console.Write("Masukkan Country ID : ");
            string countryid = Console.ReadLine();

            return new Location
            {
                Id = id,
                StreetAddress = alamat,
                PostalCode = kodepos,
                City = kota,
                StateProvince = provinsi,
                CountryId = countryid
            };
        }
        public Location edit()
        {
            Console.Clear();
            Console.Write("ID yang ingin di Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Alamat : ");
            string alamat = Console.ReadLine();
            Console.Write("Masukkan Kode Pos : ");
            string kodepos = Console.ReadLine();
            Console.Write("Masukkan Kota : ");
            string kota = Console.ReadLine();
            Console.Write("Masukkan Provinsi : ");
            string provinsi = Console.ReadLine();
            Console.Write("Masukkan Country ID : ");
            string countryid = Console.ReadLine();

            return new Location
            {
                Id = id,
                StreetAddress = alamat,
                PostalCode = kodepos,
                City = kota,
                StateProvince = provinsi,
                CountryId = countryid
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
