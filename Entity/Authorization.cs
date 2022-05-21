using System;

namespace Entity
{
    public class Authorization
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public int Id { get; set; }
        public byte[] HashPassword { get; set; }
        public double Total { get; set; }
    }
}
