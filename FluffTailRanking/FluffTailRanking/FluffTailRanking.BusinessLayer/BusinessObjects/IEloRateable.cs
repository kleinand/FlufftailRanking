using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffTailRanking.BusinessLayer.BusinessObjects
{
    public class IEloRateable
    {
        public virtual int ELOID { get; set; }
        public virtual string Name { get; set; }
        public double EloRatingNumber { get; set; }
    }
}
