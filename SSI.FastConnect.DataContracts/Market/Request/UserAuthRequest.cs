using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.FastConnect.DataContracts.Market.Request
{
    public class UserAuthRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    public class ServerRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string ServiceId { get; set; }
        public string Ip { get; set; }
    }
}
