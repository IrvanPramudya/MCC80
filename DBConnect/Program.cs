using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Data;
using System.Security.Policy;

namespace DBConnect
{
    internal class Program
    {
        private static string _connectionString = 
            "Server=ASUS-GL552;" + //bisa menggunakan Server
            "Database=kantor;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;";
        private static SqlConnection _conn;
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
                Console.WriteLine("8) EXIT");
                Console.WriteLine("**************************");
                Console.Write("INPUT A NUMBER : ");
                int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        string table_regions = "regions";
                        menutable(table_regions.ToUpper());
                        break;
                    case 2:
                        string table_countries = "countries";
                        menutable(table_countries.ToUpper());
                        break;
                    case 3:
                        string table_locations = "locations";
                        menutable(table_locations.ToUpper());
                        break;
                    case 4:
                        string table_departements = "departements";
                        menutable(table_departements.ToUpper());
                        break;
                    case 5:
                        string table_employees = "employees";
                        menutable(table_employees.ToUpper());
                        break;
                    case 6:
                        string table_histories = "histories";
                        menutable(table_histories.ToUpper());
                        break;
                    case 7:
                        string table_jobs = "jobs";
                        menutable(table_jobs.ToUpper());
                        break;
                    case 8:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("MENU DOES NOT EXIST");
                        break;
                }
                
            }
        }
        public static void menutable(string table)
        {
            bool exit_menu_table = false;
            while (!exit_menu_table) 
            {
                Console.Clear();
                Console.WriteLine("**************************");
                Console.WriteLine("MENU TABLE " + table);
                Console.WriteLine("**************************");
                Console.WriteLine("1) CREATE");
                Console.WriteLine("2) UPDATE");
                Console.WriteLine("3) DELETE");
                Console.WriteLine("4) GET BY ID");
                Console.WriteLine("5) GET ALL");
                Console.WriteLine("6) EXIT");
                Console.Write("CHOOSE NUMBER : ");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
//----------------------------------------------------------CREATE TABLE VALUE--------------------------------------
                    case 1:
//----------------------------------------------------------CREATE TABLE REGIONS--------------------------------------
                        if (table == "REGIONS") 
                        {
                            while (true)
                            {
                                Console.Write("INSERT REGIONS NAME : ");
                                string insert_regions = Console.ReadLine();
                                if (insert_regions == "" || insert_regions == " ")
                                {
                                    Console.WriteLine("PLEASE INPUT VALID REGIONS");
                                }
                                else
                                {
                                    insertregions(insert_regions);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------CREATE TABLE COUNTRIES--------------------------------------
                        else if (table == "COUNTRIES")
                        {
                            while (true)
                            {
                                Console.Write("INSERT COUNTRIES ID : ");
                                int countries_id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT COUNTRIES NAME : ");
                                string insert_countries = Console.ReadLine();
                                Console.Write("INSERT REGION ID : ");
                                int region_id = Convert.ToInt32(Console.ReadLine());
                                if (insert_countries == "" || insert_countries == " ")
                                {
                                    Console.WriteLine("PLEASE INPUT VALID COUNTRIES");
                                }
                                else
                                {
                                    insertcountries(countries_id,insert_countries,region_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------CREATE TABLE LOCATIONS--------------------------------------
                        else if (table == "LOCATIONS")
                        {
                            while (true)
                            {
                                Console.Write("INSERT LOCATIONS ID : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT ADDRESS NAME : ");
                                string insert_address = Console.ReadLine();
                                Console.Write("INSERT POSTAL CODE : ");
                                string postal_code = Console.ReadLine();
                                Console.Write("INSERT CITY NAME : ");
                                string city = Console.ReadLine();
                                Console.Write("INSERT PROVINCE NAME : ");
                                string province = Console.ReadLine();
                                Console.Write("INSERT COUNTRY ID : ");
                                int country_id = Convert.ToInt32(Console.ReadLine());
                                    insertlocations(id,insert_address,postal_code,city,province,country_id);
                                    break;
                            }
                        }
//----------------------------------------------------------CREATE TABLE DEPARTEMENTS--------------------------------------
                        else if (table == "DEPARTEMENTS") //-----------------------------------------------------------------
                        {
                            while (true)
                            {
                                Console.Write("INSERT DEPARTEMENTS ID : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT DEPARTEMENTS NAME : ");
                                string name = Console.ReadLine();
                                Console.Write("INSERT LOCATIONS ID : ");
                                int locationid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT MANAGER ID : ");
                                int managerid = Convert.ToInt32(Console.ReadLine());
                                insertdepartements(id,name,locationid,managerid);
                                    break;
                            }
                        }
//----------------------------------------------------------CREATE TABLE EMPLOYEES--------------------------------------
                        else if (table == "EMPLOYEES")
                        {
                            while (true)
                            {
                                Console.Write("INSERT EMPLOYEES ID : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT EMPLOYEES FIRST NAME : ");
                                string fn = Console.ReadLine();
                                Console.Write("INSERT EMPLOYEES LAST NAME : ");
                                string ln = Console.ReadLine();
                                Console.Write("INSERT EMPLOYEES EMAIL : ");
                                string email = Console.ReadLine();
                                Console.Write("INSERT EMPLOYEES PHONE : ");
                                string phone = Console.ReadLine();
                                Console.Write("INSERT EMPLOYEES HIRE DATE : ");
                                DateTime hire = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("INSERT EMPLOYEES SALARY : ");
                                int salary = Convert.ToInt32( Console.ReadLine());
                                Console.Write("INSERT EMPLOYEES COMMISION : ");
                                decimal commision = Convert.ToDecimal( Console.ReadLine());
                                Console.Write("INSERT EMPLOYEES MANAGER ID : ");
                                int managerid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT EMPLOYEES JOB ID : ");
                                int jobid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT EMPLOYEES DEPARTEMENT ID : ");
                                int departementid = Convert.ToInt32(Console.ReadLine());
                                insertemployees(id,fn,ln,email,phone,hire,salary,commision,managerid,jobid,departementid);
                                    break;
                            }
                        }
//----------------------------------------------------------CREATE TABLE JOBS--------------------------------------
                        else if (table == "JOBS") //-----------------------------------------------------------------
                        {
                            while (true)
                            {
                                Console.Write("INSERT JOBS ID : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT JOBS TITLE : ");
                                string title = Console.ReadLine();
                                Console.Write("INSERT JOBS MIN SALARY : ");
                                int min = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT JOBS MAX SALARY : ");
                                int max = Convert.ToInt32(Console.ReadLine());
                                insertjobs(id,title,min,max);
                                    break;
                            }
                        }
//----------------------------------------------------------CREATE TABLE HISTORIES--------------------------------------
                        else if (table == "HISTORIES") //-----------------------------------------------------------------
                        {
                            while (true)
                            {
                                Console.Write("INSERT HISTORIES START DATE : ");
                                DateTime start = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("INSERT HISTORIES END DATE : ");
                                DateTime end = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("INSERT HISTORIES EMPLOYEE ID : ");
                                int employeeid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT HISTORIES JOB ID : ");
                                int jobid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("INSERT HISTORIES DEPARTEMENT ID : ");
                                int departementid = Convert.ToInt32(Console.ReadLine());
                                inserthistories(start,employeeid,end,jobid,departementid);
                                    break;
                            }
                        }
                        Console.ReadLine();
                        break;
//----------------------------------------------------------END OF CREATE TABLE VALUE--------------------------------------
//----------------------------------------------------------UPDATE TABLE VALUE--------------------------------------
                    case 2:
//----------------------------------------------------------UPDATE TABLE REGIONS--------------------------------------
                        if (table == "REGIONS")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("***********TABLE REGIONS***********");
                                getregions();
                                Console.WriteLine("***********************************");
                                Console.Write("ENTER ID YOU WANNA UPDATE : ");
                                int update_id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nUPDATE REGIONS NAME : ");
                                string update_region = Console.ReadLine();
                                if (update_region == "" || update_region == " ")
                                {
                                    Console.WriteLine("PLEASE INPUT VALID REGIONS");
                                }
                                else
                                {
                                    updateregion(update_id,update_region);
                                    Console.ReadLine();
                                    Console.Clear();
                                    getregionbyid(update_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------UPDATE TABLE COUNTRIES--------------------------------------
                        if (table == "COUNTRIES")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("***********TABLE COUNTRIES***********");
                                getcountries();
                                Console.WriteLine("*************************************");
                                Console.Write("ENTER ID YOU WANNA UPDATE : ");
                                int update_id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE COUNTRIES NAME : ");
                                string update_countries = Console.ReadLine();
                                Console.Write("UPDATE REGION ID : ");
                                int region_id = Convert.ToInt32(Console.ReadLine());
                                if (update_countries == "" || update_countries == " ")
                                {
                                    Console.WriteLine("PLEASE INPUT VALID COUNTRIES");
                                }
                                else
                                {
                                    updatecountries(update_id,update_countries,region_id);
                                    Console.ReadLine();
                                    Console.Clear();
                                    getcountriesbyid(update_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------UPDATE TABLE LOCATIONS--------------------------------------
                        if (table == "LOCATIONS")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("***********TABLE LOCATIONS***********");
                                getlocations();
                                Console.WriteLine("*************************************");
                                Console.Write("UPDATE LOCATIONS ID : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE ADDRESS NAME : ");
                                string address = Console.ReadLine();
                                Console.Write("UPDATE POSTAL CODE : ");
                                string postal_code = Console.ReadLine();
                                Console.Write("UPDATE CITY NAME : ");
                                string city = Console.ReadLine();
                                Console.Write("UPDATE PROVINCE NAME : ");
                                string province = Console.ReadLine();
                                Console.Write("UPDATE COUNTRY ID : ");
                                int country_id = Convert.ToInt32(Console.ReadLine());
                                updatelocations(id, address, postal_code, city, province, country_id);
                                Console.ReadLine();
                                Console.Clear() ;
                                getlocationsbyid(id);
                                break;
                            }
                        }
//----------------------------------------------------------UPDATE TABLE DEPARTEMENS--------------------------------------
                        if (table == "DEPARTEMENTS")//-----------------------------------------------------------------
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("***********TABLE DEPARTEMENTS***********");
                                getdepartements();
                                Console.WriteLine("****************************************");
                                Console.Write("UPDATE DEPARTEMENTS ID : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE DEPARTEMENTS NAME : ");
                                string name = Console.ReadLine();
                                Console.Write("UPDATE LOCATIONS ID : ");
                                int locationid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE MANAGER ID : ");
                                int managerid = Convert.ToInt32(Console.ReadLine());
                                updatedepartements(id, name, locationid, managerid);
                                Console.ReadLine();
                                Console.Clear();
                                getdepartementsbyid(id);
                                break;
                            }
                        }
//----------------------------------------------------------UPDATE TABLE EMPLOYEES--------------------------------------
                        if (table == "EMPLOYEES")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("***********TABLE EMPLOYEES***********");
                                getemployees();
                                Console.WriteLine("*************************************");
                                Console.Write("UPDATE EMPLOYEES ID : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE EMPLOYEES FIRST NAME : ");
                                string fn = Console.ReadLine();
                                Console.Write("UPDATE EMPLOYEES LAST NAME : ");
                                string ln = Console.ReadLine();
                                Console.Write("UPDATE EMPLOYEES EMAIL : ");
                                string email = Console.ReadLine();
                                Console.Write("UPDATE EMPLOYEES PHONE : ");
                                string phone = Console.ReadLine();
                                Console.Write("UPDATE EMPLOYEES HIRE DATE : ");
                                DateTime hire = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("UPDATE EMPLOYEES SALARY : ");
                                int salary = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE EMPLOYEES COMMISION : ");
                                decimal commision = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("UPDATE EMPLOYEES MANAGER ID : ");
                                int managerid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE EMPLOYEES JOB ID : ");
                                int jobid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE EMPLOYEES DEPARTEMENT ID : ");
                                int departementid = Convert.ToInt32(Console.ReadLine());
                                updateemployees(id, fn, ln, email, phone, hire, salary, commision, managerid, jobid, departementid);
                                Console.ReadLine();
                                Console.Clear();
                                getemployeesbyid(id);
                                break;
                            }
                        }
//----------------------------------------------------------UPDATE TABLE HISTORIES--------------------------------------
                        if (table == "HISTORIES")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("***********TABLE HISTORIES***********");
                                gethistories();
                                Console.WriteLine("*************************************");
                                Console.Write("UPDATE HISTORIES START DATE : ");
                                DateTime start = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("UPDATE HISTORIES END DATE : ");
                                DateTime end = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("UPDATE HISTORIES EMPLOYEE ID : ");
                                int employeeid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE HISTORIES JOB ID : ");
                                int jobid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE HISTORIES DEPARTEMENT ID : ");
                                int departementid = Convert.ToInt32(Console.ReadLine());
                                updatehistories(start, employeeid, end, jobid, departementid);
                                Console.ReadLine();
                                Console.Clear();
                                gethistoriesbyid(employeeid);
                                break;
                            }
                        }
//----------------------------------------------------------UPDATE TABLE JOBS----------------------------------------
                        if (table == "JOBS")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("***********TABLE JOBS*************");
                                getjobs();
                                Console.WriteLine("***********************************");
                                Console.Write("UPDATE JOBS ID : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE JOBS TITLE : ");
                                string title = Console.ReadLine();
                                Console.Write("UPDATE JOBS MIN SALARY : ");
                                int min = Convert.ToInt32(Console.ReadLine());
                                Console.Write("UPDATE JOBS MAX SALARY : ");
                                int max = Convert.ToInt32(Console.ReadLine());
                                updatejobs(id, title, min, max);
                                Console.ReadLine();
                                Console.Clear();
                                getjobsbyid(id);
                                break;
                            }
                        }
                        Console.ReadLine();
                        break;
//----------------------------------------------------------END OF UPDATE TABLE--------------------------------------
//----------------------------------------------------------DELETE TABLE VALUES--------------------------------------
                    case 3:
//----------------------------------------------------------DELETE TABLE REGIONS--------------------------------------
                        if (table == "REGIONS")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA DELETE : ");
                                int delete_id = Convert.ToInt32(Console.ReadLine());
                                if (delete_id <= 0 )
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    deleteregion(delete_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------DELETE TABLE COUNTRIES--------------------------------------
                        else if (table == "COUNTRIES")//-----------------------------------------------------------------
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA DELETE : ");
                                int delete_id = Convert.ToInt32(Console.ReadLine());
                                if (delete_id <= 0 )
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    deletecountries(delete_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------DELETE TABLE LOCATIONS--------------------------------------
                        else if (table == "LOCATIONS")//-----------------------------------------------------------------
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA DELETE : ");
                                int delete_id = Convert.ToInt32(Console.ReadLine());
                                if (delete_id <= 0 )
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    deletelocations(delete_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------DELETE TABLE DEPARTEMENTS--------------------------------------
                        else if (table == "DEPARTEMENTS")//-----------------------------------------------------------------
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA DELETE : ");
                                int delete_id = Convert.ToInt32(Console.ReadLine());
                                if (delete_id <= 0 )
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    deletedepartements(delete_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------DELETE TABLE EMPLOYEES--------------------------------------
                        else if (table == "EMPLOYEES")//-----------------------------------------------------------------
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA DELETE : ");
                                int delete_id = Convert.ToInt32(Console.ReadLine());
                                if (delete_id <= 0 )
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    deleteemployees(delete_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------DELETE TABLE HISTORIES--------------------------------------
                        else if (table == "HISTORIES")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA DELETE : ");
                                int delete_id = Convert.ToInt32(Console.ReadLine());
                                if (delete_id <= 0 )
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    deletehistories(delete_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------DELETE TABLE JOBS--------------------------------------
                        else if (table == "JOBS")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA DELETE : ");
                                int delete_id = Convert.ToInt32(Console.ReadLine());
                                if (delete_id <= 0 )
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    deletejobs(delete_id);
                                    break;
                                }
                            }
                        }
                        Console.ReadLine();
                        break;
//----------------------------------------------------------END OF DELETE TABLE VALUES--------------------------------------
//----------------------------------------------------------GET BY ID TABLE VALUES--------------------------------------
                    case 4:
//----------------------------------------------------------GET BY ID TABLE REGIONS--------------------------------------
                        if (table == "REGIONS")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA CHECK : ");
                                int get_id = Convert.ToInt32(Console.ReadLine());
                                if (get_id <= 0)
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    getregionbyid(get_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------GET BY ID TABLE COUNTRIES--------------------------------------
                        if (table == "COUNTRIES")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA CHECK : ");
                                int get_id = Convert.ToInt32(Console.ReadLine());
                                if (get_id <= 0)
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    getcountriesbyid(get_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------GET BY ID TABLE DEPARTEMENTS--------------------------------------
                        if (table == "DEPARTEMENTS")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA CHECK : ");
                                int get_id = Convert.ToInt32(Console.ReadLine());
                                if (get_id <= 0)
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    getdepartementsbyid(get_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------GET BY ID TABLE LOCATIONS--------------------------------------
                        if (table == "LOCATIONS")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA CHECK : ");
                                int get_id = Convert.ToInt32(Console.ReadLine());
                                if (get_id <= 0)
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    getlocationsbyid(get_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------GET BY ID TABLE EMPLOYEES--------------------------------------
                        if (table == "EMPLOYEES")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA CHECK : ");
                                int get_id = Convert.ToInt32(Console.ReadLine());
                                if (get_id <= 0)
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    getemployeesbyid(get_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------GET BY ID TABLE HISTORIES--------------------------------------
                        if (table == "HISTORIES")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA CHECK : ");
                                int get_id = Convert.ToInt32(Console.ReadLine());
                                if (get_id <= 0)
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    gethistoriesbyid(get_id);
                                    break;
                                }
                            }
                        }
//----------------------------------------------------------GET BY ID TABLE JOBS--------------------------------------
                        if (table == "JOBS")
                        {
                            while (true)
                            {
                                Console.Write("ENTER ID YOU WANNA CHECK : ");
                                int get_id = Convert.ToInt32(Console.ReadLine());
                                if (get_id <= 0)
                                {
                                    Console.WriteLine("PLEASE INPUT VALID ID");
                                }
                                else
                                {
                                    getjobsbyid(get_id);
                                    break;
                                }
                            }
                        }
                        Console.ReadLine();
                        break;
//----------------------------------------------------------END OF GET BY ID TABLE VALUES--------------------------------------
//----------------------------------------------------------GET ALL ID TABLE VALUES--------------------------------------
                    case 5:
//----------------------------------------------------------GET ALL ID TABLE REGIONS--------------------------------------
                        if (table == "REGIONS")
                        {
                            getregions();
                        }
                        //----------------------------------------------------------GET ALL ID TABLE COUNTRIES--------------------------------------
                        else if (table == "COUNTRIES")
                        {
                            getcountries();
                        }
//----------------------------------------------------------GET ALL ID TABLE LOCATIONS--------------------------------------
                        else if (table == "LOCATIONS")
                        {
                            getlocations();
                        }
//----------------------------------------------------------GET ALL ID TABLE DEPARTEMENTS--------------------------------------
                        else if (table == "DEPARTEMENTS")
                        {
                            getdepartements();
                        }
//----------------------------------------------------------GET ALL ID TABLE EMPLOYEES--------------------------------------
                        else if (table == "EMPLOYEES")
                        {
                            getemployees();
                        }
//----------------------------------------------------------GET ALL ID TABLE HISTORIES--------------------------------------
                        else if (table == "HISTORIES")
                        {
                            gethistories();
                        }
//----------------------------------------------------------GET ALL ID TABLE JOBS--------------------------------------
                        else if (table == "JOBS")
                        {
                            getjobs();
                        }
                        Console.ReadLine();
                        break;
//----------------------------------------------------------BACK TO TABLE MENU--------------------------------------
                    case 6:
                        exit_menu_table = true;
                        break;
                    default:
                        Console.WriteLine("MENU DOES NOT EXIST");
                        break;

                }
            }
            
        }
//----------------------------------------------------------TABLE REGIONS-------------------------------------------
//----------------------------------------------------------GET ALL TABLE REGIONS-------------------------------------------
        public static void getregions()
        {
            _conn = new SqlConnection( _connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from regions";

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if(reader.HasRows) 
                    {
                        Console.WriteLine("ID\t Name");
                        while (reader.Read()) 
                        {
                            Console.WriteLine(
                                reader.GetInt32(0)+")\t "+
                                reader.GetString(1)
                                );
                            /*Console.WriteLine("Name\t\t = ");*/
                            /*Console.WriteLine("============================");*/
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data regions");
                    }
                    reader.Close();
                }
                /*using SqlDataReader reader = sqlCommand.ExecuteReader(); Jika menggunakan versi C# terbaru
                if(reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        Console.WriteLine("ID\t\t = "+reader.GetInt32(0));
                        Console.WriteLine("Name\t = "+reader.GetString(1));
                        Console.WriteLine("============================");
                    }
                }
                else
                {
                    Console.WriteLine("Tidak ada data regions");
                }
                reader.Close();*/
            }
            catch 
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                 _conn.Close(); }
        }
//----------------------------------------------------------INSERT TABLE REGIONS-------------------------------------------
        public static void insertregions(string region) 
        {
            _conn = new SqlConnection( _connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "insert into regions values (@region)";
            //sqlCommand.CommandText = "insert into regions values (?,?)";
            //sqlCommand.Parameters.AddWithValue(region)


                _conn.Open();
                SqlTransaction transaction = _conn.BeginTransaction();
                sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pRegions = new SqlParameter();
                pRegions.ParameterName = "@region";
                pRegions.SqlDbType = SqlDbType.VarChar;
                pRegions.Value = region;
                sqlCommand.Parameters.Add(pRegions);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0) 
                { 
                    Console.WriteLine("Insert Succes"); 
                }
                else 
                { 
                    Console.WriteLine("Insert Failed"); 
                }
                transaction.Commit();
                _conn.Close();
            }
            catch 
            { 
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database"); 
            }
        }
//----------------------------------------------------------UPDATE TABLE REGIONS-------------------------------------------
        public static void updateregion(int id,string region) 
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "update regions set name = (@region) where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try 
            {
                SqlParameter pRegions = new SqlParameter();
                pRegions.ParameterName = "@region";
                pRegions.Value = region;
                pRegions.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(pRegions);
                
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if(result>0)
                {
                    Console.WriteLine("Update Success");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
                transaction.Commit();
                _conn.Close();

            }
            catch 
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------DELETE TABLE REGIONS-------------------------------------------
        public static void deleteregion(int id) 
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "delete from regions where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if(result>0) 
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
                transaction.Commit(); _conn.Close(); 
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------GET REGION TABLE BY ID-------------------------------------------
        public static void getregionbyid(int id)
        {
            _conn = new SqlConnection( _connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from regions where id = (@id)";

            try
            {
                _conn.Open();
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);
                Console.WriteLine("ID\t Name");

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if(reader.HasRows) 
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine(
                                reader.GetInt32(0) + ")\t " +
                                reader.GetString(1));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data regions");
                    }
                    reader.Close();
                }

            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------END OF TABLE REGIONS--------------------------------------

//----------------------------------------------------------TABLE COUNTRIES-------------------------------------------
//----------------------------------------------------------GET ALL TABLE COUNTRIES-------------------------------------------
        public static void getcountries()
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from countries";

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("ID\tName\t\tRegion ID");
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                reader.GetValue(0) + ")\t(" +
                                reader.GetString(1) + "*)\t(" +
                                reader.GetInt32(2) + ")"
                                );
                        }
                        //dapat juga menggunakan (reader.getString(1)??"")
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data countries");
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------INSERT TABLE COUNTRIES-------------------------------------------
        public static void insertcountries(int id,string countries,int region_id)
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "insert into countries values (@id,@countries,@region_id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pCountries = new SqlParameter();
                pCountries.ParameterName = "@countries";
                pCountries.SqlDbType = SqlDbType.VarChar;
                pCountries.Value = countries;
                sqlCommand.Parameters.Add(pCountries);

                SqlParameter pRegionid = new SqlParameter();
                pRegionid.ParameterName = "@region_id";
                pRegionid.SqlDbType = SqlDbType.Int;
                pRegionid.Value = region_id;
                sqlCommand.Parameters.Add(pRegionid);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert Succes");
                }
                else
                {
                    Console.WriteLine("Insert Failed");
                }
                transaction.Commit();
                _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------UPDATE TABLE COUNTRIES-------------------------------------------
        public static void updatecountries(int id, string countries, int region_id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "update countries set name = (@countries), region_id = (@region_id) where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pCountries = new SqlParameter();
                pCountries.ParameterName = "@countries";
                pCountries.Value = countries;
                pCountries.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(pCountries);

                SqlParameter pRegionid = new SqlParameter();
                pRegionid.ParameterName = "@region_id";
                pRegionid.SqlDbType = SqlDbType.Int;
                pRegionid.Value = region_id;
                sqlCommand.Parameters.Add(pRegionid);


                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
                transaction.Commit();
                _conn.Close();

            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------DELETE TABLE COUNTRIES-------------------------------------------
        public static void deletecountries(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "delete from countries where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
                transaction.Commit(); _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------GET TABLE COUNTRIES BY ID-------------------------------------------
        public static void getcountriesbyid(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from countries where id = (@id)";

            try
            {
                _conn.Open();
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);
                Console.WriteLine("ID\tName\t\tRegion ID");

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                reader.GetValue(0) +")\t(" + 
                                reader.GetString(1) +"*)\t(" + 
                                reader.GetInt32(2) + ")"
                                );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data countriess");
                    }
                    reader.Close();
                }

            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------END OF TABLE COUNTRIES--------------------------------------
//----------------------------------------------------------TABLE LOCATIONS-------------------------------------------
//----------------------------------------------------------GET ALL TABLE LOCATIONS---------------------------------------------
        public static void getlocations()
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from locations";

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("ID\tAddress\t\t\tPostal Code\tCity\t\tProvince\tCountry ID");
                        while (reader.Read())
                            {
                                    Console.WriteLine(
                                    reader.GetInt32(0)+ ")\t("
                                    +reader.GetValue(1)+ ")\t(" 
                                    +reader.GetValue(2)+ ")\t\t(" 
                                    +reader.GetString(3)+ ")\t\t(" 
                                    +reader.GetValue(4)+ ")\t(" 
                                    +reader.GetValue(5)+")"
                                    );
                            }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data locations");
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------GET TABLE LOCATIONS BY ID-------------------------------------------
        public static void getlocationsbyid(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from locations where id = (@id)";

            try
            {
                _conn.Open();
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);
                Console.WriteLine("ID\tAddress\t\t\tPostal Code\tCity\t\tProvince\tCountry ID");

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                    reader.GetInt32(0) + ")\t("
                                    + reader.GetValue(1) + ")\t("
                                    + reader.GetValue(2) + ")\t\t("
                                    + reader.GetString(3) + ")\t\t("
                                    + reader.GetValue(4) + ")\t("
                                    + reader.GetValue(5) + ")"
                                );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data locationss");
                    }
                    reader.Close();
                }

            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------INSERT TABLE LOCATIONS-------------------------------------------
        public static void insertlocations(
            int id, string street_address, string postal_code, 
            string city, string state_province,int country_id
            )
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "insert into locations values " +
                "(@id,@street_address,@postal_code,@city,@state_province,@country_id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pAddress = new SqlParameter();
                pAddress.ParameterName = "@street_address";
                pAddress.SqlDbType = SqlDbType.VarChar;
                pAddress.Value = street_address;
                sqlCommand.Parameters.Add(pAddress);

                SqlParameter pPcode = new SqlParameter();
                pPcode.ParameterName = "@postal_code";
                pPcode.SqlDbType = SqlDbType.VarChar;
                pPcode.Value = postal_code;
                sqlCommand.Parameters.Add(pPcode);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = SqlDbType.VarChar;
                pCity.Value = city;
                sqlCommand.Parameters.Add(pCity);

                SqlParameter pProvince = new SqlParameter();
                pProvince.ParameterName = "@state_province";
                pProvince.SqlDbType = SqlDbType.VarChar;
                pProvince.Value = state_province;
                sqlCommand.Parameters.Add(pProvince);

                SqlParameter pCountryid = new SqlParameter();
                pCountryid.ParameterName = "@country_id";
                pCountryid.SqlDbType = SqlDbType.Int;
                pCountryid.Value = country_id;
                sqlCommand.Parameters.Add(pCountryid);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert Succes");
                }
                else
                {
                    Console.WriteLine("Insert Failed");
                }
                transaction.Commit();
                _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------UPDATE TABLE LOCATIONS-------------------------------------------
        public static void updatelocations(
            int id, 
            string street_address, 
            string postal_code,
            string city, 
            string state_province, 
            int country_id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText =
                "update locations set street_address = (@street_address), postal_code = (@postal_code), " +
                "city = (@city), state_province = (@state_province),country_id = (@country_id)" +
                "where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pAddress = new SqlParameter();
                pAddress.ParameterName = "@street_address";
                pAddress.SqlDbType = SqlDbType.VarChar;
                pAddress.Value = street_address;
                sqlCommand.Parameters.Add(pAddress);

                SqlParameter pPcode = new SqlParameter();
                pPcode.ParameterName = "@postal_code";
                pPcode.SqlDbType = SqlDbType.VarChar;
                pPcode.Value = postal_code;
                sqlCommand.Parameters.Add(pPcode);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = SqlDbType.VarChar;
                pCity.Value = city;
                sqlCommand.Parameters.Add(pCity);

                SqlParameter pProvince = new SqlParameter();
                pProvince.ParameterName = "@state_province";
                pProvince.SqlDbType = SqlDbType.VarChar;
                pProvince.Value = state_province;
                sqlCommand.Parameters.Add(pProvince);

                SqlParameter pCountryid = new SqlParameter();
                pCountryid.ParameterName = "@country_id";
                pCountryid.SqlDbType = SqlDbType.Int;
                pCountryid.Value = country_id;
                sqlCommand.Parameters.Add(pCountryid);


                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
                transaction.Commit();
                _conn.Close();

            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------DELETE TABLE LOCATIONS-------------------------------------------
        public static void deletelocations(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "delete from locations where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
                transaction.Commit(); _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------END OF TABLE LOCATIONS--------------------------------------
//----------------------------------------------------------TABLE DEPARTEMENTS------------------------------------------
//----------------------------------------------------------GET ALL TABLE DEPARTEMENTS-------------------------------------------
        public static void getdepartements()
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from departements";

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("ID\tName\t\t\tLocation ID\tManager ID");
                        while (reader.Read())
                        {
                            Console.WriteLine(
                            reader.GetInt32(0)+ ")\t(" 
                            + reader.GetString(1)+ ")\t\t\t(" 
                            + reader.GetInt32(2)+ ")\t\t(" 
                            + reader.GetValue(3)+")"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data departements");
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------GET TABLE DEPARTEMENTS BY ID-------------------------------------------
        public static void getdepartementsbyid(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from departements where id = (@id)";

            try
            {
                _conn.Open();
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);
                Console.WriteLine("ID\tName\t\t\tLocation ID\tManager ID");

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                            reader.GetInt32(0) + ")\t("
                            + reader.GetString(1) + ")\t\t\t("
                            + reader.GetInt32(2) + ")\t\t("
                            + reader.GetValue(3) + ")"
                                );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data departementss");
                    }
                    reader.Close();
                }

            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------INSERT TABLE DEPARTEMENTS-------------------------------------------
        public static void insertdepartements(
            int id, string name, int location_id,int manager_id
            )
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "insert into departements values " +
                "(@id,@name,@location_id,@manager_id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pLocationid = new SqlParameter();
                pLocationid.ParameterName = "@location_id";
                pLocationid.SqlDbType = SqlDbType.Int;
                pLocationid.Value = location_id;
                sqlCommand.Parameters.Add(pLocationid);

                SqlParameter pManagerid = new SqlParameter();
                pManagerid.ParameterName = "@manager_id";
                pManagerid.SqlDbType = SqlDbType.Int;
                pManagerid.Value = manager_id;
                sqlCommand.Parameters.Add(pManagerid);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert Succes");
                }
                else
                {
                    Console.WriteLine("Insert Failed");
                }
                transaction.Commit();
                _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------UPDATE TABLE DEPARTEMENTS-------------------------------------------
        public static void updatedepartements(
            int id, string name, int location_id, int manager_id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText =
                "update departements set name = (@name), location_id = (@location_id), " +
                "manager_id = (@manager_id)" +
                "where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pLocationid = new SqlParameter();
                pLocationid.ParameterName = "@location_id";
                pLocationid.SqlDbType = SqlDbType.Int;
                pLocationid.Value = location_id;
                sqlCommand.Parameters.Add(pLocationid);

                SqlParameter pManagerid = new SqlParameter();
                pManagerid.ParameterName = "@manager_id";
                pManagerid.SqlDbType = SqlDbType.Int;
                pManagerid.Value = manager_id;
                sqlCommand.Parameters.Add(pManagerid);


                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
                transaction.Commit();
                _conn.Close();

            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------DELETE TABLE DEPARTEMENTS-------------------------------------------
        public static void deletedepartements(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "delete from departements where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
                transaction.Commit(); _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------END OF TABLE DEPARTEMENTS------------------------------------------------
//----------------------------------------------------------TABLE EMPLOYEES---------------------------------------------------
//----------------------------------------------------------GET ALL TABLE EMPLOYEES-------------------------------------------
        public static void getemployees()
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from employees";

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine(
                            "ID " +
                            "First Name " +
                            "Last Name " +
                            "Emai " +
                            "Phone Number " +
                            "Hire Date " +
                            "Salary " +
                            "Commision " +
                            "Manager ID " +
                            "Job ID " +
                            "Departement ID");
                        while (reader.Read())
                        {
                            Console.WriteLine(
                            reader.GetInt32(0)
                            + ") (" + reader.GetString(1)
                            + ") (" + reader.GetValue(2)
                            + ") (" + reader.GetString(3)
                            + ") (" + reader.GetValue(4)
                            + ") (" + reader.GetDateTime(5)
                            + ") (" + reader.GetValue(6)
                            + ") (" + reader.GetValue(7)
                            + ") (" + reader.GetValue(8)
                            + ") (" + reader.GetValue(9)
                            + ") (" + reader.GetInt32(10)
                            + ")"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data employees");
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------GET TABLE EMPLOYEES BY ID-------------------------------------------
        public static void getemployeesbyid(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from employees where id = (@id)";

            try
            {
                _conn.Open();
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);
                Console.WriteLine(
                            "ID " +
                            "First Name " +
                            "Last Name " +
                            "Emai " +
                            "Phone Number " +
                            "Hire Date " +
                            "Salary " +
                            "Commision " +
                            "Manager ID " +
                            "Job ID " +
                            "Departement ID");

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                            reader.GetInt32(0)
                            + ") (" + reader.GetString(1)
                            + ") (" + reader.GetValue(2)
                            + ") (" + reader.GetString(3)
                            + ") (" + reader.GetValue(4)
                            + ") (" + reader.GetDateTime(5)
                            + ") (" + reader.GetValue(6)
                            + ") (" + reader.GetValue(7)
                            + ") (" + reader.GetValue(8)
                            + ") (" + reader.GetValue(9)
                            + ") (" + reader.GetInt32(10)
                            + ")"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data employeess");
                    }
                    reader.Close();
                }

            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------INSERT TABLE EMPLOYEES-------------------------------------------
        public static void insertemployees(
            int id, 
            string fn, 
            string ln, 
            string email, 
            string phone, 
            DateTime hire, 
            int salary, 
            decimal commision, 
            int manager_id,
            int job_id, 
            int departement_id 
            )
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "insert into employees values " +
                "(@id,@fn,@ln,@email,@phone,@hire,@salary,@commision,@manager_id,@job_id,@departement_id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pFn = new SqlParameter();
                pFn.ParameterName = "@fn";
                pFn.SqlDbType = SqlDbType.VarChar;
                pFn.Value = fn;
                sqlCommand.Parameters.Add(pFn);

                SqlParameter pLn = new SqlParameter();
                pLn.ParameterName = "@ln";
                pLn.SqlDbType = SqlDbType.VarChar;
                pLn.Value = ln;
                sqlCommand.Parameters.Add(pLn);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Value = email;
                sqlCommand.Parameters.Add(pEmail);

                SqlParameter pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone";
                pPhone.SqlDbType = SqlDbType.VarChar;
                pPhone.Value = phone;
                sqlCommand.Parameters.Add(pPhone);

                SqlParameter pHire = new SqlParameter();
                pHire.ParameterName = "@hire";
                pHire.SqlDbType = SqlDbType.DateTime;
                pHire.Value = hire;
                sqlCommand.Parameters.Add(pHire);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = SqlDbType.Int;
                pSalary.Value = salary;
                sqlCommand.Parameters.Add(pSalary);

                SqlParameter pCommision = new SqlParameter();
                pCommision.ParameterName = "@commision";
                pCommision.SqlDbType = SqlDbType.Decimal;
                pCommision.Value = commision;
                sqlCommand.Parameters.Add(pCommision);

                SqlParameter pManagerid = new SqlParameter();
                pManagerid.ParameterName = "@manager_id";
                pManagerid.SqlDbType = SqlDbType.Int;
                pManagerid.Value = manager_id;
                sqlCommand.Parameters.Add(pManagerid);

                SqlParameter pJobid = new SqlParameter();
                pJobid.ParameterName = "@job_id";
                pJobid.SqlDbType = SqlDbType.Int;
                pJobid.Value = job_id;
                sqlCommand.Parameters.Add(pJobid);

                SqlParameter pDepartementid = new SqlParameter();
                pDepartementid.ParameterName = "@departement_id";
                pDepartementid.SqlDbType = SqlDbType.Int;
                pDepartementid.Value = departement_id;
                sqlCommand.Parameters.Add(pDepartementid);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert Succes");
                }
                else
                {
                    Console.WriteLine("Insert Failed");
                }
                transaction.Commit();
                _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------UPDATE TABLE EMPLOYEES-------------------------------------------
        public static void updateemployees(
            int id,
            string fn,
            string ln,
            string email,
            string phone,
            DateTime hire,
            int salary,
            decimal commision,
            int manager_id,
            int job_id,
            int departement_id
            )
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText =
                "update employees set first_name = (@fn), last_name = (@ln), " +
                "email = (@email),phone_number = (@phone),hire_date = (@hire),salary = (@salary),comission_pct = (@commision),manager_id = (@manager_id)," +
                "job_id = (@job_id),departement_id = (@departement_id)" +
                "where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pFn = new SqlParameter();
                pFn.ParameterName = "@fn";
                pFn.SqlDbType = SqlDbType.VarChar;
                pFn.Value = fn;
                sqlCommand.Parameters.Add(pFn);

                SqlParameter pLn = new SqlParameter();
                pLn.ParameterName = "@ln";
                pLn.SqlDbType = SqlDbType.VarChar;
                pLn.Value = ln;
                sqlCommand.Parameters.Add(pLn);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Value = email;
                sqlCommand.Parameters.Add(pEmail);

                SqlParameter pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone";
                pPhone.SqlDbType = SqlDbType.VarChar;
                pPhone.Value = phone;
                sqlCommand.Parameters.Add(pPhone);

                SqlParameter pHire = new SqlParameter();
                pHire.ParameterName = "@hire";
                pHire.SqlDbType = SqlDbType.DateTime;
                pHire.Value = hire;
                sqlCommand.Parameters.Add(pHire);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = SqlDbType.Int;
                pSalary.Value = salary;
                sqlCommand.Parameters.Add(pSalary);

                SqlParameter pCommision = new SqlParameter();
                pCommision.ParameterName = "@commision";
                pCommision.SqlDbType = SqlDbType.Decimal;
                pCommision.Value = commision;
                sqlCommand.Parameters.Add(pCommision);

                SqlParameter pManagerid = new SqlParameter();
                pManagerid.ParameterName = "@manager_id";
                pManagerid.SqlDbType = SqlDbType.Int;
                pManagerid.Value = manager_id;
                sqlCommand.Parameters.Add(pManagerid);

                SqlParameter pJobid = new SqlParameter();
                pJobid.ParameterName = "@job_id";
                pJobid.SqlDbType = SqlDbType.Int;
                pJobid.Value = job_id;
                sqlCommand.Parameters.Add(pJobid);

                SqlParameter pDepartementid = new SqlParameter();
                pDepartementid.ParameterName = "@departement_id";
                pDepartementid.SqlDbType = SqlDbType.Int;
                pDepartementid.Value = departement_id;
                sqlCommand.Parameters.Add(pDepartementid);


                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
                transaction.Commit();
                _conn.Close();

            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------DELETE TABLE EMPLOYEES-------------------------------------------
        public static void deleteemployees(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "delete from employees where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
                transaction.Commit(); _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------END OF TABLE EMPLOYEES--------------------------------------
//----------------------------------------------------------TABLE HISTORIES-----------------------------------------------------
//----------------------------------------------------------GET ALL TABLE HISTORIES-------------------------------------------
        public static void gethistories()
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from histories";

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine(
                            "Start Date " +
                            "\t\tEmployee ID " +
                            "\tEnd Date " +
                            "\t\tDepartement ID " +
                            "Job ID "
                            );
                        while (reader.Read())
                        {
                            Console.WriteLine(
                            reader.GetValue(0)
                            + ") \t(" + reader.GetValue(1)
                            + ")\t\t(" + reader.GetValue(2)
                            + ")\t(" + reader.GetValue(3)
                            + ")\t\t(" + reader.GetValue(4)
                            +")"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data histories");
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------GET TABLE HISTORIES BY ID-------------------------------------------
        public static void gethistoriesbyid(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from histories where employee_id = (@id)";

            try
            {
                _conn.Open();
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);
                Console.WriteLine(
                            "Start Date " +
                            "\t\tEmployee ID " +
                            "\tEnd Date " +
                            "\t\tDepartement ID " +
                            "Job ID "
                            );

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                            reader.GetValue(0)
                            + ") \t(" + reader.GetValue(1)
                            + ")\t\t(" + reader.GetValue(2)
                            + ")\t(" + reader.GetValue(3)
                            + ")\t\t(" + reader.GetValue(4)
                            + ")"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data historiess");
                    }
                    reader.Close();
                }

            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------INSERT TABLE HISTORIES-------------------------------------------
        public static void inserthistories(
            DateTime start_date,
            int employee_id,
            DateTime end_date,
            int departement_id,
            int job_id
            )
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "insert into histories values " +
                "(@start_date,@employee_id,@end_date,@departement_id,@job_id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pEmployeeid = new SqlParameter();
                pEmployeeid.ParameterName = "@employee_id";
                pEmployeeid.SqlDbType = SqlDbType.Int;
                pEmployeeid.Value = employee_id;
                sqlCommand.Parameters.Add(pEmployeeid);

                SqlParameter pStart = new SqlParameter();
                pStart.ParameterName = "@start_date";
                pStart.SqlDbType = SqlDbType.DateTime;
                pStart.Value = start_date;
                sqlCommand.Parameters.Add(pStart);

                SqlParameter pEnd = new SqlParameter();
                pEnd.ParameterName = "@end_date";
                pEnd.SqlDbType = SqlDbType.DateTime;
                pEnd.Value = end_date;
                sqlCommand.Parameters.Add(pEnd);

                SqlParameter pJobid = new SqlParameter();
                pJobid.ParameterName = "@job_id";
                pJobid.SqlDbType = SqlDbType.Int;
                pJobid.Value = job_id;
                sqlCommand.Parameters.Add(pJobid);

                SqlParameter pDepartementid = new SqlParameter();
                pDepartementid.ParameterName = "@departement_id";
                pDepartementid.SqlDbType = SqlDbType.Int;
                pDepartementid.Value = departement_id;
                sqlCommand.Parameters.Add(pDepartementid);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert Succes");
                }
                else
                {
                    Console.WriteLine("Insert Failed");
                }
                transaction.Commit();
                _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------UPDATE TABLE HISTORIES-------------------------------------------
        public static void updatehistories(
            DateTime start_date,
            int employee_id,
            DateTime end_date,
            int departement_id,
            int job_id
            )
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText =
                "update histories set " +
                "start_date = (@start_date),employee_id = (@employee_id),end_date = (@end_date)," +
                "departement_id = (@departement_id),job_id = (@job_id)" +
                "where employee_id = (@employee_id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pEmployeeid = new SqlParameter();
                pEmployeeid.ParameterName = "@employee_id";
                pEmployeeid.SqlDbType = SqlDbType.Int;
                pEmployeeid.Value = employee_id;
                sqlCommand.Parameters.Add(pEmployeeid);

                SqlParameter pStart = new SqlParameter();
                pStart.ParameterName = "@start_date";
                pStart.SqlDbType = SqlDbType.DateTime;
                pStart.Value = start_date;
                sqlCommand.Parameters.Add(pStart);

                SqlParameter pEnd = new SqlParameter();
                pEnd.ParameterName = "@end_date";
                pEnd.SqlDbType = SqlDbType.DateTime;
                pEnd.Value = end_date;
                sqlCommand.Parameters.Add(pEnd);

                SqlParameter pJobid = new SqlParameter();
                pJobid.ParameterName = "@job_id";
                pJobid.SqlDbType = SqlDbType.Int;
                pJobid.Value = job_id;
                sqlCommand.Parameters.Add(pJobid);

                SqlParameter pDepartementid = new SqlParameter();
                pDepartementid.ParameterName = "@departement_id";
                pDepartementid.SqlDbType = SqlDbType.Int;
                pDepartementid.Value = departement_id;
                sqlCommand.Parameters.Add(pDepartementid);


                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
                transaction.Commit();
                _conn.Close();

            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------DELETE TABLE HISTORIES-------------------------------------------
        public static void deletehistories(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "delete from histories where employee_id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
                transaction.Commit(); _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------END OF TABLE HISTORIES--------------------------------------
//----------------------------------------------------------TABLE JOBS---------------------------------------------------------
//----------------------------------------------------------GET ALL TABLE JOBS-------------------------------------------
        public static void getjobs()
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from jobs";

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine(
                            "ID " +
                            "\t\tTitle " +
                            "\t\tMinimal Salary Column " +
                            "\tMaximal Salary Column "
                            );
                        while (reader.Read())
                        {
                            Console.WriteLine(
                            reader.GetValue(0)
                            + ") \t(" + reader.GetValue(1)
                            + ")\t\t(" + reader.GetValue(2)
                            + ")\t\t\t(" + reader.GetValue(3)
                            + ")"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data jobs");
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------GET TABLE JOBS BY ID-------------------------------------------
        public static void getjobsbyid(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from jobs where id = (@id)";

            try
            {
                _conn.Open();
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);
                Console.WriteLine(
                            "ID " +
                            "\t\tTitle " +
                            "\t\tMinimal Salary Column " +
                            "\tMaximal Salary Column "
                            );

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                            reader.GetValue(0)
                            + ") \t(" + reader.GetValue(1)
                            + ")\t\t(" + reader.GetValue(2)
                            + ")\t\t\t(" + reader.GetValue(3)
                            + ")"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tidak ada data jobs");
                    }
                    reader.Close();
                }

            }
            catch
            {
                Console.WriteLine("Error Connecting to database");
            }
            finally
            {
                _conn.Close();
            }
        }
//----------------------------------------------------------INSERT TABLE JOBS-------------------------------------------
        public static void insertjobs(
            int id,
            string title,
            int min_salary,
            int max_salary
            )
        {
            _conn = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "insert into jobs values " +
                "(@id,@title,@min_salary,@max_salary)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = SqlDbType.VarChar;
                pTitle.Value = title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMin = new SqlParameter();
                pMin.ParameterName = "@min_salary";
                pMin.SqlDbType = SqlDbType.Int;
                pMin.Value = min_salary;
                sqlCommand.Parameters.Add(pMin);

                SqlParameter pMax = new SqlParameter();
                pMax.ParameterName = "@max_salary";
                pMax.SqlDbType = SqlDbType.Int;
                pMax.Value = max_salary;
                sqlCommand.Parameters.Add(pMax);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert Succes");
                }
                else
                {
                    Console.WriteLine("Insert Failed");
                }
                transaction.Commit();
                _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------UPDATE TABLE JOBS-------------------------------------------
        public static void updatejobs(
            int id,
            string title,
            int min_salary,
            int max_salary
            )
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText =
                "update jobs set " +
                "title = (@title),min_salary = (@min_salary),max_salary = (@max_salary)"+
                "where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = SqlDbType.VarChar;
                pTitle.Value = title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMin = new SqlParameter();
                pMin.ParameterName = "@min_salary";
                pMin.SqlDbType = SqlDbType.Int;
                pMin.Value = min_salary;
                sqlCommand.Parameters.Add(pMin);

                SqlParameter pMax = new SqlParameter();
                pMax.ParameterName = "@max_salary";
                pMax.SqlDbType = SqlDbType.Int;
                pMax.Value = max_salary;
                sqlCommand.Parameters.Add(pMax);


                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
                transaction.Commit();
                _conn.Close();

            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------DELETE TABLE JOBS-------------------------------------------
        public static void deletejobs(int id)
        {
            _conn = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "delete from jobs where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
                transaction.Commit(); _conn.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error Connecting to database");
            }
        }
//----------------------------------------------------------END OF TABLE JOBS-------------------------------------------------
    }
}
