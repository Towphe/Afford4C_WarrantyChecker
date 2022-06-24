using System;
using System.Collections.Generic;

namespace Repo
{
    public partial class Policy
    {
        public string Id { get; set; }
        public string DistributorId { get; set; }
        public string Name { get; set; }
        public decimal YearsValid { get; set; }
        public DateOnly DateAdded { get; set; }
        public DateOnly DateUpdated { get; set; }

        public virtual Distributor Distributor { get; set; }
    }
}
