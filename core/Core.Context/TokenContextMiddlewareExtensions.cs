using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Context
{
    public static class TokenContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenContext(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenContextMiddleware>();
        }
    }
}
