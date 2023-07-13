using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMigration.Migrations
{
    [Migration(202306280959)]
    public class _202306280959_AddedCategorysTable : Migration
    {

        public override void Up()
        {
            Create.Table("Categories")
                   .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                   .WithColumn("Name").AsString(30).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Categories");
        }
    }
}
