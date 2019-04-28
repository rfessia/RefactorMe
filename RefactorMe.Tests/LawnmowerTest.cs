namespace RefactorMe.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RefactorMe.Console.Constants;
    using RefactorMe.DontRefactor.Data.Implementation;
    using System.Collections.Generic;

    /// <summary>
    /// Test for Lawnmower products
    /// </summary>
    [TestClass]
    public class LawnmowerTest : BaseTest
    {

        /// <summary>
        /// Get only Lawnmower products with original price
        /// </summary>
        [TestMethod]
        public void GetOnlyLawnmowerWithoutPercentage()
        {
            myDinamycList = new List<object>
            {
                new LawnmowerRepository(),
            };

            var lawnmowerProducts = productService.GetWithoutPercentage(myDinamycList, MethodConstant.GetAll);
            for (int i = 0; i < lawnmowerProducts.Count; i++)
            {
                Assert.IsTrue(lawnmowerProducts[i].Type == ProductTypeConstant.Lawnmower);
            }
        }

        /// <summary>
        /// Get only Lawnmower products with differents types of price
        /// </summary>
        [TestMethod]
        public void GetOnlyLawnmowerWithPercentage()
        {
            myDinamycList = new List<object>
            {
                new LawnmowerRepository(),
            };

            var percentagePrices = new List<double>() { PercentageMoneyConstant.USDollar, PercentageMoneyConstant.Euro };
            var lawnmowerProducts = productService.GetWithPercentage(myDinamycList, MethodConstant.GetAll, percentagePrices);
            for (int i = 0; i < lawnmowerProducts.Count; i++)
            {
                Assert.IsTrue(lawnmowerProducts[i].Type == ProductTypeConstant.Lawnmower);
            }
        }

    }
}
