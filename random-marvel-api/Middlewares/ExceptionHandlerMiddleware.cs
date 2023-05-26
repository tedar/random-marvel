namespace random_marvel_api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // We do not return to the caller the error details. Logs will be stored in a centralized location for later analysis.
                int statusCode = StatusCodes.Status500InternalServerError;
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                Trace trace = new();
                await context.Response.WriteAsync(JsonConvert.SerializeObject(trace));

                var req = context.Request;
                _logger.LogError(
                    "{traceId}:{reqPath}:{reqQueryString}:{statusCode}:{exMessage} ",
                    trace.TraceId, req.Path, req.QueryString, statusCode, ex.Message);
            }
        }
    }

    public class Trace
    {
        public Trace()
        {
            TraceId = Guid.NewGuid();
        }

        [JsonProperty("traceId")]
        public Guid? TraceId { get; set; }
    }
}
