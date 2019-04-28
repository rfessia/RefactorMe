namespace RefactorMe.Console.Services.Product
{
    using Map;
    using RefactorMe.Console.ViewModel;
    using RefactorMe.DontRefactor.Data.Implementation;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Product implementation
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductMap productMap;

        public ProductService(IProductMap productMap)
        {
            this.productMap = productMap;
        }

        /// <summary>
        /// Get all the products with original price
        /// </summary>
        /// <param name="dinamycProducts">Generic list of different types of products</param>
        /// <param name="methodName">Name of the method of repository</param>
        /// <returns>List of view model products</returns>
        public List<ProductVM> GetWithoutPercentage(List<object> dinamycProducts, string methodName)
        {
            var result = new List<ProductVM>();
            IQueryable<object> allQueryableProducts = GetAllFromDataBase(dinamycProducts, methodName);
            result.AddRange(productMap.GenericToProducts(allQueryableProducts));

            return result;
        }

        /// <summary>
        /// Get all the products with the percentage of price of each one
        /// </summary>
        /// <param name="dinamycProducts">Generic list of different types of products</param>
        /// <param name="methodName">Name of the method of repository</param>
        /// <param name="percentagePrices">Percentage of price</param>
        /// <returns>List of view model products</returns>
        public List<ProductVM> GetWithPercentage(List<object> dinamycProducts, string methodName, List<double> percentagePrices)
        {
            var result = new List<ProductVM>();
            IQueryable<object> allQueryableProducts = GetAllFromDataBase(dinamycProducts, methodName);
            for (int i = 0; i < percentagePrices.Count; i++)
            {
                result.AddRange(productMap.GenericToProducts(allQueryableProducts, percentagePrices[i]));
            }

            return result;
        }

        /// <summary>
        /// Get different types of products from the repository
        /// </summary>
        /// <param name="dinamycProducts">Generic list of different types of products</param>
        /// <param name="methodName">Name of the method of repository</param>
        /// <returns>IQueryable of generic products</returns>
        private IQueryable<object> GetAllFromDataBase(List<object> dinamycProducts, string methodName)
        {
            IQueryable<object> result = Enumerable.Empty<object>().AsQueryable();
            foreach (var item in dinamycProducts)
            {
                var myType = item.GetType().BaseType;
                if (myType.Name == typeof(BaseReadOnlyRepository<>).Name)
                {
                    var method = item.GetType().GetMethod(methodName);
                    var getAll = (IQueryable<object>)method.Invoke(item, null);
                    result = result.Concat(getAll);
                }
            }

            return result;
        }
    }
}
