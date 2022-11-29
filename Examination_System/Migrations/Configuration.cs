namespace Examination_System.Migrations
{
    using Cproject;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cproject.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
