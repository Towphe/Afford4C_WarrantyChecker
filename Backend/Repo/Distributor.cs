using System;
using System.Collections.Generic;

namespace Repo
{
    public partial class Distributor
    {
        public Distributor()
        {
            Policies = new HashSet<Policy>();
            Products = new HashSet<Product>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateOnly? DateAdded { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
