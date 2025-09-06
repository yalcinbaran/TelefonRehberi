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

        public IEnumerable<Kisi> GetAllBySearchKeyword(string? keyword)
        {
            //var tumKisiler = GetAll();
            //if (string.IsNullOrWhiteSpace(keyword))
            //{
            //    return tumKisiler;
            //}
            
            //keyword = keyword.ToLower();
            //var filteredKisiler = tumKisiler.Where(k =>
            //    (!string.IsNullOrEmpty(k.Adi) && k.Adi.ToLower().Trim().Contains(keyword)) ||
            //    (!string.IsNullOrEmpty(k.Soyadi) && k.Soyadi.ToLower().Trim().Contains(keyword)) ||
            //    (!string.IsNullOrEmpty(k.CepTel) && k.CepTel.ToLower().Trim().Contains(keyword)) ||
            //    (!string.IsNullOrEmpty(k.IsTel) && k.IsTel.ToLower().Trim().Contains(keyword)) ||
            //    (!string.IsNullOrEmpty(k.Adres1) && k.Adres1.ToLower().Trim().Contains(keyword)) ||
            //    (!string.IsNullOrEmpty(k.Adres2) && k.Adres2.ToLower().Trim().Contains(keyword))
            //);
            //return filteredKisiler;

            string query = "SELECT * FROM Kisiler WHERE @keyword IS NULL OR LTRIM(RTRIM(@keyword)) = '' "+
                                                  "OR LOWER(Adi) LIKE '%' + LOWER(@keyword) + '%'"+
                                                  "OR LOWER(Soyadi) LIKE '%' + LOWER(@keyword) + '%'" +
                                                  "OR LOWER(CepTel) LIKE '%' + LOWER(@keyword) + '%'"+
                                                  "OR LOWER(IsTel) LIKE '%' + LOWER(@keyword) + '%'"+
                                                  "OR LOWER(Adres1) LIKE '%' + LOWER(@keyword) + '%'"+
                                                  "OR LOWER(Adres2) LIKE '%' + LOWER(@keyword) + '%';";

            var filteredKisiler = conn.Query<Kisi>(query, new { keyword = keyword ?? string.Empty });
            return filteredKisiler;
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
