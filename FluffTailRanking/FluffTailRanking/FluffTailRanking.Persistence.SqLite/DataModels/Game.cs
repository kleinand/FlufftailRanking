using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace FluffTailRanking.Persistence.SqLite.DataModels
{
    [Table("Games")]
    public class Game
    {
        [PrimaryKey]
        public Guid ID { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public DateTime Date { get; set; }

        public Team Winner { get; set; }
    }
}
