using FluffTailRanking.BusinessLayer.BusinessObjects;
using FluffTailRanking.BusinessLayer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffTailRanking.BusinessLayer.BusinessObjects
{
    public class Team : IEloRateable
    {

        public int ID { get; set; }
        public string TeamName { get; set; }

        public int Wins { get; set; }
        public int Losts { get; set; }
        public double WLRation
        {
            get
            {
                if (Wins != null && Losts != null & Losts > 0)
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

        public List<Player> Players = new List<Player>();

        public override int ELOID
        {
            get
            {
                return ID;
            }
        }

        public override string Name
        {
            get
            {
                return TeamName;
            }
        }

        public Team()
        {
            EloRatingNumber = 1000;
        }

        
        public override bool Equals(object obj)
        {
            return false;
        }
    }
}
