using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffTailRanking.BusinessLayer.BusinessObjects
{
    public class DatabasePlayer
    {
        string forename;
        string lastname;
        string email;
        int eloid;
        string nickname;
        string gravatarhash;

        public DatabasePlayer(FluffTailRanking.BusinessLayer.BusinessObjects.Player player)
        {
            this.eloid = player.ELOID;
            this.email = player.Email;
            this.nickname = player.Nickname;
            this.forename = player.Forename;
            this.lastname = player.Lastname;
            this.gravatarhash = player.GetHashCode().ToString();
        }

    }
}
