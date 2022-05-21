using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.SearchIn
{
    public class SearchInGame
    {
        public int UserID { get; set; } //фильтр
        public int? Top { get; set; }
        public int? Skip { get; set; }
    }
}
