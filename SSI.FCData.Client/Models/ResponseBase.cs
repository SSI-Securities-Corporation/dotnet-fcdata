using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SSI.FCData.Models
{
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
