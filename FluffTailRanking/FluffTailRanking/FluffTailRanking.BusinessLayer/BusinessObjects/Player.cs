using FluffTailRanking.BusinessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffTailRanking.BusinessLayer.BusinessObjects
{
    public class Player : IEloRateable
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

        public int Wins { get; set; }
        public int Losts { get; set; }
        public double WLRation
        {
            get
            {
                if (Wins != null && Losts != null && Losts > 0)
                {
                    double q = Wins / Losts;
                    return Math.Round(q, 2);
                }
                else
                {
                    return 0;
                }
            }
        }

        public string GravHash 
        {
            get
            {
                return Helper.HashEmailForGravatar(Email);
            }
        }

        public override string Name { 
            get 
            {
                return string.IsNullOrEmpty(Nickname) ? Forename + " " + Lastname : Nickname;
            } 
        }

        public override int ELOID {

            get 
            {
                return ID;
            }
        }

        public Player()
        {
            EloRatingNumber = 1000;
        }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(((IEloRateable)obj).Name);
        }

    }
}
