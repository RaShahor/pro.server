using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Entities;
using Microsoft.AspNetCore.Builder;

namespace RSWebApp.MiddleWare
{
    public class RatingMiddleWare
    {
        private readonly RequestDelegate _next;

        public RatingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, SignContext schoolBusContext)
        {


            Rating r = new Rating { Host = httpContext.Request.Host.ToString(), RecordDate = DateTime.Now, Method = httpContext.Request.Method, Path = httpContext.Request.Path, UserAgent = httpContext.Request.Headers["UserAgent"] };
            await schoolBusContext.Ratings.AddAsync(r);
            await schoolBusContext.SaveChangesAsync();
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleWare>();
        }
    }
}
