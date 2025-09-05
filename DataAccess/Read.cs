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
            var tumKisiler = GetAll();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return tumKisiler;
            }
            
            keyword = keyword.ToLower();
            var filteredKisiler = tumKisiler.Where(k =>
                (!string.IsNullOrEmpty(k.Adi) && k.Adi.ToLower().Trim().Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.Soyadi) && k.Soyadi.ToLower().Replace(" ", "").Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.CepTel) && k.CepTel.ToLower().Replace(" ", "").Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.IsTel) && k.IsTel.ToLower().Replace(" ", "").Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.Adres1) && k.Adres1.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.Adres2) && k.Adres2.ToLower().Contains(keyword))
            );
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
