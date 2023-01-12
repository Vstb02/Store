namespace Store.Domain.Filters.Products
{
    public class ProductFilter : BaseFilter
    {
        public Guid? Category { get; set; }
        public Guid? Brand { get; set; }
    }
}
