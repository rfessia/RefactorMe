namespace RefactorMe.Console.ViewModel
{
    using RefactorMe.DontRefactor.Models;

    /// <summary>
    /// Product view model
    /// </summary>
    public class ProductVM : Product
    {
        /// <summary>
        /// Percentage of money
        /// </summary>
        public bool WithPercentage { get; set; }
    }
}
