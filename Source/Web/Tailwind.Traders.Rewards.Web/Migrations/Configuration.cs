namespace Tailwind.Traders.Rewards.Web.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tailwind.Traders.Rewards.Web.data;

    internal sealed class Configuration : DbMigrationsConfiguration<ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ContextDB context)
        {
            if (!context.Orders.Any())
            {
                SeedOrders(context);
            }

            if (!context.Customers.Any())
            {
                SeedCustomers(context);
            }
        }

        private void SeedCustomers(ContextDB context)
        {
            var customers = new List<Customer>
            {
                new Customer {
                    CustomerId = 1,
                    AccountCode = "TEST 101",
                    FirstName = "John",
                    LastName = "Doe",
                    FirstAddress = "100 Thames Valley Park",
                    City = "Reading",
                    Country = "United Kingdom",
                    ZipCode = "RG6 1PT",
                    Email = "info@workingdata.co.uk",
                    FaxNumber = "4259990000",
                    MobileNumber = "4253214321",
                    PhoneNumber = "4251231234",
                    Website = "",
                    Active = true,
                    Enrrolled = EnrollmentStatusEnum.Uninitialized
                },
                new Customer {
                    CustomerId = 2,
                    AccountCode = "AC234325",
                    FirstName = "Michael",
                    LastName = "Crump",
                    FirstAddress = "15010 NE 36th St",
                    City = "Redmond",
                    Country = "US",
                    ZipCode = "98052",
                    Email = "mcrump@microsoft.com",
                    FaxNumber = "4259990000",
                    MobileNumber = "4253214321",
                    PhoneNumber = "4251231234",
                    Website = "http://microsoft.com",
                    Active = true,
                    Enrrolled = EnrollmentStatusEnum.Uninitialized
                },
                new Customer {
                    CustomerId = 3,
                    AccountCode = "OK 104",
                    FirstName = "Eduard",
                    LastName = "Tomas",
                    FirstAddress = "1155 NE 8th St",
                    City = "Bellevue",
                    Country = "US",
                    ZipCode = "038278",
                    Email = "v-edutom@microsoft.com",
                    FaxNumber = "4259990000",
                    MobileNumber = "4253214321",
                    PhoneNumber = "4251231234",
                    Website = "",
                    Active = true,
                    Enrrolled = EnrollmentStatusEnum.Uninitialized
                },
                new Customer {
                    CustomerId = 4,
                    AccountCode = "AC234325",
                    FirstName = "Cecil",
                    LastName = "Philip",
                    FirstAddress = "1155 NE 8th St",
                    City = "Bellevue",
                    Country = "US",
                    ZipCode = "038278",
                    Email = "cecil@microsoft.com",
                    FaxNumber = "4259990000",
                    MobileNumber = "4253214321",
                    PhoneNumber = "4251231234",
                    Website = "http://microsoft.com",
                    Active = true,
                    Enrrolled = EnrollmentStatusEnum.Uninitialized
                }
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private void SeedOrders(data.ContextDB context)
        {
            var orders = new List<Order>
            {
                new Order {
                   Code = "192384529",
                   Date = DateTime.Now.AddDays(-3),
                   Type = "Retail",
                   ItemName = "Hammer",
                   Status = "Placed",
                   Total = 100.0M
                },
                new Order {
                   Code = "18903849",
                   Date = DateTime.Now.AddDays(-1),
                   Type = "Web",
                   ItemName = "Wrench",
                   Status = "--",
                   Total = 150.0M
                },
                new Order {
                   Code = "18983945",
                   Date = DateTime.Now.AddDays(-2),
                   Type = "Phone",
                   ItemName = "Cordless Drill",
                   Status = "--",
                   Total = 225.0M
                },
                new Order {
                   Code = "18983990",
                   Date = DateTime.Now.AddDays(-3),
                   Type = "Web",
                   ItemName = "Hammer",
                   Status = "--",
                   Total = 100.0M
                },
                new Order {
                   Code = "18983990",
                   Date = DateTime.Now.AddDays(-4),
                   Type = "Retail",
                   ItemName = "Drill",
                   Status = "--",
                   Total = 225.0M
                },
                new Order {
                   Code = "142184222",
                   Date = DateTime.Now.AddDays(-7),
                   Type = "Sheds",
                   ItemName = "Storage Shed Coated Steel",
                   Status = "placed",
                   Total = 500.0M
                },
                new Order {
                   Code = "142184923",
                   Date = DateTime.Now.AddDays(-10),
                   Type = "Sheds",
                   ItemName = "Outdoor Storage Shed Steel",
                   Status = "--",
                   Total = 150.0M
                },
                new Order {
                   Code = "18983213",
                   Date = DateTime.Now.AddDays(-6),
                   Type = "Heating",
                   ItemName = "Stove",
                   Status = "Placed",
                   Total = 220.0M
                },
                new Order {
                   Code = "189832562",
                   Date = DateTime.Now.AddDays(-3),
                   Type = "Heating",
                   ItemName = "Propane Wall Heater",
                   Status = "--",
                   Total = 320.0M
                },
                new Order {
                   Code = "18988730",
                   Date = DateTime.Now.AddDays(-15),
                   Type = "Security",
                   ItemName = "Outdoor Security Camera",
                   Status = "Placed",
                   Total = 115.0M
                },
                new Order {
                   Code = "18676990",
                   Date = DateTime.Now.AddDays(-25),
                   Type = "Security",
                   ItemName = "Plug-in Indoor Camera",
                   Status = "Placed",
                   Total = 75.0M
                }
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
