using DokuzSistemBase.Core.Helper;
using DokuzSistemBase.Data.Dorm;
using System.Data.SqlClient;
using System.Data;
using TelefonRehberi.Shared;

namespace TelefonRehberi.API.Application
{
    public class Read
    {
        readonly IDbConnection conn;

        public Read()
        {
            conn = new SqlConnection(DokuzJsonManager.GetAppSetting().GetConnectionString("DefaultConnection"));
        }

        public List<Kisi> GetAll()
        {
            try
            {
                List<Kisi> kisiler = conn.Query<Kisi>("Select * From Kisiler").ToList();
                return kisiler;
            }
            catch
            {
                return new List<Kisi>();
            }
        }

        public Kisi? GetById(long id)
        {
            try
            {
                var kisi = conn.QueryToFirstOrDefault<Kisi>("Select * From Kisiler Where Id=@Id", new { Id = id });
                return kisi;
            }
            catch
            {
                return null;
            }
        }

        public List<MenuClass> GetAllMenu()
        {
            try
            {
                var menuler = conn.Query<MenuClass>("Select * From Menuler").ToList();
                return menuler;
            }
            catch
            {
                return new List<MenuClass>();
            }
        }
    }
}
