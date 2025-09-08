using DokuzSistemBase.Data.Dorm;
using System.Data;
using TelefonRehberi.Operations.Models;

namespace TelefonRehberi.Operations
{
    public class KisiOperations
    {
        private readonly ConnectionProvider _connectionProvider;
        private IDbConnection conn => _connectionProvider.GetConnection();
        public KisiOperations(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
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

        public long KisiEkle(Kisi kisi)
        {
            var eklenenKisi = conn.Insert(kisi, TableName: "Kisiler");
            return eklenenKisi.Id;
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

        public bool KisiSilById(long Id)
        {
            var kisi = conn.QueryToFirstOrDefault<Kisi>("Select * from Kisiler Where Id = @Id", new { Id = Id });
            var silinenKisi = conn.Delete(kisi, TableName: "Kisiler");
            if (silinenKisi != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
