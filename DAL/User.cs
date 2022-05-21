using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class User
    {
        public User()
        {
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public double Total { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
