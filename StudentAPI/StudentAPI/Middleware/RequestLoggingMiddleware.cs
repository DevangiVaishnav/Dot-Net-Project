namespace StudentAPI.Middleware
{
    // Copilot used to generate middleware for logging requests
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"Request: {context.Request.Path} at {DateTime.Now}");
            await _next(context);
        }
    }
}
