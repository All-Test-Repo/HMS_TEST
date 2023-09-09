using HMS.DAL.Data;
using HMS.DAL.Generic_Implementation;
using HMS.DAL.Generic_Interface;

using HMS.Repository.Implementation;
using HMS.Repository.Interface;
using Hospital_Management_System.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Hospital_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //add newtonsoft.json support
            
            builder.Services.AddControllers().AddNewtonsoftJson();

            //add cors policy
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<HospitalDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("appCon")));

            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>)); 
            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<INurseRepo, NurseRepo>();
            builder.Services.AddScoped<ImageHelper>();

            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}