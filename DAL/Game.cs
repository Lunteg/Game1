﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Game
    {
        public Game()
        {
            Maps = new HashSet<Map>();
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Host { get; set; }

        public virtual ICollection<Map> Maps { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
