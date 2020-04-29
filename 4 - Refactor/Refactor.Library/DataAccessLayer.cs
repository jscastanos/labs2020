using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Refactor.Library
{
    public class DataAccessLayer
    {
        public static string ConnectionString { get; set; } = ConfigurationManager.ConnectionStrings["DapperDemoDB"].ConnectionString;
        private readonly IDbConnection cnn = new SqlConnection(ConnectionString);

        public List<UserModel> GetUser()
        {
            return cnn.Query<UserModel>("spSystemUser_Get", commandType: CommandType.StoredProcedure).ToList();
        }

        public void CreateUser(object user)
        {
            cnn.Execute("dbo.spSystemUser_Create", user, commandType: CommandType.StoredProcedure);
        }

        public List<UserModel> FilterUser(object filter)
        {
            return cnn.Query<UserModel>("spSystemUser_GetFiltered", filter, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}