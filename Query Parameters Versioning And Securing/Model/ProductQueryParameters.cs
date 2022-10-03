namespace Query_Parameters_Versioning_And_Securing.Model
{
    public class ProductQueryParameters : QueryParameters
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string SortBy { get; set; } = "Id";
        private string _sortOrder = "asc";
        public string SortOrder
        {
            get => _sortOrder;
            set {
                if (value == "asc" | value == "desc")
                    _sortOrder = value;
            }
        }
        public string Search { get; set; } = string.Empty;
    }
}
