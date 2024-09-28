using FluentValidation;
using FluentValidation.AspNetCore;
using GameZone.Configuration.VMConfig;
using GameZone.Services.GameServices;
using GameZone.VM;
using Microsoft.EntityFrameworkCore;

namespace GameZone
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GameZoneDbContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("GameZoneConnectionString")
                ));

            builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
            builder.Services.AddScoped<IDevicesServices, DevicesServices>();
            builder.Services.AddScoped<IGameServices, GameServices>();
            // 
			builder.Services.AddFluentValidationAutoValidation();
			builder.Services.AddFluentValidationClientsideAdapters();
			builder.Services.AddScoped<IValidator<CreateGameVM>, CreateGameVMConfig>();
			builder.Services.AddScoped<IValidator<UpdateGameVM>, UpdateGameVMConfig>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.Run();
        }
    }
}
