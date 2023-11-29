using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.FCData.Models
{
    public class SingleResponse<T>
    {
        public string message { get; set; }
        public int status { get; set; }
        public T data { get; set; }
    }
}
