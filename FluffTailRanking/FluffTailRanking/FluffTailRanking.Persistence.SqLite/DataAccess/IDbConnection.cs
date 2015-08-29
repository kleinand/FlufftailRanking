using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SQLite;
using SQLite.Net;

namespace FluffTailRanking.Persistence.SqLite.DataAccess
{
    public interface IDbConnection
    {
        Task InitializeDatabase();
        SQLiteConnection GetConnection();
    }
}
