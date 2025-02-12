namespace HW2.Migrations
{
    using HW2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HW2.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HW2.Models.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.HWTBs.AddOrUpdate
                (
                    p => new {p.name, p.comment, p.date},
                    new HWTB { name = "AAA", comment = "�A�n", date = DateTime.Parse("2019/4/28").Date },
                    new HWTB { name = "BBB", comment = "�Ȧw", date = DateTime.Parse("2019/4/28").Date },
                    new HWTB { name = "CCC", comment = "�ߦw", date = DateTime.Parse("2019/4/28").Date }
                );
        }
    }
}
