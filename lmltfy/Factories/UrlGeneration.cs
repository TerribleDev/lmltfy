using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmltfy.Factories
{
    public class UrlGeneration
    {
        public string Generate()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }
    }
}