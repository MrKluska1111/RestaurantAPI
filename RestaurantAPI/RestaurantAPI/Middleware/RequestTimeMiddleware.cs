using Microsoft.Extensions.Logging;
using RestaurantAPI.Exceptions;
using System.Diagnostics;

namespace RestaurantAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch _stopwatch;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();

            await next.Invoke(context);
            //Thread.Sleep(4000);

            _stopwatch.Stop();

            if (_stopwatch.ElapsedMilliseconds/1000 > 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {_stopwatch.Elapsed} ms.";
                _logger.LogInformation(message);
            }
        }
    }
}
