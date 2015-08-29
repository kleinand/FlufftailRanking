using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace FluffTailRanking.Persistence.SqLite.DataModels
{
    [Table("Teams")]
    public class Team
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string TeamName { get; set; }

        public int Wins { get; set; }
        public int Losts { get; set; }
    }
}
