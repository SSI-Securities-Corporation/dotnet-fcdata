namespace SSI.FCData.Models.Request
{
    public class IndexComponentRequest
    {
        public string IndexCode { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 1000;
    }
}
