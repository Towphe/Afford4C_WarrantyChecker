using System;
using System.Text.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Repo
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppUserDbContext>
    {
        public DesignTimeDbContextFactory()
        {
        }
        public AppUserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppUserDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=WarrantyCheckerAppUserDB;Username=postgres;Password=pingu");
            return new AppUserDbContext(optionsBuilder.Options);
        }
    }
}