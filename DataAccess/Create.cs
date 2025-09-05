using DataAccess.Models;
using DokuzSistemBase.Data.Dorm;
using System.Data;

namespace DataAccess
{
    public class Create
    {
        private readonly IDbConnection conn;
        public Create(ConnectionProvider connection)
        {
            conn = connection.GetConnection();
        }
        public long KisiEkle(Kisi kisi)
        {
            var eklenenKisi = conn.Insert(kisi, TableName: "Kisiler");
            return eklenenKisi.Id;
        }

        public bool MenuEkle(MenuClass menu)
        {
            var eklenenMenu = conn.Insert(menu, TableName: "Menuler");
            return eklenenMenu.Id > 0;
        }
    }
}
