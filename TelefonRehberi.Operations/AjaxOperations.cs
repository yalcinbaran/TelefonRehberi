using DokuzSistemBase.Data.Dorm;
using System.Data;
using TelefonRehberi.Operations.Models;

namespace TelefonRehberi.Operations
{
    public class AjaxOperations
    {
        private readonly ConnectionProvider? _connectionProvider;
        private IDbConnection conn => _connectionProvider.GetConnection();

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
            string query = "SELECT * FROM Kisiler WHERE Adi LIKE '%' + @keyword + '%' " +
                "                                    OR Soyadi LIKE '%' + @keyword + '%' " +
                "                                    OR CepTel LIKE '%' + @keyword + '%' " +
                "                                    OR IsTel LIKE '%' + @keyword + '%' " +
                "                                    OR Adres1 LIKE '%' + @keyword + '%' " +
                "                                    OR Adres2 LIKE '%' + @keyword + '%'";

            var filteredKisiler = conn.Query<Kisi>(query, new { keyword = keyword ?? string.Empty });
            return filteredKisiler;
        }
    }
}
