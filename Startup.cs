using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using ACDC2019SpiderpigsCovertOPs.Database;
using ACDC2019SpiderpigsCovertOPs.Models.DbModels;
using ACDC2019SpiderpigsCovertOPs.Models.ViewModels;

namespace ACDC2019SpiderpigsCovertOPs
{
#pragma warning disable 1591
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CovertOPsContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("CovertOPsConnection")));

            //services.AddScoped<INSAFilesServices, NSAFilesServices>();

            // Register Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Spiderpigs Covert OPs",
                    Version = "v1",
                    Description = "Rest API - Spiderpigs knows it all!"
                });
                //c.RoutePrefix = string.Empty;

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()                
                );
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(
                        options => options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spiderpigs Covert OPs");
            });

            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<Sensordata, SensordataDto>().ReverseMap();
                mapper.CreateMap<Sensordata, SensordataInsertDto>().ReverseMap();
                mapper.CreateMap<Incident, IncidentDto>().ReverseMap();
                mapper.CreateMap<Incident, IncidentInsertDto>().ReverseMap();
                mapper.CreateMap<Building, BuildingDto>().ReverseMap();
                mapper.CreateMap<Building, BuildingInsertDto>().ReverseMap();
                mapper.CreateMap<Position, PositionDto>().ReverseMap();
                mapper.CreateMap<Position, PositionInsertDto>().ReverseMap();
                mapper.CreateMap<Person, PersonDto>().ReverseMap();
                mapper.CreateMap<Person, PersonInsertDto>().ReverseMap();
                mapper.CreateMap<Location, LocationDto>().ReverseMap();
                mapper.CreateMap<Location, LocationInsertDto>().ReverseMap();
                mapper.CreateMap<Spiderpig, SpiderpigDto>().ReverseMap();
                mapper.CreateMap<Spiderpig, SpiderpigInsertDto>().ReverseMap();
            });


            app.UseHttpsRedirection();
            app.UseCors("AllowOrigin");
            app.UseMvc();
        }
    }
}
