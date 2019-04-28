namespace RefactorMe.Console.Main
{
    using DontRefactor.Data.Implementation;
    using Installers;
    using RefactorMe.Console.Constants;
    using RefactorMe.Console.Services.Print;
    using RefactorMe.Console.Services.Product;
    using RefactorMe.Console.ViewModel;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static LawnmowerRepository lawnmowerRepository;
        public static PhoneCaseRepository phoneCaseRepository;
        public static TShirtRepository tShirtRepository;
        public static IProductService productService;
        public static IPrintService printService;
        public static List<object> myDinamycList;

        static void Main(string[] args)
        {
            IoCBuilder.Build();
            var allProducts = new List<ProductVM>();
            var percentagePrices = new List<double>() { PercentageMoneyConstant.USDollar, PercentageMoneyConstant.Euro };
            allProducts.AddRange(productService.GetWithoutPercentage(myDinamycList, MethodConstant.GetAll));
            allProducts.AddRange(productService.GetWithPercentage(myDinamycList, MethodConstant.GetAll, percentagePrices));
            printService.PrintDetailsProducts(allProducts);
            Console.ReadLine();
        }
    }
}
