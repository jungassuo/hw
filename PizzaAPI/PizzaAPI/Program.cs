using AutoMapper;
using Barakas.Services.ProductAPI;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;

namespace PizzaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add DbContext implemented class, to use it as object through dependency injection freely
            // for crud operations. To add a service you have to declare connection string, which in this case 
            // it is called "DefaultConnection". You can change it in appsettings.json. You will have to manually
            // enter database server and name.
            builder.Services.AddDbContext<AddDbContext>(option => {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();
            
            // To get ahead of CORS policy i added a option, whichs allows localhost server to interact with 
            // this API
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Set use cors parameter created above
            app.UseCors("AllowFrontend");

            app.MapControllers();

            app.Run();
        }
    }
}