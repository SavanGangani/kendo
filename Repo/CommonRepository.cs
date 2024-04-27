using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace mvc.Repo
{
    public class CommonRepository
    {
        protected NpgsqlConnection conn;
        public CommonRepository()
        {
            IConfiguration configuration= new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            conn = new NpgsqlConnection(configuration.GetConnectionString("MyConnection"));
            
        } 
    }
}