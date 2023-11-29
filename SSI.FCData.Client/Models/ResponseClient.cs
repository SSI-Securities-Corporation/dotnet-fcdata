using System.Runtime.Serialization;

namespace SSI.FCData.Models
{
    [DataContract]
    public class ResponseClient<T> where T : class
    {
        [DataMember(Order = 1)]
        public byte[] Data { get; set; }
        [DataMember(Order = 2)]
        public string Message { get; set; }
        [DataMember(Order = 3)]
        public int StatusCode { get; set; }

        public T DeserializeObj { get; set; }
    }
}
