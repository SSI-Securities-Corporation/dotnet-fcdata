using System.Runtime.Serialization;

namespace SSI.FastConnect.DataContracts.Files
{
    [DataContract]
    public class FileResponseModel
    {
        [DataMember(Order = 1,Name = "FileBase64")]
        public string FileB64 { get; set; }
    }
}
