using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        //----------------------------------------------------------TABLE JOBS---------------------------------------------------------
        //----------------------------------------------------------GET ALL TABLE JOBS-------------------------------------------
        public List<Job> getall()
        {
            var _conn = Connection.get();
            var jobs = new List<Job>(); 

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
                        while (reader.Read())
                        {

                            var job = new Job();
                            job.Id = reader.GetInt32(0);
                            job.Title = reader.GetString(1);
                            job.MinSalary = reader.GetInt32(2);
                            job.MaxSalary = reader.GetInt32(3);

                            jobs.Add(job);
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
                }
                return jobs;
            }
            catch
            {
                return new List<Job>();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------GET TABLE JOBS BY ID-------------------------------------------
        public Job getbyid(int id)
        {
            var _conn = Connection.get();
            var job = new Job();

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

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        job.Id = reader.GetInt32(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);

                    }
                    reader.Close();
                }
                return job;

            }
            catch
            {
                return new Job();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------INSERT TABLE JOBS-------------------------------------------
        public int insert(Job job)
        {
            var _conn = Connection.get();

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
                pId.Value = job.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = SqlDbType.VarChar;
                pTitle.Value = job.Title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMin = new SqlParameter();
                pMin.ParameterName = "@min_salary";
                pMin.SqlDbType = SqlDbType.Int;
                pMin.Value = job.MinSalary;
                sqlCommand.Parameters.Add(pMin);

                SqlParameter pMax = new SqlParameter();
                pMax.ParameterName = "@max_salary";
                pMax.SqlDbType = SqlDbType.Int;
                pMax.Value = job.MaxSalary;
                sqlCommand.Parameters.Add(pMax);

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
        //----------------------------------------------------------UPDATE TABLE JOBS-------------------------------------------
        public int update(Job job)
        {
            var _conn = Connection.get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText =
                "update jobs set " +
                "title = (@title),min_salary = (@min_salary),max_salary = (@max_salary)" +
                "where id = (@id)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = job.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = SqlDbType.VarChar;
                pTitle.Value = job.Title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMin = new SqlParameter();
                pMin.ParameterName = "@min_salary";
                pMin.SqlDbType = SqlDbType.Int;
                pMin.Value = job.MinSalary;
                sqlCommand.Parameters.Add(pMin);

                SqlParameter pMax = new SqlParameter();
                pMax.ParameterName = "@max_salary";
                pMax.SqlDbType = SqlDbType.Int;
                pMax.Value = job.MaxSalary;
                sqlCommand.Parameters.Add(pMax);


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
        //----------------------------------------------------------DELETE TABLE JOBS-------------------------------------------
        public int delete(int id)
        {
            var _conn = Connection.get();
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
        //----------------------------------------------------------END OF TABLE JOBS-------------------------------------------------
    }
}
