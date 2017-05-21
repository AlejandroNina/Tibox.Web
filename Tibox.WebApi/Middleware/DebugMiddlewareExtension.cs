using System;
using Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tibox.WebApi.Middleware
{
    public static class DebugMiddlewareExtension
    {
        //Para crear una extensión:
        public static void UseDebugMiddleware(this IAppBuilder app)
        {
            //app.Use<DebugMiddleware>();
        }
    }
}