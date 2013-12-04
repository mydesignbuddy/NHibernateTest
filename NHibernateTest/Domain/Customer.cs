using System;
using System.Text;
using Iesi.Collections.Generic;

namespace NHibernateTest.Domain
{
    public class Customer
    {
        public Customer()
        {
            MemberSince = DateTime.Now;
            Orders = new HashedSet<Order>();
        }

        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime MemberSince { get; set; }
        public virtual Location Address { get; set; }
        public virtual ISet<Order> Orders { get; set; }

        public virtual void AddOrder(Order order)
        {
            Orders.Add(order);
            order.Customer = this;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("{1} {2} ({0})\r\n\t# of Orders: {3}\r\n", Id, FirstName, LastName, Orders.Count);
            result.AppendLine("\tOrders:");
            foreach (var order in Orders)
            {
                result.AppendLine("\t\t" + order);
            }
            return result.ToString();
        }
    }
}
