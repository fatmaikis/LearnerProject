namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_coursevideo_table_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseVideos",
                c => new
                    {
                        CourseVideoID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        VideoNumber = c.Int(nullable: false),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.CourseVideoID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseVideos", new[] { "CourseID" });
            DropTable("dbo.CourseVideos");
        }
    }
}
