using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMigration.Migrations
{
    [Migration(202306281014)]
    public class _202306281014_AddedNewsTagsTable : Migration
    {

        public override void Up()
        {
            Create.Table("NewsTags")

                 .WithColumn("NewsId").AsInt32().PrimaryKey()
                 .ForeignKey("FK_NewsTags_News", "News", "Id")
                 .WithColumn("TagId").AsInt32().PrimaryKey()
                 .ForeignKey("FK_NewsTags_Tags", "Tags", "Id");
                
        }
        public override void Down()
        {
            Delete.Table("NewsTags");
        }
    }
}
