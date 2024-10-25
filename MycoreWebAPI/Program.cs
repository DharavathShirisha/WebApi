
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.OData;

namespace MycoreWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddApiVersioning(o =>
            {
                //do u want application to run without version number
                o.AssumeDefaultVersionWhenUnspecified = true;
                // code to specify default version
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(2, 0);
                //enabling version support
                o.ReportApiVersions = true;
                //http://localhost:api/mymethod+?-v=1.0
                //read the url +combimne -v keyword
                o.ApiVersionReader = ApiVersionReader.Combine(
                             new QueryStringApiVersionReader("ver"),
                        new HeaderApiVersionReader("myver")); // header based versioning
            });


            builder.Services.AddControllers().AddOData(options => options
                    //.AddRouteComponents()
                    .Select()
                    .Filter()
                    .OrderBy()
                    .SetMaxTop(20)
                    .Count()
                    .Expand()
                );
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
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
            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
