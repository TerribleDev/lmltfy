using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lmltfy.Models;

namespace lmltfy.Factories
{
    public class ApplicationBrandingFactory
    {
        public ApplicationBrandingModel ResoleBrand(ApplicationBrandEnum application)
        {

            if (application == ApplicationBrandEnum.Ask)
            {
                return new ApplicationBrandingModel { LogoImageUrl = "/Images/ask.png", Brand = application, LogoImageAlt= "Ask Jeeves" };
            }
            if (application == ApplicationBrandEnum.Lycos)
            {
                return new ApplicationBrandingModel {LogoImageUrl = "/Images/logo-homepage.png", Brand = application, LogoImageAlt = "Lycos" };
            }
            if(application == ApplicationBrandEnum.DuckDuckGo)
            {
                return new ApplicationBrandingModel { LogoImageUrl = "/Images/ddgo.png", Brand = application, LogoImageAlt = "Duck Duck go" };
            }
            throw new NotImplementedException();
        }
    }
}