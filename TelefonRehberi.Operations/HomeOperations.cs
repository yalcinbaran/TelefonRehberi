using DokuzSistemBase.Data.Dorm;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
            string query = @"
        SELECT Adi, Soyadi, CepTel, IsTel, Adres1, Adres2 FROM Kisiler 
        WHERE 
            (ISNULL(Adi, '') LIKE @keyword OR 
             ISNULL(Soyadi, '') LIKE @keyword OR 
             ISNULL(CepTel, '') LIKE @keyword OR 
             ISNULL(IsTel, '') LIKE @keyword OR 
             ISNULL(Adres1, '') LIKE @keyword OR 
             ISNULL(Adres2, '') LIKE @keyword)";

            using SqlDataAdapter dataAdapter = new(query, (SqlConnection)conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@keyword", $"%{keyword ?? ""}%");

            DataTable dt = new();
            dataAdapter.Fill(dt);
            return dt;
        }
    }
}
