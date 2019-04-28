namespace RefactorMe.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RefactorMe.Console.Constants;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class UsDollarTest : BaseTest
    {
        [TestMethod]
        public void GetOnlyUsDollar()
        {
            var percentagePrices = new List<double> { PercentageMoneyConstant.USDollar };
            var productsWithDollar = productService.GetWithPercentage(myDinamycList, MethodConstant.GetAll, percentagePrices);
            var productsWithoutDollar = productService.GetWithoutPercentage(myDinamycList, MethodConstant.GetAll);
            for (int i = 0; i < productsWithDollar.Count; i++)
            {
                var originalProduct = productsWithoutDollar.Where(x => x.Name == productsWithDollar[i].Name).FirstOrDefault();
                Assert.IsTrue(productsWithDollar[i].Price == (originalProduct.Price * PercentageMoneyConstant.USDollar));
            }
        }
    }
}
