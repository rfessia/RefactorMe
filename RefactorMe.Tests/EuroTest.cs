namespace RefactorMe.Tests
{
    using Console.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Test for Euro
    /// </summary>
    [TestClass]
    public class EuroTest : BaseTest
    {
        /// <summary>
        /// Get only product with Euro
        /// </summary>
        [TestMethod]
        public void GetOnlyEuro()
        {
            var percentagePrices = new List<double> { PercentageMoneyConstant.Euro };
            var productsWithEuro = productService.GetWithPercentage(myDinamycList, MethodConstant.GetAll, percentagePrices);
            var productsWithoutEuro = productService.GetWithoutPercentage(myDinamycList, MethodConstant.GetAll);
            for (int i = 0; i < productsWithEuro.Count; i++)
            {
                var originalProduct = productsWithoutEuro.Where(x => x.Name == productsWithEuro[i].Name).FirstOrDefault();
                Assert.IsTrue(productsWithEuro[i].Price == (originalProduct.Price * PercentageMoneyConstant.Euro));
            }
        }
    }
}
