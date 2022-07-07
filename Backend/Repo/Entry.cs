using System;
using System.Collections.Generic;

namespace Repo
{
    public partial class Entry
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Productname { get; set; }
        public string Variant { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Contactnumber { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string Address { get; set; }
        public short? Postalcode { get; set; }
        public DateOnly Dateadded { get; set; }
        public DateOnly Lastupdated { get; set; }

        public virtual Product Product { get; set; }
    }
}
