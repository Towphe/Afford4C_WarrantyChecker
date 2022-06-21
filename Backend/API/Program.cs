using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppUserDbContext>(opts => opts.UseNpgsql("Host=localhost;Database=WarrantyCheckerAppUserDB;Username=postgres;Password=pingu"));

var app = builder.Build();

app.Run();
