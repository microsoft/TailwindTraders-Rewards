namespace Tailwind.Traders.Rewards.Web.Migrations
{
    public partial class initial //: DbMigration
    {
        // TODO: CON ESTA INFO CREAR LOS SCRIPTS PARA CREACIÓN DE LAS TABLAS EN DB

        //public override void Up()
        //{
        //    CreateTable(
        //        "dbo.Customers",
        //        c => new //Tailwind.Traders.Rewards.Web.data.Customer
        //        {
        //            Email = c.String(nullable: false, maxLength: 128),
        //            RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
        //            CustomerId = c.Int(nullable: false),
        //            AccountCode = c.String(),
        //            FirstName = c.String(),
        //            LastName = c.String(),
        //            FirstAddress = c.String(),
        //            City = c.String(),
        //            Country = c.String(),
        //            ZipCode = c.String(),
        //            Website = c.String(),
        //            Active = c.Boolean(nullable: false),
        //            Enrrolled = c.Int(nullable: false),
        //            PhoneNumber = c.String(),
        //            MobileNumber = c.String(),
        //            FaxNumber = c.String(),
        //        }
        //        )
        //    .PrimaryKey(t => t.Email);

        //    CreateTable(
        //        "dbo.Orders",
        //        c => new
        //        {
        //            OrderId = c.Int(nullable: false, identity: true),
        //            Code = c.String(),
        //            Date = c.DateTime(nullable: false),
        //            Type = c.String(),
        //            ItemName = c.String(),
        //            Status = c.String(),
        //            Total = c.Decimal(nullable: false, precision: 18, scale: 2),
        //        })
        //    .PrimaryKey(t => t.OrderId);

        //}

        //public override void Down()
        //{
        //    DropTable("dbo.Orders");
        //    DropTable("dbo.Customers");
        //}
    }
}
