namespace RefactorMe.Console.Services.Product
{
    using RefactorMe.Console.ViewModel;
    using System.Collections.Generic;

    /// <summary>
    /// Product interface
    /// </summary>
    public interface IProductService
    {
        List<ProductVM> GetWithoutPercentage(List<object> dinamycProducts, string methodName);
        List<ProductVM> GetWithPercentage(List<object> dinamycProducts, string methodName, List<double> percentageList);
    }
}
