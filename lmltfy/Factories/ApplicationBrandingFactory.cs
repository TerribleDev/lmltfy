using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lmltfy.Models;

namespace lmltfy.Factories
{
    public class ApplicationBrandingFactory
    {
        public ApplicationBrandingModel ResoleBrand(string application)
        {
            //this was less terrible when it was an enum...figure out a better way.
            // we had to switch away from enum b.c. its not supported by azure table storage without some really bad hacks
            if (application.Equals(ApplicationBrand.Ask))
            {
                return new ApplicationBrandingModel { LogoImageUrl = "/Images/ask.png", Brand = application, LogoImageAlt= "Ask Jeeves" };
            }
            if (application.Equals(ApplicationBrand.Lycos))
            {
                return new ApplicationBrandingModel {LogoImageUrl = "/Images/logo-homepage.png", Brand = application, LogoImageAlt = "Lycos" };
            }
            if(application.Equals(ApplicationBrand.DuckDuckGo))
            {
                return new ApplicationBrandingModel { LogoImageUrl = "/Images/ddgo.png", Brand = application, LogoImageAlt = "Duck Duck go" };
            }
            throw new NotImplementedException();
        }
    }
}