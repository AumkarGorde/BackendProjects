using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OnlineStoreApplication.Model.Enum;
using System;

namespace OnlineStoreApplication
{
    public static class SwaggerService
    {
        public static void Register(IServiceCollection _service)
        {
            _service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Online Store",
                    Description = "API Showing EF Core Implementation ",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Omkar Gorde",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    }

                });

                c.UseInlineDefinitionsForEnums();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
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
                            new string[] {}

                    }
                });

                //TODO: Check uses of this
                // Set the comments path for the Swagger JSON and UI. 
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
