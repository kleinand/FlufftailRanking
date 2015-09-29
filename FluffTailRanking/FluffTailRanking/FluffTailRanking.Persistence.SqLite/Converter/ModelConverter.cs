using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffTailRanking.Persistence.SqLite.Converter
{
    public static class ModelConverter
    {
        public static DataModels.Game ToSQLiteGame(this FluffTailRanking.BusinessLayer.BusinessObjects.Game game)
        {
            var sqLiteModel = new FluffTailRanking.Persistence.SqLite.DataModels.Game
            {
                ID = game.ID,
                Date = game.Date,
                Team1 = game.Team1.ToSQLiteTeam(),
                Team2 = game.Team2.ToSQLiteTeam(),
                Winner = game.Winner.ToSQLiteTeam()
            };
            return sqLiteModel; 
        }

        public static BusinessLayer.BusinessObjects.Game ToBusinessGame(this DataModels.Game game)
        {
            var businessModel = new BusinessLayer.BusinessObjects.Game
            {
                ID = game.ID,
                Date = game.Date,
                Team1 = game.Team1.ToBusinessPlayer(),
                Team2 = game.Team2.ToBusinessPlayer(),
                Winner = game.Winner.ToBusinessPlayer()
            };

            return businessModel;
        }

        public static DataModels.Player ToSQLitePlayer(this FluffTailRanking.BusinessLayer.BusinessObjects.Player player)
        {
            var sqLiteModel = new FluffTailRanking.Persistence.SqLite.DataModels.Player
            {
                ID = player.ID,
                Forename = player.Forename,
                Lastname = player.Lastname,
                Nickname = player.Nickname,
                Email = player.Email,
                Wins = player.Wins,
                Losts = player.Losts
            };

            return sqLiteModel;
        }

        public static BusinessLayer.BusinessObjects.Player ToBusinessPlayer(this DataModels.Player player)
        {
            var businessModel = new BusinessLayer.BusinessObjects.Player
            {
                ID = player.ID,
                Forename = player.Forename,
                Lastname = player.Lastname,
                Nickname = player.Nickname,
                Email = player.Email,
                Wins = player.Wins,
                Losts = player.Losts
            };

            return businessModel;
        }

        public static DataModels.Team ToSQLiteTeam(this FluffTailRanking.BusinessLayer.BusinessObjects.Team team)
        {
            var sqLiteModel = new FluffTailRanking.Persistence.SqLite.DataModels.Team
            {
                ID = team.ID,
                TeamName = team.TeamName,
                Losts = team.Losts,
                Wins = team.Wins                
            };
            return sqLiteModel;
        }

        public static BusinessLayer.BusinessObjects.Team ToBusinessPlayer(this DataModels.Team team)
        {
            var businessModel = new BusinessLayer.BusinessObjects.Team
            {
                ID = team.ID,
                TeamName = team.TeamName,
                Losts = team.Losts,
                Wins = team.Wins
            };

            return businessModel;
        }
    }
}
