using System.Text;

namespace APITest.API.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
        public RequestResponseLoggingMiddleware(RequestDelegate next,
    ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }        
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

            //log request
            if (context.Request.Method == "POST" || context.Request.Method == "PUT")
            {
                context.Request.EnableBuffering();
                var requestBodyStream = new StreamReader(context.Request.Body);
                var requestBodyText = await requestBodyStream.ReadToEndAsync();
                context.Request.Body.Position = 0;

                _logger.LogInformation($"Request Body: {requestBodyText}");
            }

           
            await _next(context);

          //log response
            _logger.LogInformation($"Response: {context.Response.StatusCode}");
        }
    }
}
