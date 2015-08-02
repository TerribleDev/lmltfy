using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lmltfy.Models;

namespace lmltfy.Util
{
    public static class Extensions
    {
        public static ApplicationBrandEnum? ToAppEnum(this string current)
        {
            //don't use enum.parse as its slow (reflection and all)
            if (string.Equals(current, AppNames.Lycos, StringComparison.CurrentCultureIgnoreCase))
            {
                return ApplicationBrandEnum.Lycos;                
            }
            if (string.Equals(current, AppNames.Ask, StringComparison.CurrentCultureIgnoreCase))
            {
                return ApplicationBrandEnum.Ask;
            }
            if(string.Equals(current, AppNames.DuckDuckGo, StringComparison.CurrentCultureIgnoreCase))
            {
                return ApplicationBrandEnum.DuckDuckGo;
            }
            return null;
        }
    }
}