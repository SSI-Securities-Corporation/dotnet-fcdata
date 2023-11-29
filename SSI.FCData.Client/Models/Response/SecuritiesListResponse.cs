
namespace SSI.FCData.Models.Response
{
    public class SecuritiesListResponse : ResponseBase<SecuritiesListResponseModel>
    {
        
    }
    public class SecuritiesListResponseModel
    {
        public string Market { get; set; }
        public string Symbol { get; set; }
        public string StockName { get; set; }
        public string StockEnName { get; set; }
    }
}
