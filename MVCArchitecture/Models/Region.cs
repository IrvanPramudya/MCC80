using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //----------------------------------------------------------TABLE REGIONS-------------------------------------------
        //----------------------------------------------------------GET ALL TABLE REGIONS-------------------------------------------
        public List<Region> getall()
        {
            var _conn = Connection.get();
            var regions = new List<Region>();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from regions";

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Region region = new Region();
                            region.Id = reader.GetInt32(0);
                            region.Name = reader.GetString(1);

                            regions.Add(region);
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
                    return regions;
                }
            }
            catch
            {
                return new List<Region>();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------INSERT TABLE REGIONS-------------------------------------------
        public int insert(Region region)
        {
            var _conn = Connection.get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "insert into regions values (@region)";

            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                
                SqlParameter pRegions = new SqlParameter();
                pRegions.ParameterName = "@region";
                pRegions.SqlDbType = SqlDbType.VarChar;
                pRegions.Value = region.Name;
                sqlCommand.Parameters.Add(pRegions);

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
        //----------------------------------------------------------UPDATE TABLE REGIONS-------------------------------------------
        public int update(Region region)
        {
            var _conn = Connection.get();
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
                pRegions.Value = region.Name;
                pRegions.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(pRegions);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = region.Id;
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
        //----------------------------------------------------------DELETE TABLE REGIONS-------------------------------------------
        public int delete(int id)
        {
            var _conn = Connection.get();

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
        //----------------------------------------------------------GET REGION TABLE BY ID-------------------------------------------
        public Region getbyid(int id)
        {
            var _conn = Connection.get();
            var region = new Region(); 

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from regions where id = (@id)";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        region.Id = reader.GetInt32(0);
                        region.Name = reader.GetString(1);
                    }
                    reader.Close();

                    return region;
                }
            }
            catch
            {
                return new Region();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------END OF TABLE REGIONS--------------------------------------
    }
}
