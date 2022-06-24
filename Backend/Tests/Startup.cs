using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repo;

namespace Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppUserDbContext>(opts => opts.UseInMemoryDatabase("testDB"));
            services.AddDbContext<WarrantyCheckerAppDBContext>(opts => opts.UseInMemoryDatabase("testDB"));
        }
    }
}
