using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmltfy.Models
{

    public struct ApplicationBrand
    {
        public static List<string> Brands = new List<string> { Lycos, Ask, DuckDuckGo};
        public const string Lycos = "Lycos";
        public const string Ask = "Ask";
        public const string DuckDuckGo = "DuckDuckGo";
    }

}