using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace CatholicBuddies.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "CBDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<Mod> LoadData<Mod>(string sql)
        {
            using(IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<Mod>(sql).ToList();
            }
        }

        public static int SaveData<mod>(string sql, mod data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
