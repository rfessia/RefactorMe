namespace RefactorMe.Console.Services.Print
{
    using RefactorMe.Console.ViewModel;
    using System.Collections.Generic;

    /// <summary>
    /// Print interface
    /// </summary>
    public interface IPrintService
    {
        void PrintDetailsProducts(List<ProductVM> Products);
    }
}
