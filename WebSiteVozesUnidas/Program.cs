using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<ApplicationUser>(options => { options.SignIn.RequireConfirmedAccount = false; })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        using (var scope = app.Services.CreateScope())

        {
            var roleManager =
            scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            var roles = new[] { "Admin", "Empresa", "PessoaF", "Jornalista" };

            foreach (var role in roles)

            {

                if (!await roleManager.RoleExistsAsync(role)) 
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));

            }

        }

        using (var scope = app.Services.CreateScope())

        {
            var userManager =
            scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string email = "admin@gmail.com";
            string senha = "Aa@123";

            if(await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser();
                user.Email = email;
                user.UserName = email;

                await userManager.CreateAsync(user, senha);

                await userManager.AddToRoleAsync(user, "Admin");
            }

            if(await userManager.FindByEmailAsync("empresa@gmail.com") != null)
            {
                var user = await userManager.FindByEmailAsync("empresa@gmail.com");
                await userManager.AddToRoleAsync(user, "Empresa");
            }
            if (await userManager.FindByEmailAsync("admin@gmail.com") != null)
            {
                var user = await userManager.FindByEmailAsync("admin@gmail.com");
                await userManager.AddToRoleAsync(user, "Admin");
            }
            if (await userManager.FindByEmailAsync("usuario@gmail.com") != null)
            {
                var user = await userManager.FindByEmailAsync("usuario@gmail.com");
                await userManager.AddToRoleAsync(user, "PessoaF");
            }
            if (await userManager.FindByEmailAsync("jornalista@gmail.com") != null)
            {
                var user = await userManager.FindByEmailAsync("jornalista@gmail.com");
                await userManager.AddToRoleAsync(user, "Jornalista");
            }
        }

        app.Run();
    }
}