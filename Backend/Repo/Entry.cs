using System;
using System.Collections.Generic;

namespace Repo
{
    public partial class Entry
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Variant { get; set; }
        public DateOnly DateAdded { get; set; }
        public string[] Policies { get; set; }

        public virtual Product Product { get; set; }
    }
}
