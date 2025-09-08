using DataAccess.Models;
using DokuzSistemBase.Data.Dorm;
using System.Data;

namespace DataAccess
{
    public class Read
    {
        private readonly IDbConnection conn;
        public Read(ConnectionProvider connection)
        {
            conn = connection.GetConnection();
        }

        public IEnumerable<MenuClass> GetAllMenu()
        {
            try
            {
                var menuler = conn.Query<MenuClass>("Select * From Menuler");
                return menuler;
            }
            catch
            {
                return new List<MenuClass>();
            }
        }
    }
}
