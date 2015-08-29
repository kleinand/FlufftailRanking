using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using FluffTailRanking.BusinessLayer.BusinessObjects;
using SQLite.Net;

namespace FluffTailRanking.Persistence.SqLite.DataAccess
{
    public class SQLitePersistenceManager : FluffTailRanking.BusinessLayer.Persistence.IPersistenceManager
    {
        private SQLiteConnection conn;

        public SQLitePersistenceManager()
        {
            conn = new DbConnection().GetConnection();
        }

        public List<Game> GetAllGames()
        {
            List<FluffTailRanking.Persistence.SqLite.DataModels.Game> results = conn.Query<FluffTailRanking.Persistence.SqLite.DataModels.Game>("SELECT * FROM Games", null);
            return null;
        }

        public List<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public List<Team> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayerById(int uid)
        {
            throw new NotImplementedException();
        }

        public int GetWinsOfPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public int GetWinsOfTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public int SaveGame(Game game)
        {
            throw new NotImplementedException();
        }

        public int SavePlayer(Player player)
        {
            
            throw new NotImplementedException();
        }

        public int SaveTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
