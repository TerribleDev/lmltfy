using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using lmltfy.Models;

namespace lmltfy.Factories
{
    public class UrlResolverFactory
    {
        Regex lycosRegex = new Regex(@"(\$\('#keyvol'\).val\('(?<key>.*)\'\)\;)", RegexOptions.Compiled);

        /// <summary>
        /// Generates a url for a given application
        /// </summary>
        /// <param name="app"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public RedirectModel UrlGenerate(ApplicationBrandEnum app, string query)
        {
            if (app == ApplicationBrandEnum.Lycos)
            {
                return GenerateLycosUrl(query);
            }  
            if (app == ApplicationBrandEnum.Ask)
            {
                return new RedirectModel($"http://www.ask.com/web?q={query}");
            }
            if(app == ApplicationBrandEnum.DuckDuckGo)
            {
                return new RedirectModel($"https://duckduckgo.com/?q={query}");
            }

            throw new NotImplementedException("Unknown app passed");
        }

        public RedirectModel GenerateLycosUrl(string query)
        {
            using (WebClient client = new WebClient())
            {
                var downloadString = client.DownloadString("http://lycos.com");
                var key = lycosRegex.Match(downloadString).Groups["key"].Value;
                return new RedirectModel($"http://search.lycos.com/web/?q={query}", $"&keyvol={key}");
            }

        }
    }
}