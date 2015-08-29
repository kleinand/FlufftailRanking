using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluffTailRanking.Persistence.SqLite.DataModels;

namespace FluffTailRanking.Persistence.SqLite.DataAccess
{
    /// <summary>
    /// http://social.technet.microsoft.com/wiki/contents/articles/18417.windows-store-app-with-a-sqlite-database.aspx
    /// </summary>
    public class DbConnection: IDbConnection
    {
        private string dbPath;
        private SQLiteConnection connection;

        public DbConnection()
        {
            dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "AppStore.sqlite");
            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            connection = new SQLiteConnection(platform, dbPath);
        }

        public async Task InitializeDatabase()
        {
            // TODO
            connection.CreateTable<Player>();
            connection.CreateTable<Team>();
            connection.CreateTable<Game>();
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }
    }
}
