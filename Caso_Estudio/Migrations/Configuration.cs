namespace Caso_Estudio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Caso_Estudio.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Caso_Estudio.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Caso_Estudio.Models.ApplicationDbContext context)
        {
            context.Cadenas.AddOrUpdate(p => p.CadenaID,
                new Cadena
                {
                    CadenaID = 1,
                    Name = "Debra Garcia",
                    City = "Redmond",
                    Address = "Debra Garcia",
                    Zip = "10999",
                },
                new Cadena
                {
                    CadenaID = 2,
                    Name = "Thorsten Weinrich",
                    City = "Redmond",
                    Address = "5678 1st Ave W",
                    Zip = "10999",
                },
                new Cadena
                {
                    CadenaID = 3,
                    Name = "Yuhong Li",
                    City = "Redmond",
                    Address = "9012 State st",
                    Zip = "10999",
                },
                new Cadena
                {
                    CadenaID = 4,
                    Name = "Jon Orto",
                    City = "Redmond",
                    Address = "3456 Maple St",
                    Zip = "10999",
                },
                new Cadena
                {
                    CadenaID = 5,
                    Name = "Diliana Alexieva-Bosseva",
                    City = "Redmond",
                    Address = "7890 2nd Ave E",
                    Zip = "10999",
                }
                );
        }
    }
}
