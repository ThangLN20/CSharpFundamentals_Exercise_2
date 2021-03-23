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
        _logger = logger;
    }

     public async Task Invoke(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        await _next.Invoke(context);
        watch.Stop();

        _logger.LogTrace("{duration}ms", watch.ElapsedMilliseconds);
    }


   
}