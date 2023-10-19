using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Realtime
{
    [DataContract]
    public class MdhfData
    {
        [DataMember(Order = 1)]
        public string DataType { get; set; }
        [DataMember(Order = 2)]
        public string Content { get; set; }
    }
}