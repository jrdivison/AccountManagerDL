using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AccountManager.API.Filters
{

    public class ErrorHandlerFilterMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlerFilterMiddleware(RequestDelegate next)
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
                await WriteException(context,
                new { error = ex.InnerException.Message },
                HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {

                await WriteException(context,
                new { error = ex.Message },
                HttpStatusCode.InternalServerError);
            }
        }

        private static Task WriteException(HttpContext context
            , object resultObject, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 
                (int)statusCode;

            var result = JsonConvert.SerializeObject(resultObject);
            return context.Response.WriteAsync(result);
        }
    }
}
