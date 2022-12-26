using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepoPattern.API;
using RepoPattern.Core;
using RepoPattern.Core.Interfaces;
using RepoPattern.EF;
using RepoPattern.EF.Models;
using RepoPattern.EF.Repositories;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

        builder.Services.AddDbContext<MVCContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(MVCContext).Assembly.FullName)
            ));
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddControllersWithViews();
        //builder.Services.AddAutoMapper(typeof(MappingProfile));
        /*
        builder.Services.AddDbContext <ApplicationDbContext> (option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("Server=AAAHP;Database=RepoPattern;Integrated Security=True")));
        */
        //builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        var config2 = builder.Configuration.GetConnectionString("DefaultConnection");
        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}