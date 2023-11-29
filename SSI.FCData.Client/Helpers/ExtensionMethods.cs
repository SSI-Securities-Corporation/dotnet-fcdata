using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SSI.FCData
{
    public static class ExtensionMethods
    {
        public static string ToQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" +Uri.EscapeDataString(p.GetValue(obj, null).ToString());
            return String.Join("&", properties.ToArray());
        }
    }
    
}
