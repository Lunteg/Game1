using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.SearchIn
{
    public class SearchInUser
    {
        public string UserName { get; set; } //фильтр
        public int? Top { get; set; }
        public int? Skip { get; set; }
    }
}
