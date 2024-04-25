using Biluthyrning.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Biluthyrning.Interface;
using Biluthyrning.Repositorys;
using Biluthyrning.ViewModels;

namespace Biluthyrning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContextFactory<RentalDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext") ?? throw new InvalidOperationException("Connection string 'DbContext' not found.")));
            builder.Services.AddDbContext<RentalDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext") ?? throw new InvalidOperationException("Connection string 'DbContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddTransient<Vehicle>();
            builder.Services.AddTransient<User>();
			builder.Services.AddTransient<VehicleType>();
			builder.Services.AddScoped<UserVehicleViewModel, UserVehicleViewModel>();
			builder.Services.AddTransient<IBookingRepository, BookingRepository>();
			builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
            builder.Services.AddTransient<IVehicleTypeRepository, VehicleTypeRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            
			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();
        }
    }
}


