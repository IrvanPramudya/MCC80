using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class ViewHistory
    {
        public void getall(List<History> histories)
        {
            Console.WriteLine("Start Date " +
                            "||Employee ID|| " +
                            "||End Date|| " +
                            "||History ID|| " +
                            "||Job ID|| ");
            foreach (History history in histories)
            {
                getoutput(history);
            }
        }
        public int getbyid()
        {
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void getoutput(History history)
        {
            {
                Console.WriteLine(
                history.Start + ") (" +
                history.EmployeeId + "*) ("
                + history.End + "*) (" +
                history.DepartementId + ") ("+history.JobId+")" 

                );
            }

        }
        public int menu()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("MENU TABLE HISTORY");
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
        public History create()
        {
            Console.Clear();

            Console.Write("Masukkan Tanggal Mulai Bekerja : ");
            DateTime start = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Tanggal Selesai Bekerja : ");
            DateTime end = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Employee ID : ");
            int employee = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Departement ID : ");
            int departement = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Job ID : ");
            string job = Console.ReadLine(); ;

            return new History
            {
                Start = start,
                EmployeeId = employee,
                End = end,
                DepartementId = departement,
                JobId = job
            };
        }
        public History edit()
        {
            Console.Clear();
            Console.Write("ID yang ingin di Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Tanggal Mulai Bekerja : ");
            DateTime start = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Tanggal Selesai Bekerja : ");
            DateTime end = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Employee ID : ");
            int employee = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Departement ID : ");
            int departement = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Job ID : ");
            string job = Console.ReadLine(); ;

            return new History
            {
                Start = start,
                EmployeeId = employee,
                End = end,
                DepartementId = departement,
                JobId = job
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
