using System.Collections.Generic;
using System.Runtime.Serialization;
using ProtoBuf;
using SSI.FastConnect.DataContracts.Files;
using SSI.FastConnect.DataContracts.Market.Response;

namespace SSI.FastConnect.DataContracts
{
    [DataContract]
    [ProtoInclude(100, typeof(DailyIndexResponse))]
    [ProtoInclude(101, typeof(DailyOhlcResponse))]
    [ProtoInclude(102, typeof(IndexComponentResponse))]
    [ProtoInclude(103, typeof(IndexListResponse))]
    [ProtoInclude(104, typeof(SecuritiesDetailsResponse))]
    [ProtoInclude(105, typeof(SecuritiesListResponse))]
    [ProtoInclude(106, typeof(StockPriceResponse))]
    [ProtoInclude(107, typeof(IntradayOHLCResponse))]
    [ProtoInclude(108, typeof(FileResponse))]
    public class ResponseBase<T>
    {
        [DataMember(Order = 1, Name = "data")]
        public List<T> Data { get; set; }

        [DataMember(Order = 2, Name = "message")]
        public string Message { get; set; } = "Undefine";

        [DataMember(Order = 3, Name = "status")]
        public string Status { get; set; } = "Undefine";

        [DataMember(Order = 4, Name = "totalRecord")]
        public int TotalRecord { get; set; } = 0;
    }
}
