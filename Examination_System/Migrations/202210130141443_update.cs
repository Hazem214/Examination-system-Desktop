namespace Examination_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "E_Type", c => c.Int(nullable: false));
            DropColumn("dbo.Exams", "ExamType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exams", "ExamType", c => c.Int(nullable: false));
            DropColumn("dbo.Exams", "E_Type");
        }
    }
}
