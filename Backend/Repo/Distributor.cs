using System;
using System.Collections.Generic;

namespace Repo
{
    public partial class Distributor
    {
        public Distributor()
        {
            Products = new HashSet<Product>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Mobilenumber { get; set; }
        public string Telephonenumber { get; set; }
        public string Email { get; set; }
        public string Contactperson { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string Address { get; set; }
        public DateOnly? Dateadded { get; set; }
        public DateOnly? Lastupdated { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
