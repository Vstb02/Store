namespace Store.Domain.Filters
{
    public class FilterPaging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
