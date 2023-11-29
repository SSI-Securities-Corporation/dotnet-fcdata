
using System.Collections.Generic;

namespace SSI.FCData.Models.Response
{
    public class IndexComponentResponse : ResponseBase<IndexComponentResponseModel>
    {
       
    }
    public class IndexComponentResponseModel
    {
        public string IndexCode { get; set; }
        public string IndexName { get; set; }
        public string Exchange { get; set; }
        public string TotalSymbolNo { get; set; }
        public List<IndexComponent> IndexComponent { get; set; }
    }

    public class IndexComponent
    {
        public string Isin { get; set; }
        public string StockSymbol { get; set; }
    }
}
