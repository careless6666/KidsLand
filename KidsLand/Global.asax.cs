﻿using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using KidsLand.Models.EF;
using Ninject.Web.Mvc;

namespace KidsLand
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer(new EntitiesContextInitializer());
            Database.SetInitializer<KidsLandIdentityContext>(new EntitiesContextInitializer());
        }
    }
}
