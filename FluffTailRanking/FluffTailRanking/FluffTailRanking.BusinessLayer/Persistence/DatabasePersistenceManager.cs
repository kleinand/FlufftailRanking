using FluffTailRanking.BusinessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluffTailRanking.BusinessLayer.BusinessObjects;

namespace FluffTailRanking.BusinessLayer.Persistence
{
    public class DatabasePersistenceManager : IPersistenceManager
    {
        /// <summary>
        /// Constructor without Parameters
        /// </summary>
        public DatabasePersistenceManager() { }

        /// <summary>
        /// Checks if a player is in a team
        /// </summary>
        /// <param name="team">(Team) Team to proof</param>
        /// <param name="player">(Player) Player to proof</param>
        /// <returns>(Bool) True or False</returns>
        public bool IsPlayerInTeam(FluffTailRanking.BusinessLayer.BusinessObjects.Team team, FluffTailRanking.BusinessLayer.BusinessObjects.Player player)
        {
            if (team.Players[0].ID == player.ID || team.Players[1].ID == player.ID)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get all teams by player ID
        /// </summary>
        /// <param name="p">Player Object</param>
        /// <returns>List of Teams</returns>
        public IEnumerable<FluffTailRanking.BusinessLayer.BusinessObjects.Team> GetTeamsByPlayer(FluffTailRanking.BusinessLayer.BusinessObjects.Player p)
        {
            IEnumerable<FluffTailRanking.BusinessLayer.BusinessObjects.Game> allGames = GetAllGames();
            List<FluffTailRanking.BusinessLayer.BusinessObjects.Team> pTeams = new List<FluffTailRanking.BusinessLayer.BusinessObjects.Team>();

            foreach (var game in allGames)
            {
                if (IsPlayerInTeam(game.Team1, p))
                {
                    pTeams.Add(game.Team1);
                }
                else if (IsPlayerInTeam(game.Team2, p))
                {
                    pTeams.Add(game.Team2);
                }
            }
            return pTeams;
        }

        /// <summary>
        /// Get a specific Player with his User ID
        /// </summary>
        /// <param name="uid">Users unique Identifier</param>
        /// <returns>Playerobject</returns>
        public FluffTailRanking.BusinessLayer.BusinessObjects.Player GetPlayerById(int uid)
        {
            FluffTailRanking.BusinessLayer.BusinessObjects.Player player = new FluffTailRanking.BusinessLayer.BusinessObjects.Player();
            using (KickerEntities context = new KickerEntities())
            {
                var query =
                    from pl in context.Player
                    where pl.id == uid
                    select new
                    {
                        firstname = pl.forename,
                        lastname = pl.lastname,
                        nickname = pl.nickname,
                        eloid = pl.eloid,
                        email = pl.email,
                        grav = pl.gravatarhash,
                        id = pl.id,
                        w = pl.wins,
                        l = pl.losts
                    };
                foreach (var matches in query)
                {
                    player.Forename = matches.firstname;
                    player.Lastname = matches.lastname;
                    player.Nickname = matches.nickname;
                    player.EloRatingNumber = matches.eloid;
                    player.Email = matches.email;
                    player.ID = matches.id;
                    player.Wins = matches.w;
                    player.Losts = matches.l;
                }
                return player;
            }
        }

        /// <summary>
        /// Get a specific Team with its Team ID
        /// </summary>
        /// <param name="tid">ID of Team</param>
        /// <returns>A team with the ID</returns>
        public FluffTailRanking.BusinessLayer.BusinessObjects.Team GetTeamById(int tid)
        {
            FluffTailRanking.BusinessLayer.BusinessObjects.Team team = new FluffTailRanking.BusinessLayer.BusinessObjects.Team();
            using (KickerEntities context = new KickerEntities())
            {
                var query =
                    from tm in context.Team
                    where tm.id == tid
                    select new
                    {
                        tn = tm.teamname,
                        w = tm.wins,
                        eloid = tm.eloid,
                        p1id = tm.playerone,
                        p2id = tm.playertwo,
                        id = tm.id
                    };

                foreach (var matches in query)
                {
                    FluffTailRanking.BusinessLayer.BusinessObjects.Player p1 = GetPlayerById(matches.p1id),
                                                         p2 = GetPlayerById(matches.p2id);
                    team.Players.Add(p1);
                    team.Players.Add(p2);
                    team.ID = matches.id;
                    team.TeamName = matches.tn;
                    team.EloRatingNumber = matches.eloid;
                    team.Name = matches.tn;
                    team.Wins = (int)(p1.Wins + p2.Wins);
                }
                return team;
            }
        }

        /// <summary>
        /// Get all wins of a team
        /// </summary>
        /// <param name="t">Team to get wins</param>
        /// <returns>Integer counting wins</returns>
        public int GetWinsOfTeam(FluffTailRanking.BusinessLayer.BusinessObjects.Team t)
        {
            int wins = 0;
            IEnumerable<FluffTailRanking.BusinessLayer.BusinessObjects.Game> games = GetAllGames();
            foreach(var that in games) {
                if (that.Winner.ID == t.ID)
                {
                    wins++;
                }
            }
            return wins;
        }

        /// <summary>
        /// Get wins of a player
        /// </summary>
        /// <param name="p">Player object</param>
        /// <returns>Integer counting wins</returns>
        public int GetWinsOfPlayer(FluffTailRanking.BusinessLayer.BusinessObjects.Player p)
        {
            return GetTeamsByPlayer(p).Count();
        }

        /// <summary>
        /// Get All Players from the Database
        /// </summary>
        /// <returns>List with Playerobjects</returns>
        public List<FluffTailRanking.BusinessLayer.BusinessObjects.Player> GetAllPlayers()
        {
            List<FluffTailRanking.BusinessLayer.BusinessObjects.Player> players = new List<FluffTailRanking.BusinessLayer.BusinessObjects.Player>();
            using (KickerEntities contex = new KickerEntities())
            {
                var query =
                    from player in contex.Player
                    select new
                    {
                        id = player.id
                    };

                foreach (var matches in query)
                {
                    FluffTailRanking.BusinessLayer.BusinessObjects.Player player = GetPlayerById(matches.id);
                    players.Add(player);
                }
                return players;
            }
        }

        /// <summary>
        /// Get all Teams from the Database
        /// </summary>
        /// <returns>List with Teamobjects</returns>
        public List<FluffTailRanking.BusinessLayer.BusinessObjects.Team> GetAllTeams()
        {
            List<FluffTailRanking.BusinessLayer.BusinessObjects.Team> teams = new List<FluffTailRanking.BusinessLayer.BusinessObjects.Team>();
            using (KickerEntities contex = new KickerEntities())
            {
                var query =
                    from team in contex.Team
                    select new
                    {
                        id = team.id
                    };
                foreach (var matches in query)
                {
                    FluffTailRanking.BusinessLayer.BusinessObjects.Team team = GetTeamById(matches.id);
                    teams.Add(team);
                }
                return teams;
            }
        }

        /// <summary>
        /// Get all Games out of the Database
        /// </summary>
        /// <returns>List with all Games</returns>
        public List<FluffTailRanking.BusinessLayer.BusinessObjects.Game> GetAllGames()
        {
            List<FluffTailRanking.BusinessLayer.BusinessObjects.Game> games = new List<FluffTailRanking.BusinessLayer.BusinessObjects.Game>();
            using (KickerEntities contex = new KickerEntities())
            {
                var query =
                    from game in contex.Game
                    select new
                    {
                        id = game.id,
                        date = game.date,
                        winner = game.winner,
                        t1 = game.teamone,
                        t2 = game.teamtwo
                    };

                foreach (var matches in query)
                {
                    FluffTailRanking.BusinessLayer.BusinessObjects.Game game = new FluffTailRanking.BusinessLayer.BusinessObjects.Game()
                    {
                        ID = matches.id,
                        Team1 = GetTeamById(matches.t1),
                        Team2 = GetTeamById(matches.t2),
                        Date = matches.date,
                        Winner = GetTeamById(matches.winner)
                    };
                    games.Add(game);
                }
            };

            return games;
        }

        /// <summary>
        /// Save a Player to the Database
        /// </summary>
        /// <param name="player">Playerobject to Save</param>
        /// <returns>1 if successfull, otherwise 0</returns>
        public int SavePlayer(FluffTailRanking.BusinessLayer.BusinessObjects.Player player)
        {
            player = player == null ? new FluffTailRanking.BusinessLayer.BusinessObjects.Player() : player;
            try
            {
                using (KickerEntities context = new KickerEntities())
                {
                    FluffTailRanking.BusinessLayer.Persistence.Player current = new FluffTailRanking.BusinessLayer.Persistence.Player()
                    {
                        id = player.ID,
                        lastname = player.Lastname,
                        forename = player.Forename,
                        eloid = player.ELOID,
                        email = player.Email,
                        gravatarhash = player.GetHashCode().ToString()
                    };
                    context.Player.Add(current);
                    context.SaveChanges();
                }

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }  
        }

        /// <summary>
        /// Save a Team to the Database
        /// </summary>
        /// <param name="team">Teamobject to Save</param>
        /// <returns>1 if successfull, otherwise 0</returns>
        public int SaveTeam(FluffTailRanking.BusinessLayer.BusinessObjects.Team team)
        {
            try
            {
                using (KickerEntities context = new KickerEntities())
                {
                    FluffTailRanking.BusinessLayer.Persistence.Team current = new FluffTailRanking.BusinessLayer.Persistence.Team()
                    {
                        teamname = team.Name,
                        eloid = team.ELOID,
                        playerone = team.Players[0].ID,
                        playertwo = team.Players[2].ID,
                        id = team.ID,
                        wins = team.Wins
                    };
                    context.Team.Add(current);
                    context.SaveChanges();
                }

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Save a Game to the Database
        /// </summary>
        /// <param name="game">Gameobject to Save</param>
        /// <returns>1 if successfull, otherwise 0</returns>
        public int SaveGame(FluffTailRanking.BusinessLayer.BusinessObjects.Game game)
        {
            try
            {
                using (KickerEntities context = new KickerEntities())
                {
                    FluffTailRanking.BusinessLayer.Persistence.Game current = new FluffTailRanking.BusinessLayer.Persistence.Game()
                    {
                        date = DateTime.Now,
                        teamone = game.Team1.ID,
                        teamtwo = game.Team2.ID,
                        winner = game.Winner.ID
                    };

                    //TODO: Update Player wins / losts on save

                    context.Game.Add(current);
                    context.SaveChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
