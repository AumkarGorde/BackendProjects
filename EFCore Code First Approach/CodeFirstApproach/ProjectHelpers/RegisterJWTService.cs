using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHelpers
{
    public static class RegisterJWTService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44310",
                        ValidAudience = "https://localhost:44310",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsSecretKeyForTokenValidation"))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminOrUser", policy =>
                    policy.RequireRole("ADMIN", "USER"));
            });
        }
    }
}
