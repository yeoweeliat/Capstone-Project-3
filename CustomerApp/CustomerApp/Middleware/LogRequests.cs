using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// add sequence of firing (middleware in startup.cs)
// logic of middleware, we write in Invoke() method
// middleware executed for every request - jquery src, logo picture etc
// middleware only executed for mvc
namespace CustomerApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogRequests
    {
        private readonly RequestDelegate _next;

        public LogRequests(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //add pre-processing logic here

            // string URL path
            var urlPath = httpContext.Request.Path;
            // write to d:\log.txt
            //System.IO.File.AppendAllText(@"e:\logywl.txt", urlPath.ToString()); // WriteAllText will overwrite previous content...
            System.IO.File.AppendAllText(@"e:\logywl.txt", DateTime.Now + ", " + urlPath.ToString() + "\n"); //Environment.NewLine = \n but works for max and linux (other os apart from windows)


            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogRequestsExtensions
    {
        public static IApplicationBuilder UseLogRequests(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogRequests>();
        }
    }
}
