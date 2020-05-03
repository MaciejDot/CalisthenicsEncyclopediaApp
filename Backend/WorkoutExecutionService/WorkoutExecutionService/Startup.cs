using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WorkoutExecutionService.DataAccess.Configuration;
using WorkoutExecutionService.Domain.Configuration;

namespace WorkoutExecutionService
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
            services.AddWorkoutExecutionServiceDataAccess(Configuration.GetConnectionString("WorkoutExecutionDatabase"));
            services.AddWorkoutExecutionServiceDataAccessOptions(Configuration);
            services.AddWorkoutExecutionServiceDomain();
            ConfigureAuthorization(services);
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            var rsa = RSA.Create(new RSAParameters
            {
                Exponent = Convert.FromBase64String(Configuration.GetValue<string>("Authorization:Exponent")),
                Modulus = Convert.FromBase64String(Configuration.GetValue<string>("Authorization:Modulus"))
            });
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new RsaSecurityKey(rsa),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        NameClaimType = "Name"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IBackgroundJobClient client, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
            app.UseWorkoutExecutionServiceDataAccess(client);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
