namespace EmpManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Attendances", new[] { "EmployeeID" });
            AddColumn("dbo.Attendances", "ComingTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendances", "DateOfDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendances", "LeaveTime", c => c.DateTime());
            AddColumn("dbo.Employees", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Employees", "UserRoles", c => c.String());
            DropColumn("dbo.Attendances", "Ispresent");
            DropColumn("dbo.Attendances", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendances", "Ispresent", c => c.Boolean(nullable: false));
            DropColumn("dbo.Employees", "UserRoles");
            DropColumn("dbo.Employees", "ConfirmPassword");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Attendances", "LeaveTime");
            DropColumn("dbo.Attendances", "DateOfDay");
            DropColumn("dbo.Attendances", "ComingTime");
            CreateIndex("dbo.Attendances", "EmployeeID");
            AddForeignKey("dbo.Attendances", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
        }
    }
}
