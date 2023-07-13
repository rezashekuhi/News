using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMigration.Migrations
{
    [Migration(202306281003)]
    public class _202306281003_AddedTagsTable : Migration
    {
        

        public override void Up()
        {
            Create.Table("Tags")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(30).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Tags");
        }
    }
}
