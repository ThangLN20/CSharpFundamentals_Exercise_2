using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
namespace DotNetCoreMiddleware
{

    public class TimmingMiddleware
    {
        private readonly RequestDelegate _next;
        public TimmingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();
            var name = context.Request.Query["name"];

            if (!String.IsNullOrWhiteSpace(name) )
            {
                context.Request.Headers.Add("name",name);
            }
            await context.Response.WriteAsync($"<h1>URL: {context.Request.Path} {context.Request.QueryString}</h1>");
            await context.Response.WriteAsync($"<h1> {name} </h1><h2>The time current request took: {sw.ElapsedMilliseconds} Milliseconds</h2>");
            await _next(context);
        }
    }
}