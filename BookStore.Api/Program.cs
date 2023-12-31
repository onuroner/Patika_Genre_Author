using BookStore.Api.DbOperations;
using BookStore.Api.Services;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Extensions;
using System.Reflection;

namespace BookStore.Api
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
            builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
            builder.Services.AddScoped<IBookStoreDbContext>(provider => provider.GetService<Context>());
            builder.Services.AddDbContext<Context>(options => options.UseInMemoryDatabase(databaseName:"BookStoreDB"));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCustomExceptionMiddleware();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //4. Call the DataGenerator to create sample data
                DataGenerator.Initialize(services);
            }

            app.Run();
        }
    }
}