using Microsoft.AspNetCore.StaticFiles;

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