using DataAccess.Models;
using DokuzSistemBase.Data.Dorm;
using System.Data;

namespace DataAccess
{
    public class Update
    {
        private readonly IDbConnection conn;
        public Update(ConnectionProvider connection)
        {
            conn = connection.GetConnection();
        }

        public long KisiGuncelle(Kisi kisi)
        {
            try
            {
                var guncellenenKisi = conn.Update(kisi, TableName: "Kisiler");
                return guncellenenKisi.Id;
            }
            catch
            {
                return 0;
            }
        }
    }
}
