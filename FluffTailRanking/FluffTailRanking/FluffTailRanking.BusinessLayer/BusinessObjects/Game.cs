using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluffTailRanking.BusinessLayer.BusinessObjects;

namespace FluffTailRanking.BusinessLayer.BusinessObjects
{
    public class Game
    {
        public int ID { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public DateTime Date {get; set;}

        public Team Winner { get; set; }
    }
}
