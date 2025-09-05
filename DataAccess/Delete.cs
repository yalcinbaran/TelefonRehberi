using DataAccess.Models;
using DokuzSistemBase.Data.Dorm;
using System.Data;

namespace DataAccess
{
    public class Delete
    {
        private readonly IDbConnection conn;
        public Delete(ConnectionProvider connection)
        {
            conn = connection.GetConnection();
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

        public bool KisiTopluSil(List<long> kisiIdler)
        {
            List<Kisi> tumkisiler = new();
            foreach (var id in kisiIdler)
            {
                var kisi = conn.QueryToFirstOrDefault<Kisi>("Select * from Kisiler Where Id = @Id", new { Id = id });
                if (kisi != null)
                {
                    tumkisiler.Add(kisi);
                }
            }
            var trn = conn.BeginTransaction();
            using (trn)
            {
                try
                {
                    var silinenKisiler = conn.Delete(tumkisiler, transaction: trn, TableName: "Kisiler");
                    if (silinenKisiler.Count > 0)
                    {
                        trn.Commit();
                        return true;
                    }
                    else
                    {
                        trn.Rollback();
                        return false;
                    }
                }
                catch
                {
                    trn.Rollback();
                    return false;
                }
            }
        }

    }
}
