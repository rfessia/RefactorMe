namespace RefactorMe.Console.Helpers
{
    using RefactorMe.Console.Constants;
    using RefactorMe.DontRefactor.Models;
    using System;

    /// <summary>
    /// Helper for types of products
    /// </summary>
    public static class ProducTypeHelper
    {
        /// <summary>
        /// Get the name of a product type
        /// </summary>
        /// <param name="productType">Kind of product</param>
        /// <returns></returns>
        public static string GetType(Type productType)
        {
            var result = "";
            if (productType == typeof(Lawnmower))
            {
                result = ProductTypeConstant.Lawnmower;
            }
            else if (productType == typeof(PhoneCase))
            {
                result = ProductTypeConstant.PhoneCase;
            }
            else if (productType == typeof(TShirt))
            {
                result = ProductTypeConstant.TShirt;
            }

            return result;
        }
    }
}
