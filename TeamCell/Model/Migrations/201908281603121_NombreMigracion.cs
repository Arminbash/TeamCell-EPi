namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PV.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PV.Product",
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
                .ForeignKey("PV.Brand", t => t.Id_Brand)
                .ForeignKey("PV.Provider", t => t.Id_Provider)
                .Index(t => t.Id_Brand)
                .Index(t => t.Id_Provider);
            
            CreateTable(
                "PV.Provider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Id_Country = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PV.Country", t => t.Id_Country)
                .Index(t => t.Id_Country);
            
            CreateTable(
                "PV.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PV.Purchases",
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
                .ForeignKey("PV.Provider", t => t.IdProvider)
                .ForeignKey("PV.Warehouse", t => t.IdWarehouse)
                .Index(t => t.IdWarehouse)
                .Index(t => t.IdProvider);
            
            CreateTable(
                "PV.DetailPurchase",
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
                .ForeignKey("PV.Product", t => t.IdProduct)
                .ForeignKey("PV.Purchases", t => t.IdPurchases)
                .Index(t => t.IdPurchases)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "PV.Warehouse",
                c => new
                    {
                        IdWarehouse = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdWarehouse);
            
            CreateTable(
                "PV.Kardex",
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
                .ForeignKey("PV.Product", t => t.IdProducto)
                .ForeignKey("PV.Warehouse", t => t.IdWarehouse)
                .Index(t => t.IdProducto)
                .Index(t => t.IdWarehouse);
            
            CreateTable(
                "PV.CostingAverage",
                c => new
                    {
                        IdCostingAverage = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdKardex = c.Int(),
                    })
                .PrimaryKey(t => t.IdCostingAverage)
                .ForeignKey("PV.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "PV.CostingPeps",
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
                .ForeignKey("PV.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "PV.CostingWeighted",
                c => new
                    {
                        IdCostingWeighted = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdKardex = c.Int(),
                    })
                .PrimaryKey(t => t.IdCostingWeighted)
                .ForeignKey("PV.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "PV.Client",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CardIdentification = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "PV.Employee",
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
                "PV.User",
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
                .ForeignKey("PV.Employee", t => t.IdEmployee, cascadeDelete: true)
                .Index(t => t.IdEmployee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("PV.User", "IdEmployee", "PV.Employee");
            DropForeignKey("PV.Product", "Id_Provider", "PV.Provider");
            DropForeignKey("PV.Purchases", "IdWarehouse", "PV.Warehouse");
            DropForeignKey("PV.Kardex", "IdWarehouse", "PV.Warehouse");
            DropForeignKey("PV.Kardex", "IdProducto", "PV.Product");
            DropForeignKey("PV.CostingWeighted", "IdKardex", "PV.Kardex");
            DropForeignKey("PV.CostingPeps", "IdKardex", "PV.Kardex");
            DropForeignKey("PV.CostingAverage", "IdKardex", "PV.Kardex");
            DropForeignKey("PV.Purchases", "IdProvider", "PV.Provider");
            DropForeignKey("PV.DetailPurchase", "IdPurchases", "PV.Purchases");
            DropForeignKey("PV.DetailPurchase", "IdProduct", "PV.Product");
            DropForeignKey("PV.Provider", "Id_Country", "PV.Country");
            DropForeignKey("PV.Product", "Id_Brand", "PV.Brand");
            DropIndex("PV.User", new[] { "IdEmployee" });
            DropIndex("PV.CostingWeighted", new[] { "IdKardex" });
            DropIndex("PV.CostingPeps", new[] { "IdKardex" });
            DropIndex("PV.CostingAverage", new[] { "IdKardex" });
            DropIndex("PV.Kardex", new[] { "IdWarehouse" });
            DropIndex("PV.Kardex", new[] { "IdProducto" });
            DropIndex("PV.DetailPurchase", new[] { "IdProduct" });
            DropIndex("PV.DetailPurchase", new[] { "IdPurchases" });
            DropIndex("PV.Purchases", new[] { "IdProvider" });
            DropIndex("PV.Purchases", new[] { "IdWarehouse" });
            DropIndex("PV.Provider", new[] { "Id_Country" });
            DropIndex("PV.Product", new[] { "Id_Provider" });
            DropIndex("PV.Product", new[] { "Id_Brand" });
            DropTable("PV.User");
            DropTable("PV.Employee");
            DropTable("PV.Client");
            DropTable("PV.CostingWeighted");
            DropTable("PV.CostingPeps");
            DropTable("PV.CostingAverage");
            DropTable("PV.Kardex");
            DropTable("PV.Warehouse");
            DropTable("PV.DetailPurchase");
            DropTable("PV.Purchases");
            DropTable("PV.Country");
            DropTable("PV.Provider");
            DropTable("PV.Product");
            DropTable("PV.Brand");
        }
    }
}
