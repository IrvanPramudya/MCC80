using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Location
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }
        //----------------------------------------------------------TABLE LOCATIONS-------------------------------------------
        //----------------------------------------------------------GET ALL TABLE LOCATIONS---------------------------------------------
        public List<Location> getall()
        {
            var _conn = Connection.get();
            var locations = new List<Location>();

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
                        while (reader.Read())
                        {
                            Location location = new Location();
                            location.Id = reader.GetInt32(0);
                            location.StreetAddress= (reader.IsDBNull(1) ? "" : reader.GetString(1));
                            location.PostalCode= (reader.IsDBNull(2) ? "" : reader.GetString(2));
                            location.City= reader.GetString(3);
                            location.StateProvince= (reader.IsDBNull(4) ? "" : reader.GetString(4));
                            location.CountryId= (reader.IsDBNull(5)?"":reader.GetString(5));

                            locations.Add(location);
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
                    return locations;
                }
            }
            catch
            {
                return new List<Location>();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------GET TABLE LOCATIONS BY ID-------------------------------------------
        public Location getbyid(int id)
        {
            var _conn = Connection.get();
            var location = new Location();

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

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        location.Id = reader.GetInt32(0);
                        location.StreetAddress = (reader.IsDBNull(1) ? "" : reader.GetString(1));
                        location.PostalCode = (reader.IsDBNull(2) ? "" : reader.GetString(2));
                        location.City = reader.GetString(3);
                        location.StateProvince = (reader.IsDBNull(4) ? "" : reader.GetString(4));
                        location.CountryId = (reader.IsDBNull(5) ? "" : reader.GetString(5));
                    }

                    reader.Close();
                    return location;
                }

            }
            catch
            {
                return new Location();
            }
            finally
            {
                _conn.Close();
            }
        }
        //----------------------------------------------------------INSERT TABLE LOCATIONS-------------------------------------------
        public int insert(Location location)
        {
            var _conn = Connection.get();

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
                pId.Value = location.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pAddress = new SqlParameter();
                pAddress.ParameterName = "@street_address";
                pAddress.SqlDbType = SqlDbType.VarChar;
                pAddress.Value = location.StreetAddress;
                sqlCommand.Parameters.Add(pAddress);

                SqlParameter pPcode = new SqlParameter();
                pPcode.ParameterName = "@postal_code";
                pPcode.SqlDbType = SqlDbType.VarChar;
                pPcode.Value = location.PostalCode;
                sqlCommand.Parameters.Add(pPcode);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = SqlDbType.VarChar;
                pCity.Value = location.City;
                sqlCommand.Parameters.Add(pCity);

                SqlParameter pProvince = new SqlParameter();
                pProvince.ParameterName = "@state_province";
                pProvince.SqlDbType = SqlDbType.VarChar;
                pProvince.Value = location.StateProvince;
                sqlCommand.Parameters.Add(pProvince);

                SqlParameter pCountryid = new SqlParameter();
                pCountryid.ParameterName = "@country_id";
                pCountryid.SqlDbType = SqlDbType.VarChar;
                pCountryid.Value = location.CountryId;
                sqlCommand.Parameters.Add(pCountryid);

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
        //----------------------------------------------------------UPDATE TABLE LOCATIONS-------------------------------------------
        public int update(Location location)
        {
            var _conn = Connection.get();

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
                pId.Value = location.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pAddress = new SqlParameter();
                pAddress.ParameterName = "@street_address";
                pAddress.SqlDbType = SqlDbType.VarChar;
                pAddress.Value = location.StreetAddress;
                sqlCommand.Parameters.Add(pAddress);

                SqlParameter pPcode = new SqlParameter();
                pPcode.ParameterName = "@postal_code";
                pPcode.SqlDbType = SqlDbType.VarChar;
                pPcode.Value = location.PostalCode;
                sqlCommand.Parameters.Add(pPcode);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = SqlDbType.VarChar;
                pCity.Value = location.City;
                sqlCommand.Parameters.Add(pCity);

                SqlParameter pProvince = new SqlParameter();
                pProvince.ParameterName = "@state_province";
                pProvince.SqlDbType = SqlDbType.VarChar;
                pProvince.Value = location.StateProvince;
                sqlCommand.Parameters.Add(pProvince);

                SqlParameter pCountryid = new SqlParameter();
                pCountryid.ParameterName = "@country_id";
                pCountryid.SqlDbType = SqlDbType.VarChar;
                pCountryid.Value = location.CountryId;
                sqlCommand.Parameters.Add(pCountryid);


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
        //----------------------------------------------------------DELETE TABLE LOCATIONS-------------------------------------------
        public int delete(int id)
        {
            var _conn = Connection.get();

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
        //----------------------------------------------------------END OF TABLE LOCATIONS--------------------------------------
    }
}
