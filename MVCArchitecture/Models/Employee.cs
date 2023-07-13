using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Hire { get; set; }
        public int Salary { get; set; }
        public decimal Comission { get; set; }
        public int ManagerId { get; set; }
        public int JobId { get; set; }
        public int DepartementId { get; set; }
        //----------------------------------------------------------TABLE EMPLOYEES---------------------------------------------------
        //----------------------------------------------------------GET ALL TABLE EMPLOYEES-------------------------------------------
        public List<Employee> getall()
        {
            var _conn = Connection.get();
            var employees = new List<Employee>();

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
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Id = reader.GetInt32(0);
                            employee.FirstName = reader.GetString(1);
                            employee.LastName = (reader.IsDBNull(2)?"": reader.GetString(2));
                            employee.Email = reader.GetString(3);
                            employee.Phone = reader.GetString(4);
                            employee.Hire = reader.GetDateTime(5);
                            employee.Salary = reader.GetInt32(6);
                            employee.Comission = reader.GetDecimal(7);
                            employee.ManagerId = (reader.IsDBNull(8) ? 0 : reader.GetInt32(8));
                            employee.JobId = (reader.IsDBNull(9) ? 0 : reader.GetInt32(9));
                            employee.DepartementId = (reader.IsDBNull(10) ? 0 : reader.GetInt32(10));

                            employees.Add(employee);
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
                    return employees;
                }
            }
            catch
            {
                return new List<Employee>();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------GET TABLE EMPLOYEES BY ID-------------------------------------------
        public Employee getbyid(int id)
        {
            var _conn = Connection.get();
            var employee = new Employee();

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
                
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        employee.Id = reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = (reader.IsDBNull(2) ? "" : reader.GetString(2));
                        employee.Email = reader.GetString(3);
                        employee.Phone = reader.GetString(4);
                        employee.Hire = reader.GetDateTime(5);
                        employee.Salary = reader.GetInt32(6);
                        employee.Comission = reader.GetDecimal(7);
                        employee.ManagerId = (reader.IsDBNull(8) ? 0 : reader.GetInt32(8));
                        employee.JobId = (reader.IsDBNull(9) ? 0 : reader.GetInt32(9));
                        employee.DepartementId = (reader.IsDBNull(10) ? 0 : reader.GetInt32(10));
                    }
                    reader.Close();
                    return employee;
                }

            }
            catch
            {
                return new Employee();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------INSERT TABLE EMPLOYEES-------------------------------------------
        public int insert(Employee employee)
        {
            var _conn = Connection.get();

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
                pId.Value = employee.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pFn = new SqlParameter();
                pFn.ParameterName = "@fn";
                pFn.SqlDbType = SqlDbType.VarChar;
                pFn.Value = employee.FirstName;
                sqlCommand.Parameters.Add(pFn);

                SqlParameter pLn = new SqlParameter();
                pLn.ParameterName = "@ln";
                pLn.SqlDbType = SqlDbType.VarChar;
                pLn.Value = employee.LastName;
                sqlCommand.Parameters.Add(pLn);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Value = employee.Email;
                sqlCommand.Parameters.Add(pEmail);

                SqlParameter pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone";
                pPhone.SqlDbType = SqlDbType.VarChar;
                pPhone.Value = employee.Phone;
                sqlCommand.Parameters.Add(pPhone);

                SqlParameter pHire = new SqlParameter();
                pHire.ParameterName = "@hire";
                pHire.SqlDbType = SqlDbType.DateTime;
                pHire.Value = employee.Hire;
                sqlCommand.Parameters.Add(pHire);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = SqlDbType.Int;
                pSalary.Value = employee.Salary;
                sqlCommand.Parameters.Add(pSalary);

                SqlParameter pCommision = new SqlParameter();
                pCommision.ParameterName = "@commision";
                pCommision.SqlDbType = SqlDbType.Decimal;
                pCommision.Value = employee.Comission;
                sqlCommand.Parameters.Add(pCommision);

                SqlParameter pManagerid = new SqlParameter();
                pManagerid.ParameterName = "@manager_id";
                pManagerid.SqlDbType = SqlDbType.Int;
                pManagerid.Value = employee.ManagerId;
                sqlCommand.Parameters.Add(pManagerid);

                SqlParameter pJobid = new SqlParameter();
                pJobid.ParameterName = "@job_id";
                pJobid.SqlDbType = SqlDbType.Int;
                pJobid.Value = employee.JobId;
                sqlCommand.Parameters.Add(pJobid);

                SqlParameter pDepartementid = new SqlParameter();
                pDepartementid.ParameterName = "@departement_id";
                pDepartementid.SqlDbType = SqlDbType.Int;
                pDepartementid.Value = employee.DepartementId;
                sqlCommand.Parameters.Add(pDepartementid);

                int result = sqlCommand.ExecuteNonQuery();
      
                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------UPDATE TABLE EMPLOYEES-------------------------------------------
        public int update(Employee employee)
        {
            var _conn = Connection.get();

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
                pId.Value = employee.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pFn = new SqlParameter();
                pFn.ParameterName = "@fn";
                pFn.SqlDbType = SqlDbType.VarChar;
                pFn.Value = employee.FirstName;
                sqlCommand.Parameters.Add(pFn);

                SqlParameter pLn = new SqlParameter();
                pLn.ParameterName = "@ln";
                pLn.SqlDbType = SqlDbType.VarChar;
                pLn.Value = employee.LastName;
                sqlCommand.Parameters.Add(pLn);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Value = employee.Email;
                sqlCommand.Parameters.Add(pEmail);

                SqlParameter pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone";
                pPhone.SqlDbType = SqlDbType.VarChar;
                pPhone.Value = employee.Phone;
                sqlCommand.Parameters.Add(pPhone);

                SqlParameter pHire = new SqlParameter();
                pHire.ParameterName = "@hire";
                pHire.SqlDbType = SqlDbType.DateTime;
                pHire.Value = employee.Hire;
                sqlCommand.Parameters.Add(pHire);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = SqlDbType.Int;
                pSalary.Value = employee.Salary;
                sqlCommand.Parameters.Add(pSalary);

                SqlParameter pCommision = new SqlParameter();
                pCommision.ParameterName = "@commision";
                pCommision.SqlDbType = SqlDbType.Decimal;
                pCommision.Value = employee.Comission;
                sqlCommand.Parameters.Add(pCommision);

                SqlParameter pManagerid = new SqlParameter();
                pManagerid.ParameterName = "@manager_id";
                pManagerid.SqlDbType = SqlDbType.Int;
                pManagerid.Value = employee.ManagerId;
                sqlCommand.Parameters.Add(pManagerid);

                SqlParameter pJobid = new SqlParameter();
                pJobid.ParameterName = "@job_id";
                pJobid.SqlDbType = SqlDbType.Int;
                pJobid.Value = employee.JobId;
                sqlCommand.Parameters.Add(pJobid);

                SqlParameter pDepartementid = new SqlParameter();
                pDepartementid.ParameterName = "@departement_id";
                pDepartementid.SqlDbType = SqlDbType.Int;
                pDepartementid.Value = employee.DepartementId;
                sqlCommand.Parameters.Add(pDepartementid);


                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                
                transaction.Commit();
                return result;

            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------DELETE TABLE EMPLOYEES-------------------------------------------
        public int delete(int id)
        {
            var _conn = Connection.get();

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
                
                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------END OF TABLE EMPLOYEES--------------------------------------
    }
}
