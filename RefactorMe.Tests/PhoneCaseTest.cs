namespace RefactorMe.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RefactorMe.Console.Constants;
    using RefactorMe.DontRefactor.Data.Implementation;
    using System.Collections.Generic;

    /// <summary>
    /// Test for PhoneCase products
    /// </summary>
    [TestClass]
    public class PhoneCaseTest : BaseTest
    {
        /// <summary>
        /// Get only PhoneCase products with original price
        /// </summary>
        [TestMethod]
        public void GetOnlyPhoneCaseWithoutPercentage()
        {
            myDinamycList = new List<object>
            {
                new PhoneCaseRepository(),
            };

            var phoneCaseProducts = productService.GetWithoutPercentage(myDinamycList, MethodConstant.GetAll);
            for (int i = 0; i < phoneCaseProducts.Count; i++)
            {
                Assert.IsTrue(phoneCaseProducts[i].Type == ProductTypeConstant.PhoneCase);
            }
        }

        /// <summary>
        /// Get only PhoneCase products with differents types of price
        /// </summary>
        [TestMethod]
        public void GetOnlyPhoneCaseWithPercentage()
        {
            myDinamycList = new List<object>
            {
                new PhoneCaseRepository(),
            };

            var percentagePrices = new List<double>() { PercentageMoneyConstant.USDollar, PercentageMoneyConstant.Euro };
            var phoneCaseProducts = productService.GetWithPercentage(myDinamycList, MethodConstant.GetAll, percentagePrices);
            for (int i = 0; i < phoneCaseProducts.Count; i++)
            {
                Assert.IsTrue(phoneCaseProducts[i].Type == ProductTypeConstant.PhoneCase);
            }
        }

    }
}
