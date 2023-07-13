using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class ViewRegion
    {
        public void getall(List<Region> regions)
        {
            Console.WriteLine("ID\t Name");
            foreach (Region region in regions)
            {
                getoutput(region);
            }
        }
        public int getbyid()
        {
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void getoutput(Region region)
        {
            Console.WriteLine(
            region.Id + ")\t (" +
            region.Name+")"
            );
        }
        public int menu()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("MENU TABLE REGIONS");
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
        public Region create()
        {
            Console.Clear();
            Console.Write("Masukkan Nama Region : ");
            string nama = Console.ReadLine();

            return new Region
            {
                Id = 0,
                Name = nama,
            };
        }
        public Region edit()
        {
            Console.Clear();
            Console.Write("ID yang ingin di Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Region : ");
            string nama = Console.ReadLine();

            return new Region
            {
                Id = id,
                Name = nama,
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
