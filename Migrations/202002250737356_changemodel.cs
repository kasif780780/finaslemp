namespace EmpManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leaves", "LeaveTypeID", "dbo.LeaveTypes");
            DropIndex("dbo.Leaves", new[] { "LeaveTypeID" });
            AddColumn("dbo.Leaves", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Leaves", "EmployeeID");
            AddForeignKey("dbo.Leaves", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
            DropColumn("dbo.Leaves", "LeaveTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaves", "LeaveTypeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Leaves", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Leaves", new[] { "EmployeeID" });
            DropColumn("dbo.Leaves", "EmployeeID");
            CreateIndex("dbo.Leaves", "LeaveTypeID");
            AddForeignKey("dbo.Leaves", "LeaveTypeID", "dbo.LeaveTypes", "LeaveTypeID", cascadeDelete: true);
        }
    }
}
