using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranzactChallenge.Application.Services;
using TranzactChallenge.Infrastructure.Repository;
using TranzactChallenge.Core.Interfaces;
using TranzactChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TranzactChallenge.API
{
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
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TranzactChallenge.API", Version = "v1" });
            });

            //configure database
            services.AddDbContext<PremiumContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
            });

            #region Add Service Injection
            //necesary fot injection
            services.AddTransient<IPremiumRepository, PremiumRepository>();
            services.AddScoped<IPremiumService, PremiumService>();

            services.AddTransient<IStateRepository, StateRepository>();
            services.AddScoped<IStateService, StateService>();

            services.AddTransient<IPeriodRepository, PeriodRepository>();
            services.AddScoped<IPeriodService, PeriodService>();

            services.AddTransient<IPlanRepository, PlanRepository>();
            services.AddScoped<IPlanService, PlanService>();
            #endregion


            services.AddCors(options =>
            {
                options.AddPolicy("permit",
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranzactChallenge.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("permit");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            
        }
    }
}
