namespace RefactorMe.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RefactorMe.Console.Constants;
    using RefactorMe.DontRefactor.Data.Implementation;
    using System.Collections.Generic;

    /// <summary>
    /// Test for TShirt products
    /// </summary>
    [TestClass]
    public class TShirtTest : BaseTest
    {
        /// <summary>
        /// Get only TShirt products with original price
        /// </summary>
        [TestMethod]
        public void GetOnlyTShirtWithoutPercentage()
        {
            myDinamycList = new List<object>
            {
                new TShirtRepository(),
            };

            var tShirtProducts = productService.GetWithoutPercentage(myDinamycList, MethodConstant.GetAll);
            for (int i = 0; i < tShirtProducts.Count; i++)
            {
                Assert.IsTrue(tShirtProducts[i].Type == ProductTypeConstant.TShirt);
            }
        }

        /// <summary>
        /// Get only TShirt products with differents types of price
        /// </summary>
        [TestMethod]
        public void GetOnlyTShirtWithPercentage()
        {
            myDinamycList = new List<object>
            {
                new TShirtRepository(),
            };

            var percentagePrices = new List<double>() { PercentageMoneyConstant.USDollar, PercentageMoneyConstant.Euro };
            var tShirtProducts = productService.GetWithPercentage(myDinamycList, MethodConstant.GetAll, percentagePrices);
            for (int i = 0; i < tShirtProducts.Count; i++)
            {
                Assert.IsTrue(tShirtProducts[i].Type == ProductTypeConstant.TShirt);
            }
        }

    }
}
