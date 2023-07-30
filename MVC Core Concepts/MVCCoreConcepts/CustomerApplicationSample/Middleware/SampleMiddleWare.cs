using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplicationSample
{
    /* The order in which SampleMiddleWare is placed in the configure method effects the number of inovation of the Invoke method detail explaination is given at the end*/
    public class SampleMiddleWare
    {
        private readonly RequestDelegate _next;
        private int rcount = 0;
        private int rscount = 0;
        private readonly object _lock = new object();
        public SampleMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            lock (_lock)
            {
                if (httpContext.Request.Method == "GET")
                {
                    Console.WriteLine($"Request - {rcount++}");
                }
                int statusCode = httpContext.Response.StatusCode;
                if (statusCode >= 200)
                {
                    Console.WriteLine($"Response - {rscount++}");
                }
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SampleMiddleWareExtensions
    {
        public static IApplicationBuilder UseSampleMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SampleMiddleWare>();
        }
    }

    /*
     The middleware is being invoked multiple times because of the behavior of other middleware and internal requests triggered during the processing of an HTTP request in ASP.NET Core.
    When you place your `SampleMiddleWare` before other middleware, such as `UseStaticFiles`, `UseRouting`, `UseAuthentication`, and `UseAuthorization`, it will be the first middleware in the pipeline to process the incoming request. However, the execution of other middleware components can lead to additional internal requests being made within the application.
    Let's understand why this can happen:
        1. Static Files Middleware (`UseStaticFiles`): When a request is made for a static file (e.g., CSS, JavaScript, images), the `UseStaticFiles` middleware intercepts it and serves the file directly from the specified directory. Serving static files is a common scenario in web applications.
        2. Routing Middleware (`UseRouting`): The `UseRouting` middleware parses the incoming URL and determines which endpoint (controller action) should handle the request based on the route configuration.
        3. Authentication Middleware (`UseAuthentication`): If your application uses authentication, the `UseAuthentication` middleware performs authentication checks based on the authentication scheme and settings you've configured.
        4. Authorization Middleware (`UseAuthorization`): If your application uses authorization, the `UseAuthorization` middleware applies authorization policies to determine whether the user is allowed to access the requested resource.

    Now, if one of these middleware components (e.g., `UseStaticFiles`, `UseRouting`, etc.) generates an internal request within your application, that internal request will also go through the middleware pipeline. As a result, all the middleware components, including your `SampleMiddleWare`, will be invoked again for the internal request.
    Here's the sequence of events:
        1. An external HTTP request comes in and is processed by `SampleMiddleWare`, which increments `rcount`.
        2. Suppose during the request processing, an internal request is triggered, such as fetching a static file or routing to another endpoint. This internal request will go through the entire middleware pipeline, including `SampleMiddleWare`, which increments `rcount` again for the internal request.
    This behavior is a characteristic of how the ASP.NET Core middleware pipeline works, especially during development when various components interact, triggering internal requests.
    If you want to avoid multiple invocations of `SampleMiddleWare`, you can consider:
    1. Placing `SampleMiddleWare` after other middleware components that might trigger internal requests.
    2. Implementing logic inside `SampleMiddleWare` to control its behavior based on the request context (e.g., skipping multiple increments for internal requests).
    3. Understanding that in a real-world scenario, multiple invocations of middleware for a single request are common due to internal requests and other factors in the application's execution flow.
     */
}
