namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Country.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Country.Product",
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
                .ForeignKey("Country.Brand", t => t.Id_Brand)
                .ForeignKey("Country.Provider", t => t.Id_Provider)
                .Index(t => t.Id_Brand)
                .Index(t => t.Id_Provider);
            
            CreateTable(
                "Country.Provider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Id_Country = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Country.Country", t => t.Id_Country)
                .Index(t => t.Id_Country);
            
            CreateTable(
                "Country.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Country.Client",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CardIdentification = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "Country.Employee",
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
                "Country.User",
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
                .ForeignKey("Country.Employee", t => t.IdEmployee, cascadeDelete: true)
                .Index(t => t.IdEmployee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Country.User", "IdEmployee", "Country.Employee");
            DropForeignKey("Country.Product", "Id_Provider", "Country.Provider");
            DropForeignKey("Country.Provider", "Id_Country", "Country.Country");
            DropForeignKey("Country.Product", "Id_Brand", "Country.Brand");
            DropIndex("Country.User", new[] { "IdEmployee" });
            DropIndex("Country.Provider", new[] { "Id_Country" });
            DropIndex("Country.Product", new[] { "Id_Provider" });
            DropIndex("Country.Product", new[] { "Id_Brand" });
            DropTable("Country.User");
            DropTable("Country.Employee");
            DropTable("Country.Client");
            DropTable("Country.Country");
            DropTable("Country.Provider");
            DropTable("Country.Product");
            DropTable("Country.Brand");
        }
    }
}
