using DokuzSistemBase.Core.Helper;
using DokuzSistemBase.Data.Dorm;
using System.Data.SqlClient;
using System.Data;
using TelefonRehberi.Shared;

namespace TelefonRehberi.API.Application
{
    public class Create
    {
        IDbConnection conn;

        public Create()
        {
            conn = new SqlConnection(DokuzJsonManager.GetAppSetting().GetConnectionString("DefaultConnection"));
        }

        public long KisiEkle(Kisi kisi)
        {
            try
            {
                var eklenenKisi = conn.Insert(kisi, TableName: "Kisiler");
                return eklenenKisi.Id;
            }
            catch
            {
                return 0;
            }
        }

        public bool MenuEkle(MenuClass menu)
        {
            var eklenenMenu = conn.Insert(menu, TableName: "Menuler");
            return eklenenMenu.Id > 0;
        }
    }
}
