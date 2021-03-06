﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KingsmanTailors.API.Data;
using KingsmanTailors.API.Helpers;
using KingsmanTailors.API.Interfaces;
using KingsmanTailors.API.Models;
using KingsmanTailors.API.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KingsmanTailors.API
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
            // setup data context for injection
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(SiteUtils.SqlConnectionString(Configuration)));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();

            // Add cloudinary settings
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            // register automapper for injection
            services.AddAutoMapper();

            // register database initializer for injection
            services.AddScoped<IDbInitializer, DbInitializer>();

            // register repositories for injection
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRepository<Fabric>, Repository<Fabric>>();
            services.AddScoped<IRepository<OccasionFit>, Repository<OccasionFit>>();
            services.AddScoped<IRepository<Role>, Repository<Role>>();
            services.AddScoped<IRepository<Suit>, Repository<Suit>>();
            services.AddScoped<IRepository<SuitPhoto>, Repository<SuitPhoto>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<UserRole>, Repository<UserRole>>();

            //setup authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(Options =>
            {
                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        // handling application specific errors
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var err = context.Features.Get<IExceptionHandlerFeature>();
                        if (err != null)
                        {
                            context.Response.AddApplicationError(err.Error.Message);
                            await context.Response.WriteAsync(err.Error.Message);
                        }
                    });
                });
            }

            // app.UseHttpsRedirection();
            dbInitializer.Initialize();

            //allow access from other apps
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseMvc();

        }
    }
}
