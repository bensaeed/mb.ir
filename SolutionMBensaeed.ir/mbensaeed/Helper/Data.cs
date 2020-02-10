using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApp.Helpers
{
    public class Data
    {
        public static T UnProxy<T>(DbContext context, T proxyObject) where T : class
        {
            var proxyCreationEnabled = context.Configuration.ProxyCreationEnabled;
            try
            {
                context.Configuration.ProxyCreationEnabled = false;
                var poco = context.Entry(proxyObject).CurrentValues.ToObject() as T;

                return poco;
            }
            finally
            {
                context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            }
        }

        public static IList<T> UnProxy<T>(DbContext context, IEnumerable<T> proxyObject) where T : class
        {
            return UnProxy(context, proxyObject.AsQueryable());
        }

        public static IList<T> UnProxy<T>(DbContext context, IQueryable<T> proxyObject) where T : class
        {
            var proxyCreationEnabled = context.Configuration.ProxyCreationEnabled;
            try
            {
                context.Configuration.ProxyCreationEnabled = false;
                return proxyObject.ToList();
            }
            finally
            {
                context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            }
        }
    }
}