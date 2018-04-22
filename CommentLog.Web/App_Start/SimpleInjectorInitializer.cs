[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CommentLog.Web.App_Start.SimpleInjectorInitializer), "Initialize")]


namespace CommentLog.Web.App_Start
{
    using DAL;
    using Process;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            InitializeContainer(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IUserProcess, UserProcess>();
            container.Register<IUserDataAccess, UserDataAccess>();
            container.Register<ICommentProcess, CommentProcess>();
            container.Register<ICommentsDataAccess, CommentsDataAccess>();
            container.Register<DbContext, MainDbContext>(Lifestyle.Scoped);
            container.Register(typeof(IEFRepository<>), typeof(EFRepository<>));
        }
    }
}