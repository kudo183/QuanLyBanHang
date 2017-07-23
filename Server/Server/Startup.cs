﻿using huypq.SmtMiddleware;
using huypq.SmtMiddleware.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Server.Entities;
using System.IO;

namespace Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            services.AddSmtWithTrustedConnection<SqlDbContext, SmtTenant, SmtUser, SmtUserClaim>("PhuDinh", @"c:\Server.key");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseFileServer(new FileServerOptions()
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), @"website"))
                });
            }

            SmtSettings.Instance.DefaultOrderOption = new huypq.QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = "Ma",
                IsAscending = true
            };
            //app.UseCors(builder => builder.WithOrigins("http://localhost").AllowAnyHeader().AllowAnyMethod());
            app.UseSmt<SqlDbContext, SmtTenant, SmtUser, SmtUserClaim>("Server");
        }
    }
}