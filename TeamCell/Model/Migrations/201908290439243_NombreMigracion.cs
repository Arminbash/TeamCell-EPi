namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Pv.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Pv.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        NameProduct = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                        HandleIdentifier = c.Boolean(nullable: false),
                        DriveLot = c.Boolean(nullable: false),
                        TypeCosting = c.String(maxLength: 100),
                        Iva = c.Boolean(nullable: false),
                        Id_Brand = c.Int(),
                        Id_Provider = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Pv.Brand", t => t.Id_Brand)
                .ForeignKey("Pv.Provider", t => t.Id_Provider)
                .Index(t => t.Id_Brand)
                .Index(t => t.Id_Provider);
            
            CreateTable(
                "Pv.Provider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Id_Country = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Pv.Country", t => t.Id_Country)
                .Index(t => t.Id_Country);
            
            CreateTable(
                "Pv.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "Pv.Warehouse",
                c => new
                    {
                        IdWarehouse = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdWarehouse);
            
            CreateTable(
                "Pv.Kardex",
                c => new
                    {
                        IdKardex = c.Int(nullable: false, identity: true),
                        EntryAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OutputAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdDocument = c.Int(nullable: false),
                        Document = c.String(maxLength: 200),
                        IdProducto = c.Int(),
                        IdWarehouse = c.Int(),
                    })
                .PrimaryKey(t => t.IdKardex)
                .ForeignKey("Pv.Product", t => t.IdProducto)
                .ForeignKey("Pv.Warehouse", t => t.IdWarehouse)
                .Index(t => t.IdProducto)
                .Index(t => t.IdWarehouse);
            
            CreateTable(
                "Pv.CostingAverage",
                c => new
                    {
                        IdCostingAverage = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdKardex = c.Int(),
                    })
                .PrimaryKey(t => t.IdCostingAverage)
                .ForeignKey("Pv.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "Pv.CostingPeps",
                c => new
                    {
                        IdCostingPeps = c.Int(nullable: false, identity: true),
                        EntryQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntryCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OutputQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OutputCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Available = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdKardex = c.Int(),
                    })
                .PrimaryKey(t => t.IdCostingPeps)
                .ForeignKey("Pv.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "Pv.CostingWeighted",
                c => new
                    {
                        IdCostingWeighted = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdKardex = c.Int(),
                    })
                .PrimaryKey(t => t.IdCostingWeighted)
                .ForeignKey("Pv.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "Pv.Client",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CardIdentification = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "Pv.Employee",
                c => new
                    {
                        IdEmployee = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        SecondName = c.String(maxLength: 50),
                        FirstSurname = c.String(maxLength: 50),
                        SecondSurname = c.String(maxLength: 50),
                        BirthDay = c.DateTime(nullable: false),
                        IdentificationCard = c.String(maxLength: 100),
                        State = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmployee);
            
            CreateTable(
                "Pv.Segment",
                c => new
                    {
                        IdSegment = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdSegment);
            
            CreateTable(
                "Pv.User",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Salt = c.Binary(),
                        Password = c.Binary(),
                        IdEmployee = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("Pv.Employee", t => t.IdEmployee, cascadeDelete: true)
                .Index(t => t.IdEmployee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Pv.User", "IdEmployee", "Pv.Employee");
            DropForeignKey("Pv.Product", "Id_Provider", "Pv.Provider");
            DropForeignKey("Pv.Purchases", "IdWarehouse", "Pv.Warehouse");
            DropForeignKey("Pv.Kardex", "IdWarehouse", "Pv.Warehouse");
            DropForeignKey("Pv.Kardex", "IdProducto", "Pv.Product");
            DropForeignKey("Pv.CostingWeighted", "IdKardex", "Pv.Kardex");
            DropForeignKey("Pv.CostingPeps", "IdKardex", "Pv.Kardex");
            DropForeignKey("Pv.CostingAverage", "IdKardex", "Pv.Kardex");
            DropForeignKey("Pv.Purchases", "IdProvider", "Pv.Provider");
            DropForeignKey("Pv.DetailPurchase", "IdPurchases", "Pv.Purchases");
            DropForeignKey("Pv.DetailPurchase", "IdProduct", "Pv.Product");
            DropForeignKey("Pv.Provider", "Id_Country", "Pv.Country");
            DropForeignKey("Pv.Product", "Id_Brand", "Pv.Brand");
            DropIndex("Pv.User", new[] { "IdEmployee" });
            DropIndex("Pv.CostingWeighted", new[] { "IdKardex" });
            DropIndex("Pv.CostingPeps", new[] { "IdKardex" });
            DropIndex("Pv.CostingAverage", new[] { "IdKardex" });
            DropIndex("Pv.Kardex", new[] { "IdWarehouse" });
            DropIndex("Pv.Kardex", new[] { "IdProducto" });
            DropIndex("Pv.DetailPurchase", new[] { "IdProduct" });
            DropIndex("Pv.DetailPurchase", new[] { "IdPurchases" });
            DropIndex("Pv.Purchases", new[] { "IdProvider" });
            DropIndex("Pv.Purchases", new[] { "IdWarehouse" });
            DropIndex("Pv.Provider", new[] { "Id_Country" });
            DropIndex("Pv.Product", new[] { "Id_Provider" });
            DropIndex("Pv.Product", new[] { "Id_Brand" });
            DropTable("Pv.User");
            DropTable("Pv.Segment");
            DropTable("Pv.Employee");
            DropTable("Pv.Client");
            DropTable("Pv.CostingWeighted");
            DropTable("Pv.CostingPeps");
            DropTable("Pv.CostingAverage");
            DropTable("Pv.Kardex");
            DropTable("Pv.Warehouse");
            DropTable("Pv.DetailPurchase");
            DropTable("Pv.Purchases");
            DropTable("Pv.Country");
            DropTable("Pv.Provider");
            DropTable("Pv.Product");
            DropTable("Pv.Brand");
        }
    }
}
