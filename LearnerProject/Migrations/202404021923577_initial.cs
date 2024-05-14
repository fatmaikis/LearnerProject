namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        BannerID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BannerID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Icon = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                        ClassroomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ClassroomID);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ClassroomID);
            
            CreateTable(
                "dbo.CourseRegisters",
                c => new
                    {
                        CourseRegisterID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRegisterID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        ReviewValue = c.Double(nullable: false),
                        Comment = c.String(),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        ImageUrl = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FAQID);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.TestimonialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Reviews", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseRegisters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseRegisters", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "ClassroomID", "dbo.Classrooms");
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Reviews", new[] { "StudentID" });
            DropIndex("dbo.Reviews", new[] { "CourseID" });
            DropIndex("dbo.CourseRegisters", new[] { "CourseID" });
            DropIndex("dbo.CourseRegisters", new[] { "StudentID" });
            DropIndex("dbo.Courses", new[] { "ClassroomID" });
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.FAQs");
            DropTable("dbo.Reviews");
            DropTable("dbo.Students");
            DropTable("dbo.CourseRegisters");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Banners");
            DropTable("dbo.Abouts");
        }
    }
}
