namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Inventory.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Inventory.Product",
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
                .ForeignKey("Inventory.Brand", t => t.Id_Brand)
                .ForeignKey("Inventory.Provider", t => t.Id_Provider)
                .Index(t => t.Id_Brand)
                .Index(t => t.Id_Provider);
            
            CreateTable(
                "Inventory.Provider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Id_Country = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inventory.Country", t => t.Id_Country)
                .Index(t => t.Id_Country);
            
            CreateTable(
                "Inventory.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Inventory.Client",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CardIdentification = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "Inventory.CostingAverage",
                c => new
                    {
                        IdCostingAverage = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdKardex = c.Int(),
                    })
                .PrimaryKey(t => t.IdCostingAverage)
                .ForeignKey("Inventory.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "Inventory.Kardex",
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
                .ForeignKey("Inventory.Product", t => t.IdProducto)
                .ForeignKey("Inventory.Warehouse", t => t.IdWarehouse)
                .Index(t => t.IdProducto)
                .Index(t => t.IdWarehouse);
            
            CreateTable(
                "Inventory.CostingPeps",
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
                .ForeignKey("Inventory.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "Inventory.CostingWeighted",
                c => new
                    {
                        IdCostingWeighted = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdKardex = c.Int(),
                    })
                .PrimaryKey(t => t.IdCostingWeighted)
                .ForeignKey("Inventory.Kardex", t => t.IdKardex)
                .Index(t => t.IdKardex);
            
            CreateTable(
                "Inventory.Warehouse",
                c => new
                    {
                        IdWarehouse = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdWarehouse);
            
            CreateTable(
                "Inventory.Employee",
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
                "Inventory.User",
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
                .ForeignKey("Inventory.Employee", t => t.IdEmployee, cascadeDelete: true)
                .Index(t => t.IdEmployee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Inventory.User", "IdEmployee", "Inventory.Employee");
            DropForeignKey("Inventory.CostingAverage", "IdKardex", "Inventory.Kardex");
            DropForeignKey("Inventory.Kardex", "IdWarehouse", "Inventory.Warehouse");
            DropForeignKey("Inventory.Kardex", "IdProducto", "Inventory.Product");
            DropForeignKey("Inventory.CostingWeighted", "IdKardex", "Inventory.Kardex");
            DropForeignKey("Inventory.CostingPeps", "IdKardex", "Inventory.Kardex");
            DropForeignKey("Inventory.Product", "Id_Provider", "Inventory.Provider");
            DropForeignKey("Inventory.Provider", "Id_Country", "Inventory.Country");
            DropForeignKey("Inventory.Product", "Id_Brand", "Inventory.Brand");
            DropIndex("Inventory.User", new[] { "IdEmployee" });
            DropIndex("Inventory.CostingWeighted", new[] { "IdKardex" });
            DropIndex("Inventory.CostingPeps", new[] { "IdKardex" });
            DropIndex("Inventory.Kardex", new[] { "IdWarehouse" });
            DropIndex("Inventory.Kardex", new[] { "IdProducto" });
            DropIndex("Inventory.CostingAverage", new[] { "IdKardex" });
            DropIndex("Inventory.Provider", new[] { "Id_Country" });
            DropIndex("Inventory.Product", new[] { "Id_Provider" });
            DropIndex("Inventory.Product", new[] { "Id_Brand" });
            DropTable("Inventory.User");
            DropTable("Inventory.Employee");
            DropTable("Inventory.Warehouse");
            DropTable("Inventory.CostingWeighted");
            DropTable("Inventory.CostingPeps");
            DropTable("Inventory.Kardex");
            DropTable("Inventory.CostingAverage");
            DropTable("Inventory.Client");
            DropTable("Inventory.Country");
            DropTable("Inventory.Provider");
            DropTable("Inventory.Product");
            DropTable("Inventory.Brand");
        }
    }
}
