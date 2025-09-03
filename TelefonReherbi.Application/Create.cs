using Microsoft.Data.SqlClient;
using System.Data;

namespace TelefonReherbi.Application
{
    public class Create
    {
        readonly IDbConnection conn;
        public Create()
        {
            conn = new SqlConnection();
        }
    }
}
