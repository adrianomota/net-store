namespace NetStore.Api.Configurations;

using System.Reflection;
using Microsoft.OpenApi.Models;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => 
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "NetDevStore services api",
                Description = "Api - Management catalog of products",
                Version = "v1"   
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insert token like this: Bearer {your token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            var host = Environment.GetEnvironmentVariable("HOST");
            var hostBasePath = Environment.GetEnvironmentVariable("HOST_BASE_PATH");
            var hostPort = Environment.GetEnvironmentVariable("HOST_PORT");

            app.UseSwagger(options =>
            {

                if (!string.IsNullOrEmpty(host))
                    options.PreSerializeFilters.Add((swagger, httpReq) =>
                    {

                        var serverUrl = $"{httpReq.Scheme}://{host}/{hostBasePath}";

                        if (!string.IsNullOrEmpty(hostPort))
                            serverUrl = $"{httpReq.Scheme}://{host}:{hostPort}/{hostBasePath}";

                        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
                    });
            });
            app.UseSwaggerUI(c =>
            {
                if (!string.IsNullOrEmpty(hostBasePath))
                    c.SwaggerEndpoint($"/{hostBasePath}/swagger/v1/swagger.json", "v1");
                else
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
}
