using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class RequestDurationMiddlewares
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestDurationMiddlewares> _logger;

    public RequestDurationMiddlewares(RequestDelegate next, ILogger<RequestDurationMiddlewares> logger)
    {
        _next = next;
        //_logger = logger;
    }

     public async Task Invoke(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        await _next.Invoke(context);
        string name =context.Request.Query["name"];
            if(name != null) {
                context.Request.Headers.Add("time",DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            } 

                Console.WriteLine($"Query:{context.Request.QueryString}");
                Console.WriteLine($"Elasped time:{sw.ElapsedTicks.ToString()}");

            await _next(context);
            }
         
         
        //watch.Stop();
        //_logger.LogTrace("{duration}ms", watch.ElapsedMilliseconds);
    
        public static class CustomMiddlewareExtension 
        {
            public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder) 
            {
                return builder.UseMiddleware<CustomMiddleware>();
            }
        }
}





   
}
