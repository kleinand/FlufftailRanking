using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluffTailRanking.BusinessLayer;
using FluffTailRanking.BusinessLayer.BusinessObjects;
using FluffTailRanking.BusinessLayer.Persistence;

namespace Kicker4Namics.BusinessLayer
{
    public class Facade
    {
        public IPersistenceManager persistentManager {get; set;}

        public Facade() { }

        public IEnumerable<Team> GetTeams()
        {
            IEnumerable<Team> teams = persistentManager.GetAllTeams();
            return teams;
        }

        public IEnumerable<Player> GetPlayers()
        {
            IEnumerable<Player> players = persistentManager.GetAllPlayers();
            return players;
        }

        public Player PlayerById(int id)
        {
            return persistentManager.GetPlayerById(id);
        }

        public IEnumerable<Game> GetGames()
        {
            IEnumerable<Game> games = persistentManager.GetAllGames();
            return games;
        }

        public int GetPlayerWins(Player p)
        {
            return persistentManager.GetWinsOfPlayer(p);
        }

        public int GetTeamWins(Team t)
        {
            return persistentManager.GetWinsOfTeam(t);
        }

        public int AddPlayer(FluffTailRanking.BusinessLayer.BusinessObjects.Player newplayer)
        {
            try
            {
                return persistentManager.SavePlayer(newplayer);
            }
            catch (Exception ex)
            {
                return 0;
            }
            
        }

        public int AddGame(Game newgame)
        {
            try
            {
                return persistentManager.SaveGame(newgame);
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
