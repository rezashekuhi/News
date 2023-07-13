using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMigration.Migrations
{
    [Migration(202306281016)]
    public class _202306281016_AddedNewsCommentsTable : Migration
    {
        

        public override void Up()
        {
            Create.Table("NewsComments")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("UserName").AsString(30).NotNullable()
                 .WithColumn("IsAprroved").AsBoolean().NotNullable()
                 .WithColumn("Text").AsString(999).NotNullable()
                 .WithColumn("Date").AsDateTime().NotNullable()
                 .WithColumn("NewsId").AsInt32().NotNullable()
                 .ForeignKey("NewsComment", "News", "Id");
               
        }
        public override void Down()
        {
            Delete.Table("NewsComments");
        }
    }
}
