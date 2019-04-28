namespace RefactorMe.Console.Map
{
    using RefactorMe.Console.Helpers;
    using RefactorMe.Console.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Product Mapping implementation
    /// </summary>
    public class ProductMap : IProductMap
    {
        /// <summary>
        /// Mapping a generic class of products to a view model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="products">IQueryable of products to map</param>
        /// <param name="percentageOfMoney">Percentage of money to final price</param>
        /// <returns>Lit of Product view model</returns>
        public List<ProductVM> GenericToProducts<T>(IQueryable<T> products, double percentageOfMoney = 1) where T : class
        {
            percentageOfMoney = percentageOfMoney == 0 ? 1 : percentageOfMoney;
            var withPercentage = percentageOfMoney == 1 ? false : true;
            var result = products.Select(x => new ProductVM()
            {
                Id = (Guid)x.GetType().GetProperty(nameof(ProductVM.Id)).GetValue(x),
                Name = x.GetType().GetProperty(nameof(ProductVM.Name)).GetValue(x).ToString(),
                Price = Convert.ToDouble(x.GetType().GetProperty(nameof(ProductVM.Price)).GetValue(x)) * percentageOfMoney,
                Type = ProducTypeHelper.GetType(x.GetType()),
                WithPercentage = withPercentage
            }).ToList();

            return result;
        }

    }
}
