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
        protected static int _mode;
        public RatingMiddleWare(RequestDelegate next,int mo)
        {
            _next = next;
            _mode = mo;
        }

        public async Task Invoke(HttpContext httpContext, SignContext _signContext)
        {

            
            Rating r = new Rating { Host = httpContext.Request.Host.ToString(), RecordDate = DateTime.Now.AddYears(_mode), Method = httpContext.Request.Method, Path = httpContext.Request.Path, UserAgent = httpContext.Request.Headers["UserAgent"] };
            await _signContext.Ratings.AddAsync(r);
            await _signContext.SaveChangesAsync();
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder,int mode=0)
        {
            
            return builder.UseMiddleware<RatingMiddleWare>(mode);
        }
    }
}
