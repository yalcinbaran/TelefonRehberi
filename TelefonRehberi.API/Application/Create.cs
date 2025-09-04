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
    }
}
