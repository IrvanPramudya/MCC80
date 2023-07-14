using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace MVCArchitecture.Models
{
    internal class History
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int EmployeeId { get; set; }
        public int DepartementId { get; set; }
        public string JobId { get; set; }
        //----------------------------------------------------------TABLE HISTORIES-----------------------------------------------------
        //----------------------------------------------------------GET ALL TABLE HISTORIES-------------------------------------------
        public List<History> getall()
        {
            var _conn = Connection.get();
            var histories = new List<History>();

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
                        while (reader.Read())
                        {
                            History history = new History();
                            history.Start = reader.GetDateTime(0);
                            history.EmployeeId = reader.GetInt32(1);
                            history.End = reader.IsDBNull(2)? DateTime.Today : reader.GetDateTime(2);
                            history.DepartementId = reader.GetInt32(3);
                            history.JobId = reader.GetString(4);

                            histories.Add(history);
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
                    
                }
                return histories;
            }
            catch
            {
                return new List<History>();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------GET TABLE HISTORIES BY ID-------------------------------------------
        public History getbyid(int id)
        {
            var _conn = Connection.get();
            var history = new History();
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
                
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        history.Start = reader.GetDateTime(0);
                        history.EmployeeId = reader.GetInt32(1);
                        history.End = reader.IsDBNull(2)? DateTime.Today : reader.GetDateTime(2);
                        history.DepartementId = reader.GetInt32(3);
                        history.JobId = reader.GetString(4);
                    }
                    reader.Close();
                }
                return history;

            }
            catch
            {
                return new History();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------INSERT TABLE HISTORIES-------------------------------------------
        public int insert(History history)
        {
            var _conn = Connection.get();

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
                pEmployeeid.Value = history.EmployeeId;
                sqlCommand.Parameters.Add(pEmployeeid);

                SqlParameter pStart = new SqlParameter();
                pStart.ParameterName = "@start_date";
                pStart.SqlDbType = SqlDbType.DateTime;
                pStart.Value = history.Start;
                sqlCommand.Parameters.Add(pStart);

                SqlParameter pEnd = new SqlParameter();
                pEnd.ParameterName = "@end_date";
                pEnd.SqlDbType = SqlDbType.DateTime;
                pEnd.Value = history.End;
                sqlCommand.Parameters.Add(pEnd);

                SqlParameter pJobid = new SqlParameter();
                pJobid.ParameterName = "@job_id";
                pJobid.SqlDbType = SqlDbType.VarChar;
                pJobid.Value = history.JobId;
                sqlCommand.Parameters.Add(pJobid);

                SqlParameter pDepartementid = new SqlParameter();
                pDepartementid.ParameterName = "@departement_id";
                pDepartementid.SqlDbType = SqlDbType.Int;
                pDepartementid.Value = history.DepartementId;
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
        //----------------------------------------------------------UPDATE TABLE HISTORIES-------------------------------------------
        public int update(History history)
        {
            var _conn = Connection.get();

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
                pEmployeeid.Value = history.EmployeeId;
                sqlCommand.Parameters.Add(pEmployeeid);

                SqlParameter pStart = new SqlParameter();
                pStart.ParameterName = "@start_date";
                pStart.SqlDbType = SqlDbType.DateTime;
                pStart.Value = history.Start;
                sqlCommand.Parameters.Add(pStart);

                SqlParameter pEnd = new SqlParameter();
                pEnd.ParameterName = "@end_date";
                pEnd.SqlDbType = SqlDbType.DateTime;
                pEnd.Value = history.End;
                sqlCommand.Parameters.Add(pEnd);

                SqlParameter pJobid = new SqlParameter();
                pJobid.ParameterName = "@job_id";
                pJobid.SqlDbType = SqlDbType.VarChar;
                pJobid.Value = history.JobId;
                sqlCommand.Parameters.Add(pJobid);

                SqlParameter pDepartementid = new SqlParameter();
                pDepartementid.ParameterName = "@departement_id";
                pDepartementid.SqlDbType = SqlDbType.Int;
                pDepartementid.Value = history.DepartementId;
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
        //----------------------------------------------------------DELETE TABLE HISTORIES-------------------------------------------
        public int delete(int id)
        {
            var _conn = Connection.get();

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
        //----------------------------------------------------------END OF TABLE HISTORIES--------------------------------------
    }
}
