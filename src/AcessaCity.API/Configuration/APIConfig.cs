using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AcessaCity.API.Configuration
{
    public static class APIConfig
    {
        public static IServiceCollection WebAPIConfig(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());


                // options.AddPolicy("Production",
                //     builder =>
                //         builder
                //             .WithMethods("GET")
                //             .WithOrigins("http://acessacity.com.br")
                //             .SetIsOriginAllowedToAllowWildcardSubdomains()
                //             //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                //             .AllowAnyHeader());
            });            


            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            //app.UseMvc();
            return app;
        }        
    }
}