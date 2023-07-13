using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class ViewJob
    {
        public void getall(List<Job> jobs)
        {
            Console.WriteLine("ID " +
                            "||title|| " +
                            "||Minimal Salary|| " +
                            "||Maximal Salary|| ");
            foreach (Job job in jobs)
            {
                getoutput(job);
            }
        }
        public int getbyid()
        {
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void getoutput(Job job)
        {
            {
                Console.WriteLine(
                job.Id + ") (" +
                job.Title + "*) ("
                + job.MinSalary + "*) (" +
                job.MaxSalary + ")"

                );
            }

        }
        public int menu()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("MENU TABLE JOB");
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
        public Job create()
        {
            Console.Clear();

            Console.Write("Masukkan Job ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Pekerjaan : ");
            string job = Console.ReadLine();
            Console.Write("Masukkan Minimal Gaji : ");
            int mingaji = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Maksimal Gaji : ");
            int maxgaji = Convert.ToInt32(Console.ReadLine());

            return new Job
            {
                Id = id,
                Title = job,
                MinSalary = mingaji,
                MaxSalary = maxgaji
            };
        }
        public Job edit()
        {
            Console.Clear();
            Console.Write("ID yang ingin di Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Pekerjaan : ");
            string job = Console.ReadLine();
            Console.Write("Masukkan Minimal Gaji : ");
            int mingaji = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Maksimal Gaji : ");
            int maxgaji = Convert.ToInt32(Console.ReadLine());

            return new Job
            {
                Id = id,
                Title = job,
                MinSalary = mingaji,
                MaxSalary = maxgaji
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
