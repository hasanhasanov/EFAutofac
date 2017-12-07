using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace WebDoctor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Start autofac container
            AutofacWebConfig.ConfigureContainer();

            // Standard MVC setup:
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //FalidationFactory
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
