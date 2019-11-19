namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientTable",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dob = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Client_AddressTable",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.ClientTable", t => t.Client_ClientId)
                .Index(t => t.Client_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client_AddressTable", "Client_ClientId", "dbo.ClientTable");
            DropIndex("dbo.Client_AddressTable", new[] { "Client_ClientId" });
            DropTable("dbo.Client_AddressTable");
            DropTable("dbo.ClientTable");
        }
    }
}
