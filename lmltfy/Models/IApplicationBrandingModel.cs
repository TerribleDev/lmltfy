using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmltfy.Models
{
    public interface IApplicationBrandingModel
    {
        string LogoImageUrl { get; set; }

        string LogoImageAlt { get; set; }

        ApplicationBrandEnum Brand { get; set; }

        IList<string> StyleSheetUrl { get; set; }

        IList<string> ScriptUrls { get; set; }
    }
}