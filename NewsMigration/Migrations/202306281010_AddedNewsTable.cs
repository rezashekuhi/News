using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMigration.Migrations
{
    [Migration(202306281010)]
    public class _202306281010_AddedNewsTable : Migration
    {
        public override void Up()
        {
            Create.Table("News")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("Title").AsString(30).NotNullable()
                 .WithColumn("Text").AsString(1999).NotNullable()
                 .WithColumn("Date").AsDateTime().NotNullable()
                 .WithColumn("IsSlider").AsBoolean().NotNullable()
                 .WithColumn("View").AsInt32().NotNullable()
                 .WithColumn("CityId").AsInt32().NotNullable()
                 .ForeignKey("FK_News_Cities", "Cities", "Id")

                 .WithColumn("CategoryId").AsInt32().NotNullable()
                 .ForeignKey("FK_News_Categories", "Categories", "Id");
                
                
        }
        public override void Down()
        {
            Delete.Table("News");
        }

    }
}
