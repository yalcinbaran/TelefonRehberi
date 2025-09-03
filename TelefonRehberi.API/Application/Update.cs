using DokuzSistemBase.Core.Helper;
using DokuzSistemBase.Data.Dorm;
using System.Data.SqlClient;
using System.Data;
using TelefonRehberi.Shared;

namespace TelefonRehberi.API.Application
{
    public class Update
    {
        IDbConnection conn;

        public Update()
        {
            conn = new SqlConnection(DokuzJsonManager.GetAppSetting().GetConnectionString("DefaultConnection"));
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
