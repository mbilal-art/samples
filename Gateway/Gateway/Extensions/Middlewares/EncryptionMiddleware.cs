namespace Gateway.Extensions.Middlewares
{
    public class EncryptionMiddleware
    {
        private readonly RequestDelegate _next;

        public EncryptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Body = Cryptography.EncryptStream(httpContext.Response.Body);
            httpContext.Request.Body = Cryptography.DecryptStream(httpContext.Request.Body);
            if (httpContext.Request.QueryString.HasValue)
            {
                string decryptedString = Cryptography.DecryptString(httpContext.Request.QueryString.Value.Substring(1));
                httpContext.Request.QueryString = new QueryString($"?{decryptedString}");
            }
            await _next(httpContext);
            await httpContext.Request.Body.DisposeAsync();
            await httpContext.Response.Body.DisposeAsync();
        }
    }
}
