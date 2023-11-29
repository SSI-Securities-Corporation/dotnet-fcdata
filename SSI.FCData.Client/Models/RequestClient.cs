using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SSI.FCData.Models
{
    [DataContract]
    public class RequestClient
    {
        [DataMember(Order = 1)]
        public byte[] Data { get; set; }
        [DataMember(Order = 2)]
        public Dictionary<string, string> Dic { get; set; }
        [DataMember(Order = 3)]
        public string Key { get; set; }
        public string Type { get; set; }
    }
}
