namespace RefactorMe.Console.Services.Print
{
    using RefactorMe.Console.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Print implementation
    /// </summary>
    public class PrintService : IPrintService
    {
        /// <summary>
        /// Print al the details of the products
        /// </summary>
        /// <param name="Products">List of view model products</param>
        public void PrintDetailsProducts(List<ProductVM> Products)
        {
            for (int i = 0; i < Products.Count(); i++)
            {
                Console.WriteLine($"| Nombre {Products[i].Name}");
                Console.WriteLine($"| Precio {Products[i].Price}");
                Console.WriteLine($"| Tipo {Products[i].Type}");
                Console.WriteLine($"----------------------------");
            }
        }
    }
}
