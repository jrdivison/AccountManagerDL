namespace AccountManager.API.Filters
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public class ErrorHandlerFilterMiddlewarer
    {
        private readonly RequestDelegate next;

        public ErrorHandlerFilterMiddlewarer(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (DbUpdateException ex)
            {
                await WriteException(context, new { error = ex.InnerException.Message },
                   HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                await WriteException(context, new { error = ex.InnerException.Message }, 
                    HttpStatusCode.InternalServerError);
            }
        }

        private static Task WriteException(HttpContext context
            , Object resultObject, HttpStatusCode statuscode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statuscode;

            var result = JsonConvert.SerializeObject(resultObject);
            return context.Response.WriteAsync(result);
        }
    }
}
