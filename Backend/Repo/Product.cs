using System;
using System.Collections.Generic;

namespace Repo
{
    public partial class Product
    {
        public Product()
        {
            Entries = new HashSet<Entry>();
        }

        public string Id { get; set; }
        public string DistributorId { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
        public string Sku { get; set; }
        public string Warrantyperiod { get; set; }
        public short? Warrantyunit { get; set; }
        public DateOnly Dateadded { get; set; }
        public DateOnly Lastupdated { get; set; }

        public virtual Distributor Distributor { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
