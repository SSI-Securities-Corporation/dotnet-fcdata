using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Files
{
    [DataContract]
    public class FileRequest
    {
        [DataMember(Order = 1)]
        public string ServiceName { get; set; }
        [DataMember(Order = 2)]
        public string Language { get; set; }
    }
}
