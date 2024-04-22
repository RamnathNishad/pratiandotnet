
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI_EFCodeFirst.Models;

namespace WebAPI_EFCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configure DbContext and DataAccess Layer
            builder.Services.AddDbContext<CustomerDBContext>(
                options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CustomerDBEF;Integrated Security=True;")
                );
            builder.Services.AddScoped<ICustomerDataAccess, CustomerDataAccess>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("clients-allowed", opt => {
                    opt.WithOrigins("http://localhost:5136")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });


            builder.Services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
               }).AddJwtBearer(
                    opts =>
                    {
                        var bytesKey = Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyzabcdefghij");

                        opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime= true,

                            ValidIssuer = "pratian",
                            ValidAudience = "pratian",
                            IssuerSigningKey = new SymmetricSecurityKey(bytesKey)
                        };
                    }
                );   

            builder.Services.AddScoped<GlobalExceptionHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           
            app.UseAuthentication(); //this sequence should be same
            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("clients-allowed");

            app.UseMiddleware<GlobalExceptionHandler>();

            app.Run();
        }
    }
}
