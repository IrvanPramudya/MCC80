using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Departement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }
        //----------------------------------------------------------TABLE DEPARTEMENTS------------------------------------------
        //----------------------------------------------------------GET ALL TABLE DEPARTEMENTS-------------------------------------------
        public List<Departement> getall()
        {
            var _conn = Connection.get();
            var departements = new List<Departement>();

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
                        while (reader.Read())
                        {
                            Departement departement = new Departement();
                            departement.Id = reader.GetInt32(0);
                            departement.Name = reader.GetString(1);
                            departement.LocationId = reader.GetInt32(2);
                            departement.ManagerId = reader.GetInt32(3);

                            departements.Add(departement);
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
                    return departements;
                }
            }
            catch
            {
                return new List<Departement>();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------GET TABLE DEPARTEMENTS BY ID-------------------------------------------
        public Departement getbyid(int id)
        {
            var _conn = Connection.get();
            var departement = new Departement();

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

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        departement.Id = reader.GetInt32(0);
                        departement.Name = reader.GetString(1);
                        departement.LocationId = reader.GetInt32(2);
                        departement.ManagerId = (reader.IsDBNull(3)? 0 :reader.GetInt32(3));
                    }
                    reader.Close();
                    return departement;
                }

            }
            catch
            {
                return new Departement();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------INSERT TABLE DEPARTEMENTS-------------------------------------------
        public int insert(Departement departement)
        {
            var _conn = Connection.get();

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
                pId.Value = departement.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = departement.Name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pLocationid = new SqlParameter();
                pLocationid.ParameterName = "@location_id";
                pLocationid.SqlDbType = SqlDbType.Int;
                pLocationid.Value = departement.LocationId;
                sqlCommand.Parameters.Add(pLocationid);

                SqlParameter pManagerid = new SqlParameter();
                pManagerid.ParameterName = "@manager_id";
                pManagerid.SqlDbType = SqlDbType.Int;
                pManagerid.Value = departement.ManagerId;
                sqlCommand.Parameters.Add(pManagerid);

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
        //----------------------------------------------------------UPDATE TABLE DEPARTEMENTS-------------------------------------------
        public int update(Departement departement)
        {
            var _conn = Connection.get();
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
                pId.Value = departement.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = departement.Name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pLocationid = new SqlParameter();
                pLocationid.ParameterName = "@location_id";
                pLocationid.SqlDbType = SqlDbType.Int;
                pLocationid.Value = departement.LocationId;
                sqlCommand.Parameters.Add(pLocationid);

                SqlParameter pManagerid = new SqlParameter();
                pManagerid.ParameterName = "@manager_id";
                pManagerid.SqlDbType = SqlDbType.Int;
                pManagerid.Value = departement.ManagerId;
                sqlCommand.Parameters.Add(pManagerid);


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
        //----------------------------------------------------------DELETE TABLE DEPARTEMENTS-------------------------------------------
        public int delete(int id)
        {
            var _conn = Connection.get();
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
                
                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
            finally { _conn.Close(); }
        }
        //----------------------------------------------------------END OF TABLE DEPARTEMENTS------------------------------------------------
    }
}
