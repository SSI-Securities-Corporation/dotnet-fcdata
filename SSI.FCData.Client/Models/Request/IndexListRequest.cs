
namespace SSI.FCData.Models.Request
{
    public class IndexListRequest
    {
        public string Exchange { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
