using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckSecurity // for every request, check for security
    {
        private readonly RequestDelegate _next;

        public CheckSecurity(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //add pre-processing logic here
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckSecurityExtensions
    {
        public static IApplicationBuilder UseCheckSecurity(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckSecurity>();
        }
    }
}
