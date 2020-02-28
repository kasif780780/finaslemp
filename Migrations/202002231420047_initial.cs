namespace EmpManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmpSalaries", "PayrollID", "dbo.Payrolls");
            DropIndex("dbo.EmpSalaries", new[] { "PayrollID" });
            AddColumn("dbo.Payrolls", "HRT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Payrolls", "MCA", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Payrolls", "Incentive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Payrolls", "IncomeTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Payrolls", "PF", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.EmpSalaries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmpSalaries",
                c => new
                    {
                        EmpSalaryID = c.Int(nullable: false, identity: true),
                        PayrollID = c.Int(nullable: false),
                        HRA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MCA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LTA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Commision = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TDS = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EmpSalaryID);
            
            DropColumn("dbo.Payrolls", "PF");
            DropColumn("dbo.Payrolls", "IncomeTax");
            DropColumn("dbo.Payrolls", "Incentive");
            DropColumn("dbo.Payrolls", "MCA");
            DropColumn("dbo.Payrolls", "HRT");
            CreateIndex("dbo.EmpSalaries", "PayrollID");
            AddForeignKey("dbo.EmpSalaries", "PayrollID", "dbo.Payrolls", "PayrollID", cascadeDelete: true);
        }
    }
}
