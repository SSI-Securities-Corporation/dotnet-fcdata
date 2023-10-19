using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.FastConnect.DataContracts.Enums
{
    public enum MarketStatControlCodeEnum
    {
        [Description("Đóng cửa MainBoard")]
        C,
        [Description("Kết thúc nghỉ giữa đợt")]
        F,
        [Description("")]
        G,
        [Description("Ngưng giao dịch tất cả ck")]
        H,
        [Description("Bắt đầu nghỉ giữa đợt")]
        I,
        [Description("")]
        J,
        [Description("Kết thúc đợt Run-off")]
        K,
        [Description("Giao dịch trở lại của ck cụ thể")]
        N,
        [Description("Bắt đầu đợt KL liên tục")]
        O,
        [Description("Bắt đầu đợt KL định kỳ")]
        P,
        [Description("Giao dịch trở lại tất cả ck")]
        R,
        A
    }
}
