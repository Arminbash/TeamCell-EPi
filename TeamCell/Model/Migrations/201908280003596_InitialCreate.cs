namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Provider.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Provider.Product",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NameProduct = c.String(maxLength: 50),
                        Preci = c.String(maxLength: 100),
                        Description = c.String(maxLength: 100),
                        IdBrand = c.Int(),
                        IdProvider = c.Int(),
                        Status = c.Boolean(nullable: false),
                        Brand_IdBrand = c.Int(),
                        Provider_IdProvider = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Provider.Brand", t => t.Brand_IdBrand)
                .ForeignKey("Provider.Provider", t => t.Provider_IdProvider)
                .Index(t => t.Brand_IdBrand)
                .Index(t => t.Provider_IdProvider);
            
            CreateTable(
                "Provider.Provider",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 200),
                        Address = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Provider.Client",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CardIdentification = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "Provider.Employee",
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
                "Provider.User",
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
                .ForeignKey("Provider.Employee", t => t.IdEmployee, cascadeDelete: true)
                .Index(t => t.IdEmployee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Provider.User", "IdEmployee", "Provider.Employee");
            DropForeignKey("Provider.Product", "Provider_IdProvider", "Provider.Provider");
            DropForeignKey("Provider.Product", "Brand_IdBrand", "Provider.Brand");
            DropIndex("Provider.User", new[] { "IdEmployee" });
            DropIndex("Provider.Product", new[] { "Provider_IdProvider" });
            DropIndex("Provider.Product", new[] { "Brand_IdBrand" });
            DropTable("Provider.User");
            DropTable("Provider.Employee");
            DropTable("Provider.Client");
            DropTable("Provider.Provider");
            DropTable("Provider.Product");
            DropTable("Provider.Brand");
        }
    }
}
