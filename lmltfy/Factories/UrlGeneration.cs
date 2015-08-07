using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmltfy.Factories
{
    public class UrlGeneration
    {
        static readonly List<string> EnumedChars = Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz0123456789", 8).ToList();
        public string Generate()
        {
            var random = new Random();
            return new string(
                EnumedChars
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }
    }
}