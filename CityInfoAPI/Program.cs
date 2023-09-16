using CityInfoAPI.Data;
using CityInfoAPI.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            /* Adding xml to the default json and if user requested any format that isn't configured
            it will return not acceptable instead of Default JSON. */

            builder.Services.AddControllers(options =>
            { 
             options.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters().AddNewtonsoftJson();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // for detching and uploading a file ( extension ).
            builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
            builder.Services.AddScoped<CPDbContext>();


            //
            builder.Services.AddSingleton<CitiesDataStore>();

            // Adding DbContext and Sql Server 
            builder.Services.AddDbContext<CPDbContext>(options => {
                options.UseSqlServer(
                    builder.Configuration["ConnectionStrings:CitiesAppInfoDataBaseConnection"]);
            });



            //
#if DEBUG
            builder.Services.AddTransient<IMailService , LocalMailService>();
            #else
            builder.Services.AddTransient<IMailService , CloudMailService>();
            #endif



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            

            app.Run();
        }
    }
}