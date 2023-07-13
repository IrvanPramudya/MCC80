using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        //----------------------------------------------------------TABLE COUNTRIES-------------------------------------------
        //----------------------------------------------------------GET ALL TABLE COUNTRIES-------------------------------------------
        public  List<Country> getall()
        {
            var _conn = Connection.get();
            var countries = new List<Country>();

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
                        while (reader.Read())
                        {
                            Country country = new Country();
                            country.Id = reader.GetString(0);
                            country.Name = reader.GetString(1);
                            country.RegionId = reader.GetInt32(2);

                            countries.Add(country);
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
                    return countries;
                }
            }
            catch
            {
                return new List<Country> ();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------GET TABLE COUNTRIES BY ID-------------------------------------------
        public Country getbyid(int id)
        {
            var _conn = Connection.get();
            var country = new Country();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _conn;
            sqlCommand.CommandText = "select * from countries where id = (@id)";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                _conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                            
                            country.Id = reader.GetString(0);
                            country.Name = reader.GetString(1);
                            country.RegionId = reader.GetInt32(2);
                    }
                    reader.Close();

                    return country;
                }

            }
            catch
            {
                return new Country();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------INSERT TABLE COUNTRIES-------------------------------------------
        public int insert(Country country)
        {
            var _conn = Connection.get();

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
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = country.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pCountries = new SqlParameter();
                pCountries.ParameterName = "@countries";
                pCountries.SqlDbType = SqlDbType.VarChar;
                pCountries.Value = country.Name;
                sqlCommand.Parameters.Add(pCountries);

                SqlParameter pRegionid = new SqlParameter();
                pRegionid.ParameterName = "@region_id";
                pRegionid.SqlDbType = SqlDbType.Int;
                pRegionid.Value = country.RegionId;
                sqlCommand.Parameters.Add(pRegionid);

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
            { _conn.Close(); }
        }
        //----------------------------------------------------------UPDATE TABLE COUNTRIES-------------------------------------------
        public int update(Country country)
        {
            var _conn = Connection.get();
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
                pId.Value = country.Id;
                pId.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pCountries = new SqlParameter();
                pCountries.ParameterName = "@countries";
                pCountries.Value = country.Name;
                pCountries.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(pCountries);

                SqlParameter pRegionid = new SqlParameter();
                pRegionid.ParameterName = "@region_id";
                pRegionid.SqlDbType = SqlDbType.Int;
                pRegionid.Value = country.RegionId;
                sqlCommand.Parameters.Add(pRegionid);


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
            { _conn.Close(); }
        }
        //----------------------------------------------------------DELETE TABLE COUNTRIES-------------------------------------------
        public int delete(int id)
        {
            var _conn = Connection.get();
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
                pId.SqlDbType = SqlDbType.VarChar;
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
        //----------------------------------------------------------END OF TABLE COUNTRIES--------------------------------------
    }
}
