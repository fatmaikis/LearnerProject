namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_remove_relation_classroom_and_course : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "ClassroomID", "dbo.Classrooms");
            DropIndex("dbo.Courses", new[] { "ClassroomID" });
            DropColumn("dbo.Courses", "ClassroomID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ClassroomID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "ClassroomID");
            AddForeignKey("dbo.Courses", "ClassroomID", "dbo.Classrooms", "ClassroomID", cascadeDelete: true);
        }
    }
}
