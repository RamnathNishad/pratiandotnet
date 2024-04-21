
using EmployeesWebAPIDemo.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace EmployeesWebAPIDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options=>options.OutputFormatters
                                                            .Add(new XmlSerializerOutputFormatter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configure DbContext with connection string
            var constr = builder.Configuration.GetConnectionString("constr");

            builder.Services.AddDbContext<EmpDBContext>(options => 
                                options.UseSqlServer(constr));
            //configure dependency injection for EmpDataAccess
            builder.Services.AddScoped<IEmpDataAccess,EmpDataAccessLayer>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("clients-allowed", opt => {
                    opt.WithOrigins("http://localhost:5136")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("clients-allowed");
            app.Run();
        }
    }
}
