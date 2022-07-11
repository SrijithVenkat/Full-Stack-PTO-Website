
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FirstWebsite.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FirstWebsite.Web.App_Start
{ 
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SQLUserData>()
                .As<UserData>()
                .InstancePerRequest();
            builder.RegisterType<SQLRequestProcessing>()
                .As<RequestProcessing>()
                .InstancePerRequest();


            builder.RegisterType<UserDbContext>().InstancePerRequest();

            builder.RegisterType<RequestDbContext>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}