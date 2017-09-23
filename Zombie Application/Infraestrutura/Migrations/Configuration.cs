namespace Infraestrutura.Migrations
{
    using Core.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infraestrutura.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infraestrutura.Contexto context)
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

            context.Usuarios.AddOrUpdate(u => u.Nome,
                new Usuario
                {
                    Nome = "Daniel Aragão",
                    Login = "Daniel",
                    Senha = "e8d95a51f3af4a3b134bf6bb680a213a" // Senha = senha
                }
            );
        }
    }
}
