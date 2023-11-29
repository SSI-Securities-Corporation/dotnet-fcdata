
namespace SSI.FCData.Models.Response
{
    public class IndexListResponse : ResponseBase<IndexListResponseModel>
    {
        
    }
    public class IndexListResponseModel
    {
        public string IndexCode { get; set; }
        public string IndexName { get; set; }
        public string Exchange { get; set; }

    }
}
