using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WebDoctor.Business;
using WebDoctor.Data;

namespace WebDoctor
{
    public class AutofacWebConfig
    {
        public static void ConfigureContainer()
        {
            var builder=new ContainerBuilder();

            // MVC - OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // MVC - Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // MVC - OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // MVC - OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // MVC - OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register application services.
            builder.RegisterType<DoctorDbContext>().As<IDoctorDbContext>().InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            // builder.RegisterGeneric(typeof(GeneralEngines)).As(typeof(IGeneralEngine)).InstancePerDependency();


            builder.RegisterType<CategoryEngine>().As<ICategoryEngine>().InstancePerDependency();
            builder.RegisterType<ArticleEngine>().As<IArticelEngine>().InstancePerDependency();
            builder.RegisterType<LabelEngine>().As<ILabelEngine>().InstancePerDependency();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}