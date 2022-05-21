using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.SearchOut
{
    public class SearchOutUser
    {
        public int Total { get; set; }
        public int Count { get; set; }
        public List<Entity.Authorization> Users { get; set; }
    }
}
