
using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionProvider
    {

        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=localhost;Database=VoidSystem;User Id=sa;Password=P@ssw0rd;");
        }
    }
}
