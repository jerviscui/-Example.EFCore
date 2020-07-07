using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedEntities
{
    public class Order
    {
        public int Id { get; set; }

        public StreetAddress ShippingAddress { get; set; }

        //private StreetAddress ShippingAddress2 { get; set; }
    }

    public class StreetAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class Distributor
    {
        public int Id { get; set; }

        public ICollection<StreetAddress> ShippingCenters { get; set; } = new List<StreetAddress>();
    }
}
