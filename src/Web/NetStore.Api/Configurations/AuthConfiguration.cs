using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetStore.Catalog.Application.Config;

namespace NetStore.Api.Configurations;

public static class AuthConfiguration
{
    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var jwtOptions = new JwtOptions();
            var section = config.GetSection(nameof(JwtOptions));
            new ConfigureFromConfigurationOptions<JwtOptions>(section).Configure(jwtOptions);
            services.AddSingleton(jwtOptions);

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                    ValidAudience = jwtOptions.Audience,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidateIssuerSigningKey = false,
                    ValidateLifetime = false,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
}
