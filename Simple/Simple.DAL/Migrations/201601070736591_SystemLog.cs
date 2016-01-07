namespace Simple.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Security.SystemLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Level = c.String(),
                        Logger = c.String(),
                        Message = c.String(),
                        Exception = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Security.SystemLog");
        }
    }
}
