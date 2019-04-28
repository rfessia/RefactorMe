namespace RefactorMe.Console.Map
{
    using RefactorMe.Console.ViewModel;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Product Mapping interface
    /// </summary>
    public interface IProductMap
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="products"></param>
        /// <param name="percentageOfMoney"></param>
        /// <returns></returns>
        List<ProductVM> GenericToProducts<T>(IQueryable<T> products, double percentageOfMoney = 1) where T : class;
    }
}
