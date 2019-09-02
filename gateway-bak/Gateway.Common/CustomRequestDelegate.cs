using Gateway.Model;
using System;
using System.Threading.Tasks;

namespace Gateway.Common
{
    public delegate Task CustomRequestDelegate(RouteContext routeContext);
}
