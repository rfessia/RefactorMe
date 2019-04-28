namespace RefactorMe.Tests
{
    using Console.ViewModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RefactorMe.Console.Constants;
    using System.Collections.Generic;

    /// <summary>
    /// Test for the main functionality of products
    /// </summary>
    [TestClass]
    public class ProductTest : BaseTest
    {
        /// <summary>
        /// Get a list with all the products
        /// </summary>
        [TestMethod]
        public void GetAllProducts()
        {
            var allProducts = new List<ProductVM>();
            var percentagePrices = new List<double>() { PercentageMoneyConstant.USDollar, PercentageMoneyConstant.Euro };
            var productsWithoutPercentage = productService.GetWithoutPercentage(myDinamycList, MethodConstant.GetAll);
            for (int i = 0; i < productsWithoutPercentage.Count; i++)
            {
                Assert.IsTrue(productsWithoutPercentage[i].WithPercentage == false);
            }

            allProducts.AddRange(productsWithoutPercentage);
            var productsWithPercentage = productService.GetWithPercentage(myDinamycList, MethodConstant.GetAll, percentagePrices);
            for (int i = 0; i < productsWithPercentage.Count; i++)
            {
                Assert.IsTrue(productsWithPercentage[i].WithPercentage == true);
            }

            allProducts.AddRange(productsWithPercentage);
            printService.PrintDetailsProducts(allProducts);
        }
    }
}
