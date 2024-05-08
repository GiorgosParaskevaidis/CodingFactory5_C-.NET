using FirstWebDBApp.Configuration;
using FirstWebDBApp.DAO;
using FirstWebDBApp.DTO;
using FirstWebDBApp.Services;
using FirstWebDBApp.Validators;
using FluentValidation;
using Serilog;

namespace FirstWebDBApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
                
            });

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<ICustomerDAO, CustomerDAOImpl>();
            builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddScoped<IValidator<CustomerInsertDTO>, CustomerInsertValidator>();
            builder.Services.AddScoped<IValidator<CustomerUpdateDTO>, CustomerUpdateValidator>();

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

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
