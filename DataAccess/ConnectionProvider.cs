
using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionProvider
    {

        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=localhost;Database=TelefonRehberi;Integrated Security=True");
        }
    }
}
