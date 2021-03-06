
using System.Net;
using System.Text.Json;
using WebUtilities.Services;

namespace AccountService.Errors
{
    public class ErrorsHandler
    {
        private readonly RequestDelegate next;
        public ErrorsHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await next(context);
            }
            catch(Exception error) 
            {
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(JsonService.GetErrorJson(null, new List<string>() { error.Message }));
                await response.WriteAsync(result);
            }
        }
    }
}
