namespace APITest.API.Middleware
{
    public class SecurityHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SecurityHeaderMiddleware> _logger;
        public SecurityHeaderMiddleware(RequestDelegate next, ILogger<SecurityHeaderMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("Referrer-Policy", "no-referrer");
            context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");

            await _next(context);
        }
    }
}
