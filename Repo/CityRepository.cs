using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models;
using Npgsql;

namespace mvc.Repo
{
    public class CityRepository : CommonRepository
    {
        public List<tblCity> GetAllCitys()
        {
            List<tblCity> cities = new List<tblCity>();
            try
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT c_cityid, c_cityname FROM t_city ", conn))
                {
                    using (var reader =  command.ExecuteReader())
                    {
                        while (reader.Read()){
                            cities.Add(new tblCity
                            {
                                c_cityid = reader.GetInt32(0),
                                c_cityname = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return cities;
        }
    }
}