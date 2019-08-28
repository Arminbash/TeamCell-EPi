namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigracion : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "Inventory.Brand", newSchema: "Pv");
            MoveTable(name: "Inventory.Product", newSchema: "Pv");
            MoveTable(name: "Inventory.Provider", newSchema: "Pv");
            MoveTable(name: "Inventory.Country", newSchema: "Pv");
            MoveTable(name: "Inventory.Client", newSchema: "Pv");
            MoveTable(name: "Inventory.CostingAverage", newSchema: "Pv");
            MoveTable(name: "Inventory.Kardex", newSchema: "Pv");
            MoveTable(name: "Inventory.CostingPeps", newSchema: "Pv");
            MoveTable(name: "Inventory.CostingWeighted", newSchema: "Pv");
            MoveTable(name: "Inventory.Warehouse", newSchema: "Pv");
            MoveTable(name: "Inventory.Employee", newSchema: "Pv");
            MoveTable(name: "Inventory.User", newSchema: "Pv");
            CreateTable(
                "Pv.Purchases",
                c => new
                    {
                        IdPurchases = c.Int(nullable: false, identity: true),
                        Factura = c.String(maxLength: 200),
                        PurchaseDate = c.DateTime(nullable: false, storeType: "date"),
                        EntryDate = c.DateTime(nullable: false, storeType: "date"),
                        IdEmployee = c.Int(nullable: false),
                        IdWarehouse = c.Int(),
                        IdProvider = c.Int(),
                    })
                .PrimaryKey(t => t.IdPurchases)
                .ForeignKey("Pv.Provider", t => t.IdProvider)
                .ForeignKey("Pv.Warehouse", t => t.IdWarehouse)
                .Index(t => t.IdWarehouse)
                .Index(t => t.IdProvider);
            
            CreateTable(
                "Pv.DetailPurchase",
                c => new
                    {
                        IdDetailPurchase = c.Int(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IVA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdPurchases = c.Int(),
                        IdProduct = c.Int(),
                    })
                .PrimaryKey(t => t.IdDetailPurchase)
                .ForeignKey("Pv.Product", t => t.IdProduct)
                .ForeignKey("Pv.Purchases", t => t.IdPurchases)
                .Index(t => t.IdPurchases)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "Pv.Segment",
                c => new
                    {
                        IdSegment = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdSegment);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Pv.Purchases", "IdWarehouse", "Pv.Warehouse");
            DropForeignKey("Pv.Purchases", "IdProvider", "Pv.Provider");
            DropForeignKey("Pv.DetailPurchase", "IdPurchases", "Pv.Purchases");
            DropForeignKey("Pv.DetailPurchase", "IdProduct", "Pv.Product");
            DropIndex("Pv.DetailPurchase", new[] { "IdProduct" });
            DropIndex("Pv.DetailPurchase", new[] { "IdPurchases" });
            DropIndex("Pv.Purchases", new[] { "IdProvider" });
            DropIndex("Pv.Purchases", new[] { "IdWarehouse" });
            DropTable("Pv.Segment");
            DropTable("Pv.DetailPurchase");
            DropTable("Pv.Purchases");
            MoveTable(name: "Pv.User", newSchema: "Inventory");
            MoveTable(name: "Pv.Employee", newSchema: "Inventory");
            MoveTable(name: "Pv.Warehouse", newSchema: "Inventory");
            MoveTable(name: "Pv.CostingWeighted", newSchema: "Inventory");
            MoveTable(name: "Pv.CostingPeps", newSchema: "Inventory");
            MoveTable(name: "Pv.Kardex", newSchema: "Inventory");
            MoveTable(name: "Pv.CostingAverage", newSchema: "Inventory");
            MoveTable(name: "Pv.Client", newSchema: "Inventory");
            MoveTable(name: "Pv.Country", newSchema: "Inventory");
            MoveTable(name: "Pv.Provider", newSchema: "Inventory");
            MoveTable(name: "Pv.Product", newSchema: "Inventory");
            MoveTable(name: "Pv.Brand", newSchema: "Inventory");
        }
    }
}
