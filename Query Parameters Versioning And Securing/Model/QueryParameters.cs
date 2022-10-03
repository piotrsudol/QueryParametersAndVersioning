namespace Query_Parameters_Versioning_And_Securing.Model
{
    public class QueryParameters
    {
        const int MAX_SIZE = 100;
        private int size = 50;

        public int Page { get; set; } = 1;
        public int Size { get { return size; } set {
                size = Math.Min(MAX_SIZE, value);
            } }

        public int GetSkippedAmount() => Size * (Page - 1);
    }
}
