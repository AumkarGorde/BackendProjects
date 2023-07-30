using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplicationSample
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /* 
       1. When a request comes in, it flows through the middleware pipeline from the top (the first middleware added) to the bottom (the last middleware added).
       2. Each middleware component in the pipeline has the opportunity to inspect, modify, or handle the request as it passes through.
       3. Once the request has passed through all the middleware components, it reaches the appropriate controller action method to generate the response.
       4. The controller action method processes the request, performs the necessary logic, and generates a response.
       5. The response then flows back through the middleware pipeline in the same order, from the top to the bottom.
       6. Each middleware component has the opportunity to inspect, modify, or handle the response as it flows through.
       7. Finally, the response is sent back to the client as an HTTP response.*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                /* You will see an error page with detailed information about the unhandled exception, including the stack trace, request information, and more.
                   You only require this when you are running the application locally to understand the stacktrace
                 */
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

            /*a middleware in ASP.NET Core that automatically redirects HTTP requests to HTTPS. */
            app.UseHttpsRedirection();

            
            /* The static files stored in wwwroot folder are made accessible by this middleware*/
            app.UseStaticFiles();

           
            /* Required Mandatory field*/
            app.UseRouting();

            /*Once the user's identity is established, the app.UseAuthorization() middleware takes over. 
             * It examines the user's identity and applies authorization rules to determine whether the user is allowed to access specific resources or perform certain actions within the application. 
             * Authorization rules are typically based on roles, policies, or claims associated with the user's identity.*/
            app.UseAuthorization();

            /* If you want to add collection of routes create a static class and pass the instance of IEndpointRouteBuilder
             Eg: - RouteConfig.ConfigureRoutes(app.UseEndpoints);
             */
            SampleMiddleWareExtensions.UseSampleMiddleWare(app);
            /* Required Mandatory field*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Customer}/{action=Home}");
            });


        }

        /* Routing
         * If your URL follows the default convention of "{controller}/{action}", you don't need to specify the routing explicitly in app.UseEndpoints(). 
         * The framework will use convention-based routing to map the URL to the appropriate controller and action.
         * If your URL path is different from the default convention, you can use MapControllerRoute() to define custom routing patterns and map them to specific controller actions.*/
    }
}
