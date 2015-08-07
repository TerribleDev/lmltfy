using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmltfy.Models
{
    public class ApplicationBrandingModel   : IApplicationBrandingModel
    {
        public string LogoImageUrl { get; set; }

        public string LogoImageAlt { get; set; }

        public string Brand { get; set; }

        public IList<string> StyleSheetUrl { get; set; } = new List<string>();

        public IList<string> ScriptUrls { get; set; } = new List<string>();
    }
}