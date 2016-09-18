using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Parent.Child
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes()) {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Route = new Route(
                        "Parent/{parentId}",
                        new RouteValueDictionary {{"area", "Parent.Child" }, {"controller", "Stock"}, {"Action", "Parent"}},
                        new RouteValueDictionary(),
                        new RouteValueDictionary {{"area", "Parent.Child" } },
                        new MvcRouteHandler())
                }
            };
        } 
    }
}