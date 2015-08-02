using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmltfy.Models
{
    public class RedirectModel
    {
        public string RedirectUrl { get; set; }
        public string Key { get; set; }

        public RedirectModel(string redirectUrl, string redirectKey = "")
        {
            RedirectUrl = redirectUrl;
            Key = redirectKey;
        }
    }
}