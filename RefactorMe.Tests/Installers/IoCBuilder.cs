namespace RefactorMe.Tests.Installers
{
    using Autofac;
    using RefactorMe.Console.Map;
    using RefactorMe.Console.Services.Print;
    using RefactorMe.Console.Services.Product;
    using RefactorMe.DontRefactor.Data.Implementation;
    using System.Collections.Generic;

    /// <summary>
    /// AutoFac configuration
    /// </summary>
    public static class IoCBuilder
    {
        /// <summary>
        /// Initializer of the container instance
        /// </summary>
        public static void Build()
        {
            var builder = new ContainerBuilder();
            var container = Register(builder);
            Resolver(container);
        }

        /// <summary>
        /// Register all services
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private static IContainer Register(ContainerBuilder builder)
        {
            builder.RegisterType<LawnmowerRepository>();
            builder.RegisterType<PhoneCaseRepository>();
            builder.RegisterType<TShirtRepository>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<PrintService>().As<IPrintService>();
            builder.RegisterType<ProductMap>().As<IProductMap>();
            return builder.Build();
        }

        /// <summary>
        /// Resolve all instances
        /// </summary>
        /// <param name="container"></param>
        private static void Resolver(IContainer container)
        {
            BaseTest.productService = container.Resolve<IProductService>();
            BaseTest.printService = container.Resolve<IPrintService>();
            BaseTest.lawnmowerRepository = container.Resolve<LawnmowerRepository>();
            BaseTest.phoneCaseRepository = container.Resolve<PhoneCaseRepository>();
            BaseTest.tShirtRepository = container.Resolve<TShirtRepository>();
            BaseTest.myDinamycList = new List<object>
            {
                BaseTest.lawnmowerRepository,
                BaseTest.phoneCaseRepository,
                BaseTest.tShirtRepository
            };
        }

    }
}
