using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models;
using Npgsql;

namespace mvc.Repo
{
    public class BuyRepository:CommonRepository
    {
        public void buy(tblBuy buy){
            Console.WriteLine(buy.c_quantity);
            Console.WriteLine(buy.c_sid);

            try
            {
                conn.Open();
                using (var command  = new NpgsqlCommand("INSERT INTO t_buy (c_sid, c_quantity)VALUES(@sid, @quantity)", conn)){
                    command.Parameters.AddWithValue("@sid",buy.c_sid);
                    command.Parameters.AddWithValue("@quantity",buy.c_quantity);
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }finally{
                conn.Close();
            }
        }
    }
}