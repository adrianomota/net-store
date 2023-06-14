using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using NetStore.Catalog.Application.MapConfig;
using Newtonsoft.Json.Converters;

namespace NetStore.Api.Configurations;

public static class ApiConfigurations
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new CatalogMapConfig()));
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddControllers(config => 
        {
            var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
        });

        services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            services.AddSwaggerGenNewtonsoftSupport();

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseCors("Total");

            app.UseSwaggerSetup();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
}
