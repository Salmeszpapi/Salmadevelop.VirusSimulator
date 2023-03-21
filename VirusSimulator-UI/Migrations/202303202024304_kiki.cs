namespace VirusSimulator_UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kiki : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SimulationDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AllPeople = c.Int(nullable: false),
                        AllHealthyPeoples = c.Int(nullable: false),
                        AllInfectedPeoples = c.Int(nullable: false),
                        AllDeadPeoples = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SimulationRuns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfRun = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SimulationRuns");
            DropTable("dbo.SimulationDatas");
        }
    }
}
