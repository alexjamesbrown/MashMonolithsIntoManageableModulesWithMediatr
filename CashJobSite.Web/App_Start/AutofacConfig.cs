using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CashJobSite.Application;
using CashJobSite.Application.CommandHandlers;
using CashJobSite.Application.Logging;
using CashJobSite.Data;
using CashJobSite.Data.Repositories;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Web
{
    public class AutofacConfig
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CashJobSiteDbContext>().As<ICashJobSiteDbContext>().InstancePerRequest();

            builder.RegisterType<JobRepository>().As<IRepository<Job>>();
            builder.RegisterType<JobReportRepository>().As<IRepository<JobReport>>();
            builder.RegisterType<JobApplicationRepository>().As<IRepository<JobApplication>>();

            builder.RegisterType<JobService>().As<IJobService>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<Logger>().As<ILogger>();

            //mediatr
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AddJobCommandHandler).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}