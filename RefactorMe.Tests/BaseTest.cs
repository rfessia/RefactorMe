namespace RefactorMe.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RefactorMe.Console.Services.Print;
    using RefactorMe.Console.Services.Product;
    using RefactorMe.DontRefactor.Data.Implementation;
    using RefactorMe.Tests.Installers;
    using System.Collections.Generic;

    /// <summary>
    /// Base class for test
    /// </summary>
    [TestClass]
    public abstract class BaseTest
    {
        public static LawnmowerRepository lawnmowerRepository;
        public static PhoneCaseRepository phoneCaseRepository;
        public static TShirtRepository tShirtRepository;
        public static IProductService productService;
        public static IPrintService printService;
        public static List<object> myDinamycList;

        /// <summary>
        /// Initialize all installers
        /// </summary>
        [TestInitialize]
        public void InitializeTest()
        {
            IoCBuilder.Build();
        }
    }
}
