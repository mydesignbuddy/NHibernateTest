using System;
using Iesi.Collections.Generic;

namespace NHibernateTest.Domain
{
    public class Order
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime Ordered { get; set; }
        public virtual DateTime? Shipped { get; set; }
        public virtual Location ShipTo { get; set; }
        public virtual Customer Customer { get; set; }

        public override string ToString()
        {
            return string.Format("Order Id: {0} Date Order: {1} Shipped: {2}", Id, Ordered, Shipped);
        }
    }
}