using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffTailRanking.Persistence.SqLite.Converter
{
    public static class ModelConverter
    {
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
    }
}
