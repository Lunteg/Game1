using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Session
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int JoinId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User Join { get; set; }
    }
}
