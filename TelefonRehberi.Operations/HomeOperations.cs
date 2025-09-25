using DokuzSistemBase.Data.Dorm;
using System.Data;
using TelefonRehberi.Operations.Models;

namespace TelefonRehberi.Operations
{
    public class HomeOperations
    {
        private readonly ConnectionProvider _connectionProvider;
        private IDbConnection conn => _connectionProvider.GetConnection();
        public HomeOperations(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public IEnumerable<Kisi> GetAll()
        {
            try
            {
                IEnumerable<Kisi> kisiler = conn.Query<Kisi>("Select * From Kisiler");
                return kisiler;
            }
            catch
            {
                return Enumerable.Empty<Kisi>();
            }
        }

        public IEnumerable<Kisi> GetAllBySearchKeyword(string? keyword)
        {
            string query = "SELECT * FROM Kisiler WHERE (ISNULL(Adi, '') + ISNULL(Soyadi, '') + ISNULL(CepTel, '') +  ISNULL(IsTel, '') + ISNULL(Adres1, '') + ISNULL(Adres2, '')) LIKE '%' + @keyword + '%'";
            //string query = "SELECT * FROM Kisiler WHERE (Adi+Soyadi+CepTel+IsTel+Adres1+Adres2) Like @keyword";

            var filteredKisiler = conn.Query<Kisi>(query, new { keyword = keyword ?? string.Empty });
            return filteredKisiler;
        }
        public DataTable GetAllDataTableBySearchKeyword(string? keyword)
        {
            string query = "SELECT * FROM Kisiler WHERE (ISNULL(Adi, '') + ISNULL(Soyadi, '') + ISNULL(CepTel, '') +  ISNULL(IsTel, '') + ISNULL(Adres1, '') + ISNULL(Adres2, '')) LIKE '%' + @keyword + '%'";
            //string query = "SELECT * FROM Kisiler WHERE (Adi+Soyadi+CepTel+IsTel+Adres1+Adres2) Like @keyword";

            var filteredKisiler = conn.Query<Kisi>(query, new { keyword = keyword ?? string.Empty });
            DataTable dt = new();
            DataSet filtreliler = new();
            filtreliler.Tables.Add(dt);
            filtreliler.Tables[0].Columns.Add("Id", typeof(int));
            filtreliler.Tables[0].Columns.Add("Adi", typeof(string));
            filtreliler.Tables[0].Columns.Add("Soyadi", typeof(string));
            filtreliler.Tables[0].Columns.Add("CepTel", typeof(string));
            filtreliler.Tables[0].Columns.Add("IsTel", typeof(string));
            filtreliler.Tables[0].Columns.Add("Adres1", typeof(string));
            filtreliler.Tables[0].Columns.Add("Adres2", typeof(string));
            foreach (var item in filteredKisiler)
            {
                filtreliler.Tables[0].Rows.Add(item.Id, item.Adi, item.Soyadi, item.CepTel, item.IsTel, item.Adres1, item.Adres2);
            }
            return dt;
        }
    }
}
