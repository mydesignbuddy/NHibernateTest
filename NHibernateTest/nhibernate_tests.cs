using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Hql.Ast.ANTLR;
using NHibernate.Linq;
using NHibernateTest.Domain;
using NUnit.Framework;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace NHibernateTest
{
    [TestFixture]
    public class nhibernate_tests
    {
        private ISessionFactory sessionFactory;

        [SetUp]
        public void Init()
        {
            var cfg = new Configuration();
            /** ========================================================
             *  Loquacious style of configuration (Code based)
                ======================================================== */
            /*cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=localhost;Database=nhibernate_learning;Uid=appUser;Pwd=appPassword;";
                x.Driver<MySqlDataDriver>();
                x.Dialect<MySQL5Dialect>();
                x.LogSqlInConsole=true;
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());*/

            /** ========================================================
             *  Load Hibernate XML configuration (hibernate.cfg.xml)
                ======================================================== */
            cfg.Configure();

            sessionFactory = cfg.BuildSessionFactory();
        }

        [Test]
        public void Query_with_Criteria()
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var customers = session.CreateCriteria<Customer>().List<Customer>();

                    foreach (var customer in customers)
                    {
                        Console.WriteLine("Id: {0} Name: {1} {2} ", customer.Id, customer.FirstName, customer.LastName);
                    }
                    trans.Commit();
                }
            }
        }


        [Test]
        public void Query_with_Linq()
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var customers = from customer in session.Query<Customer>()
                                    where customer.LastName.StartsWith("T") 
                                    orderby customer.FirstName descending 
                                    select customer;

                    foreach (var customer in customers)
                    {
                        Console.WriteLine("Id: {0} Name: {1} {2} ", customer.Id, customer.FirstName, customer.LastName);
                    }
                    trans.Commit();
                }
            }
        }

        [Test]
        public void Create_Record()
        {
            using (var session = sessionFactory.OpenSession())
            {
                int lastInsertedId;
                using (var trans = session.BeginTransaction())
                {
                    var customer = new Customer
                    {
                        FirstName = "Bill",
                        LastName = "Crystal"
                    };
                    session.Save(customer);
                    lastInsertedId = customer.Id;
                    Console.WriteLine("Last Inserted ID: {0}", customer.Id);
                    trans.Commit();
                }

                using (var trans = session.BeginTransaction())
                {
                    var customerReadBack = session.Load<Customer>(lastInsertedId);
                    Console.WriteLine("Id: {0} Name: {1} {2} ", customerReadBack.Id, customerReadBack.FirstName, customerReadBack.LastName);
                    trans.Commit();
                }
            }
        }


        [Test]
        public void Create_Record_with_component()
        {
            using (var session = sessionFactory.OpenSession())
            {
                int lastInsertedId;
                using (var trans = session.BeginTransaction())
                {
                    var customer = new Customer
                    {
                        FirstName = "Bill",
                        LastName = "Crystal",
                        Address = new Location
                        {
                            Street = "1234 Some Street",
                            City = "Houston",
                            Province = "TX",
                            Country = "US"
                        }
                    };
                    session.Save(customer);
                    lastInsertedId = customer.Id;
                    Console.WriteLine("Last Inserted ID: {0}", customer.Id);
                    trans.Commit();
                }

                using (var trans = session.BeginTransaction())
                {
                    var customerReadBack = session.Load<Customer>(lastInsertedId);
                    Console.WriteLine("Id: {0} Name: {1} {2} ", customerReadBack.Id, customerReadBack.FirstName, customerReadBack.LastName);
                    trans.Commit();
                }
            }
        }

        [Test]
        public void Update_Record()
        {
            using (var session = sessionFactory.OpenSession())
            {
                int lastInsertedId;
                using (var trans = session.BeginTransaction())
                {
                    var customers = from customer in session.Query<Customer>()
                                    where customer.LastName == "Crystal"
                                    select customer;
                    foreach (var customer in customers)
                    {
                        customer.FirstName = "Billy";
                        session.Save(customer);
                    }
                    trans.Commit();
                }
            }
        }

        [Test]
        public void Delete_Record()
        {
            using (var session = sessionFactory.OpenSession())
            {
                int lastInsertedId;
                using (var trans = session.BeginTransaction())
                {
                    var customers = from customer in session.Query<Customer>()
                        where customer.LastName == "Crystal"
                        select customer;
                    foreach (var customer in customers)
                    {
                        session.Delete(customer);
                    }
                    trans.Commit();
                }
            }
        }

        #region Relationships
        [Test]
        public void Create_Record_with_one_to_many()
        {
            using (var session = sessionFactory.OpenSession())
            {
                int lastInsertedId;
                using (var trans = session.BeginTransaction())
                {
                    var customer = new Customer
                    {
                        FirstName = "Bill",
                        LastName = "Crystal",
                        Address = new Location
                        {
                            Street = "1234 Some Street",
                            City = "Houston",
                            Province = "TX",
                            Country = "US"
                        }
                    };

                    var order1 = new Order
                    {
                        Ordered = DateTime.Now.AddDays(-1),
                        Shipped = DateTime.Now,
                        ShipTo = new Location
                        {
                            Street = "1234 Some Street",
                            City = "Houston",
                            Province = "TX",
                            Country = "US"
                        }
                    };
                    customer.AddOrder(order1);

                    var order2 = new Order
                    {
                        Ordered = DateTime.Now
                    };
                    customer.AddOrder(order2);

                    session.Save(customer);
                    lastInsertedId = customer.Id;
                    Console.WriteLine("Last Inserted ID: {0}", customer.Id);
                    trans.Commit();
                }

                using (var trans = session.BeginTransaction())
                {
                    var customerReadBack = session.Load<Customer>(lastInsertedId);
                    Console.WriteLine("Id: {0} Name: {1} {2} ", customerReadBack.Id, customerReadBack.FirstName, customerReadBack.LastName);
                    trans.Commit();
                }
            }
        }
        #endregion
    }
}
