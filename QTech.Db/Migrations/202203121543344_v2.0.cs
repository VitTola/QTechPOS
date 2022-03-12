namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        DiscountType = c.Int(nullable: false),
                        DiscountByProduct = c.String(),
                        DiscountByTotal = c.String(),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AuditTrails", "ClientAddress", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.AuditTrails", "OperatorGroup", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.AuditTrails", "TablePK", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.AuditTrails", "ChangeJson", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.AuditTrails", "TableValue", c => c.String(nullable: false, maxLength: 1000));
            //DropTable("dbo.Invoices");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Invoices",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            InvoiceNo = c.String(),
            //            InvoicingDate = c.DateTime(nullable: false),
            //            TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            LeftAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            InvoiceStatus = c.Int(nullable: false),
            //            CustomerId = c.Int(nullable: false),
            //            CustomerName = c.String(),
            //            Active = c.Boolean(nullable: false),
            //            RowDate = c.DateTime(nullable: false),
            //            CreatedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AuditTrails", "TableValue", c => c.String());
            AlterColumn("dbo.AuditTrails", "ChangeJson", c => c.String());
            AlterColumn("dbo.AuditTrails", "TablePK", c => c.String());
            AlterColumn("dbo.AuditTrails", "OperatorGroup", c => c.String());
            AlterColumn("dbo.AuditTrails", "ClientAddress", c => c.String());
            DropTable("dbo.Discounts");
        }
    }
}
