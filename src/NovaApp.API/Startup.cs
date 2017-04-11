using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using NovaApp.API.DataProvider;
using Swashbuckle.Swagger.Model;

namespace NovaApp.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .AddUserSecrets();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddSwaggerGen(
                x =>
                {
                    x.DescribeAllEnumsAsStrings();
                });

            services.ConfigureSwaggerGen(
                setup =>
                {
                    setup.SingleApiVersion(
                        new Info
                        {
                            Version = "v1",
                            Description = "UFDF Central API",
                            Title = "UFDF Central API",
                            TermsOfService = "None",
                        });
                    setup.DescribeStringEnumsInCamelCase();
                });

            services.Configure<GzipCompressionProviderOptions>(config => config.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(
                config =>
                {
                    config.EnableForHttps = true;
                    config.Providers.Add<GzipCompressionProvider>();
                    config.MimeTypes = ResponseCompressionDefaults.MimeTypes;
                });

            services.AddSingleton<IDataProvider, MockDataProvider>();
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug(LogLevel.Trace);

            UseCustomCors(app);

            app.UseResponseCompression();

            UseCustomSwagger(app);

            app.UseMvc();
        }

        public static IApplicationBuilder UseCustomCors(IApplicationBuilder app)
        {
            app.Use(async (httpContext, next) =>
            {
                if (httpContext.Request.Path.Value.Contains("rest/"))
                {
                    httpContext.Response.Headers.Add("Access-Control-Allow-Origin", new StringValues(httpContext.Request.Headers["Origin"].ToArray()));
                    httpContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept, Authorization, SC-Service-Link" });
                    httpContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PATCH, PUT, DELETE, OPTIONS" });
                    httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });

                    if (httpContext.Request.Method == "OPTIONS") return;
                }

                await next();
            });

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.WithMethods("GET, POST, PUT, DELETE, OPTIONS");
                builder.AllowAnyOrigin();
                builder.AllowCredentials();
            });

            return app;
        }

        public static IApplicationBuilder UseCustomSwagger(IApplicationBuilder app)
        {
            app.UseSwagger(
                (request, doc) =>
                {

                    doc.Schemes = new List<string> { "http", "https" };
                });

            app.UseSwaggerUi();

            return app;
        }

    }
}
