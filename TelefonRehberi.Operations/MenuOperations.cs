using DokuzSistemBase.Data.Dorm;
using System.Data;
using System.Text;
using TelefonRehberi.Operations.Models;

namespace TelefonRehberi.Operations
{
    public class MenuOperations
    {
        private readonly ConnectionProvider _connectionProvider;
        private IDbConnection conn => _connectionProvider.GetConnection();
        public MenuOperations(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public IEnumerable<MenuClass> GetAllMenu()
        {
            try
            {
                var menuler = conn.Query<MenuClass>("Select * From Menuler Order By Id");
                return menuler;
            }
            catch
            {
                return new List<MenuClass>();
            }
        }

        public string GetMenuHTML(IEnumerable<MenuClass> menuler, long parentID, string prefix = "")
        {
            StringBuilder HTMLstr = new();
            var altMenuler = menuler.Where(x => x.ParentId == parentID).OrderBy(x => x.Id).ToList();
            if (altMenuler.Any())
            {
                for (int i = 0; i < altMenuler.Count; i++)
                {
                    HTMLstr.Append("<ul>");
                    var menu = altMenuler[i];
                    var currentPrefix = string.IsNullOrEmpty(prefix) ? (i + 1).ToString() : prefix + "." + (i + 1);
                    HTMLstr.Append($"<li> {currentPrefix} - {menu.MenuAdi}");
                    HTMLstr.Append(GetMenuHTML(menuler, menu.Id, currentPrefix));
                    HTMLstr.Append("</li>");
                    HTMLstr.Append("</ul>");
                }
            }
            return HTMLstr.ToString();
        }

        public Dictionary<string, string> GetMenuList(Dictionary<string, string> menuList, IEnumerable<MenuClass> menuler, long parentID, string prefix = "")
        {
            var altMenuler = menuler.Where(x => x.ParentId == parentID).OrderBy(x => x.Id).ToList();
            if (altMenuler.Any())
            {
                for (int i = 0; i < altMenuler.Count; i++)
                {
                    var menu = altMenuler[i];
                    var currentPrefix = string.IsNullOrEmpty(prefix) ? (i + 1).ToString() : prefix + "." + (i + 1);
                    menuList.Add(menu.Id.ToString(), $"{currentPrefix} - {menu.MenuAdi}");
                    GetMenuList(menuList, menuler, menu.Id, currentPrefix);
                }
            }
            return menuList;
        }


        public bool MenuEkle(MenuClass menu)
        {
            var eklenenMenu = conn.Insert(menu, TableName: "Menuler");
            return eklenenMenu.Id > 0;
        }
    }
}
