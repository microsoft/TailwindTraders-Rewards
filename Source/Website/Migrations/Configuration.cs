namespace Tailwind.Traders.Rewards.Web.Migrations
{
    using System;
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
            context.Customers.Add(new Customer
            {
                CustomerId = 1,
                AccountCode = "AC234323",
                FirstName = "John",
                LastName = "Doe",
                FirstAddress = "562 Mokice View",
                City = "Dundee",
                Country = "United Kingdom",
                ZipCode = "188930",
                Email = "john@workingdata.co.uk",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 2,
                AccountCode = "AC234148",
                FirstName = "Sophie",
                LastName = "Stevenson",
                FirstAddress = "1018 Obevir Extension",
                City = "Chicago",
                Country = "United States",
                ZipCode = "184342",
                Email = "sophie@workingdata.com",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 3,
                AccountCode = "AC451745",
                FirstName = "Trevor",
                LastName = "Adkins",
                FirstAddress = "1508 Hepik Junction",
                City = "Toronto",
                Country = "Canada",
                ZipCode = "44118",
                Email = "trevor@workingdata.com",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 4,
                AccountCode = "AC761459",
                FirstName = "Jessie",
                LastName = "Burton",
                FirstAddress = "385 Akuehe Trail",
                City = "Hobart",
                Country = "Australia",
                ZipCode = "038278",
                Email = "cecil@workingdata.au",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 5,
                AccountCode = "AC741655",
                FirstName = "Steven",
                LastName = "Martin",
                FirstAddress = "1646 Oriro Loop",
                City = "Monterrey",
                Country = "Mexico",
                ZipCode = "154715",
                Email = "steven@workingdata.mx",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 6,
                AccountCode = "AC174967",
                FirstName = "Darrell",
                LastName = "Russell",
                FirstAddress = "1155 NE 8th St",
                City = "Florida",
                Country = "United States",
                ZipCode = "108278",
                Email = "darrell@workingdata.com",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 7,
                AccountCode = "AC714897",
                FirstName = "Maria",
                LastName = "Gordon",
                FirstAddress = "882 Emevo Key",
                City = "Sevilla",
                Country = "Spain",
                ZipCode = "54864",
                Email = "maria@workingdata.com",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 8,
                AccountCode = "AC783452",
                FirstName = "Elijah",
                LastName = "Rodriquez",
                FirstAddress = "1076 Viero Key",
                City = "Rio de Janeiro",
                Country = "Brazil",
                ZipCode = "038278",
                Email = "elijah@workingdata.com",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 9,
                AccountCode = "AC122458",
                FirstName = "Christina",
                LastName = "Meyer",
                FirstAddress = "512 Tadta Pass",
                City = "New York",
                Country = "United States",
                ZipCode = "038278",
                Email = "christina@workingdata.com",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 10,
                AccountCode = "AC458752",
                FirstName = "Olivia",
                LastName = "Cohen",
                FirstAddress = "1916 Pinut Drive",
                City = "Toronto",
                Country = "Canada",
                ZipCode = "458756",
                Email = "olivia@workingdata.com",
                FaxNumber = "4259990000",
                MobileNumber = "4253214321",
                PhoneNumber = "4251231234",
                Website = "http://workingdata.com",
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized
            });

            context.SaveChanges();
        }

        private void SeedOrders(data.ContextDB context)
        {
            context.Orders.Add(new Order
            {
                Code = "192384529",
                Date = DateTime.Now.AddDays(-3),
                Type = "Retail",
                ItemName = "Hammer",
                Status = "Placed",
                Total = 100.0M
            });

            context.Orders.Add(new Order
            {
                Code = "18903849",
                Date = DateTime.Now.AddDays(-1),
                Type = "Web",
                ItemName = "Wrench",
                Status = "--",
                Total = 150.0M
            });

            context.Orders.Add(new Order
            {
                Code = "18983945",
                Date = DateTime.Now.AddDays(-2),
                Type = "Phone",
                ItemName = "Cordless Drill",
                Status = "--",
                Total = 225.0M
            });

            context.Orders.Add(new Order
            {
                Code = "18983990",
                Date = DateTime.Now.AddDays(-3),
                Type = "Web",
                ItemName = "Hammer",
                Status = "--",
                Total = 100.0M
            });

            context.Orders.Add(new Order
            {
                Code = "18983990",
                Date = DateTime.Now.AddDays(-4),
                Type = "Retail",
                ItemName = "Drill",
                Status = "--",
                Total = 225.0M
            });

            context.Orders.Add(new Order
            {
                Code = "142184222",
                Date = DateTime.Now.AddDays(-7),
                Type = "Sheds",
                ItemName = "Storage Shed Coated Steel",
                Status = "placed",
                Total = 500.0M
            });
            context.Orders.Add(new Order
            {
                Code = "142184923",
                Date = DateTime.Now.AddDays(-10),
                Type = "Sheds",
                ItemName = "Outdoor Storage Shed Steel",
                Status = "--",
                Total = 150.0M
            });

            context.Orders.Add(new Order
            {
                Code = "18983213",
                Date = DateTime.Now.AddDays(-6),
                Type = "Heating",
                ItemName = "Stove",
                Status = "Placed",
                Total = 220.0M
            });

            context.Orders.Add(new Order
            {
                Code = "189832562",
                Date = DateTime.Now.AddDays(-3),
                Type = "Heating",
                ItemName = "Propane Wall Heater",
                Status = "--",
                Total = 320.0M
            });

            context.Orders.Add(new Order
            {
                Code = "18988730",
                Date = DateTime.Now.AddDays(-15),
                Type = "Security",
                ItemName = "Outdoor Security Camera",
                Status = "Placed",
                Total = 115.0M
            });

            context.Orders.Add(new Order
            {
                Code = "18676990",
                Date = DateTime.Now.AddDays(-25),
                Type = "Security",
                ItemName = "Plug-in Indoor Camera",
                Status = "Placed",
                Total = 75.0M
            });

            context.SaveChanges();
        }
    }
}
