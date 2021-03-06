﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;
using SQLite.Net.Attributes;

namespace FluffTailRanking.Persistence.SqLite.DataModels
{    
    [Table("Players")]
    public class Player
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Forename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

        public int Wins { get; set; }
        public int Losts { get; set; }
    }
}
