using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMigration.Migrations
{
    [Migration(202306280934)]
    public class _202306280934_AddedCitysTable : Migration
    {

        public override void Up()
        {
            Create.Table("Cities")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Name").AsString(30).NotNullable();
                

        }
        public override void Down()
        {
            Delete.Table("Cities");
        }

    }
}
