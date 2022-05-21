using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Map
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Json { get; set; }

        public virtual Game Game { get; set; }
    }
}
