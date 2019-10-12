using Microsoft.AspNetCore.Builder;
using System;

namespace Core.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(
           this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestLogMiddleware>();
            return builder;
        }
    }
}
