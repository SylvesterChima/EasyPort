using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPort.Helpers
{
    public class AppUtil
    {
        public string getMsg(string alertType, string Msg)
        {
            return $"<div class=\"m-alert alert alert-{alertType}\"> <strong>{alertType}!</strong> <span data-dismiss=\"alert\" class=\"close\">&times;</span> { Msg}</div>";
        }

        public string Naira { get; set; } = "&#8358;";
    }
    public class ResponseViewModel
    {
        public bool IsSuccessful { get; set; } = false;
        public string Msg { get; set; }
    }
}

public enum alert{
    success,
    danger,
    warning
}