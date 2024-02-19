using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    public class MoovIt : IMoovIt
    {
        private HashSet<Route> routes;
        private Dictionary<string, Route> routeMap;

        public MoovIt()
        {
            this.routes = new HashSet<Route>();
            this.routeMap = new Dictionary<string, Route>();
        }


        public void AddRoute(Route route)
        {
            if (this.routes.Contains(route))
            {
                throw new ArgumentException();
            }

            this.routes.Add(route);
            this.routeMap.Add(route.Id, route);
        }

        public void RemoveRoute(string routeId)
        {

            if (!this.routeMap.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            var route = this.routeMap[routeId];

            this.routes.Remove(route);
            this.routeMap.Remove(route.Id);
        }

        public bool Contains(Route route)
        {
            return this.routes.Contains(route);
        }

        public int Count => this.routes.Count;

        public Route GetRoute(string routeId)
        {
            if (!this.routeMap.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            return this.routeMap[routeId];
        }

        public void ChooseRoute(string routeId)
        {
            if (!this.routeMap.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            this.routeMap[routeId].Popularity++;
        }


        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
        {
            return this.routes
                .Where(r => r.IsFavorite &&
                 r.LocationPoints.IndexOf(destinationPoint) > 0)
                .OrderBy(r => r.Distance)
                .ThenByDescending(r => r.Popularity);
        }


        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
        {
            return this.routes
                 .OrderByDescending(r => r.Popularity)
                 .ThenBy(r => r.Distance)
                 .ThenBy(r => r.LocationPoints.Count)
                 .Take(5);
        }


        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
        {
            return this.routes
                 .Where(r => r.LocationPoints.IndexOf(startPoint) >= 0 && r.LocationPoints.IndexOf(startPoint) < r.LocationPoints.IndexOf(endPoint))
                 .OrderBy(r => r.IsFavorite)
                 .ThenBy(r => r.LocationPoints.IndexOf(endPoint) - r.LocationPoints.IndexOf(startPoint))
                 .ThenByDescending(r => r.Popularity);
        }
    }
}
