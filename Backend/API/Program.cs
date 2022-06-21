using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Services;
using Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppUserDbContext>(opts => opts.UseNpgsql("Host=localhost;Database=WarrantyCheckerAppUserDB;Username=postgres;Password=pingu"));
builder.Services.AddIdentityCore<AppUser>(opts =>
{
    // NOTE: Change this later on to make app more secure
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireDigit = false;
}).AddSignInManager<AppUser>().AddEntityFrameworkStores<AppUserDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(opts =>
{
    opts.RequireAuthenticatedSignIn = true;
    opts.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
}).AddCookie(IdentityConstants.ApplicationScheme, opts =>
{
    opts.LoginPath = "api/account/signin";
    opts.LogoutPath = "api/account/signout";
    opts.ReturnUrlParameter = "returnUrl";
});
builder.Services.AddAuthorization();
builder.Services.AddTransient<IPasswordHasher<AppUser>, Services.Account.PasswordHasher>();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthentication();

app.Run();
