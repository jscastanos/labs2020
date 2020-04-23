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
        public static string connectionString = ConfigurationManager.ConnectionStrings["DapperDemoDb"].ConnectionString;
        readonly IDbConnection cnn = new SqlConnection(connectionString);


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
