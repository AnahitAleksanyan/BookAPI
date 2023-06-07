using WebApplication4.statics;

namespace WebApplication4.Middlewares
{
    public class LanguageGetterMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguageGetterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var language = context.Request.Headers["lang"];

            LanguageInfo.Language = language.ToString();

            await _next(context);
        }
    }
}
