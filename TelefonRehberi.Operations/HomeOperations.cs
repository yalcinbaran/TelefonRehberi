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
                return new List<Kisi>();
            }
        }

        public IEnumerable<Kisi> GetAllBySearchKeyword(string? keyword)
        {
            string query = "SELECT * FROM Kisiler WHERE Adi+Soyadi+CepTel+IsTel+Adres1+Adres2 Like '%+@keyword+%'";

            var filteredKisiler = conn.Query<Kisi>(query, new { keyword = keyword ?? string.Empty });
            return filteredKisiler;
        }

    }
}
