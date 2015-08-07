using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmltfy.Models
{
    public class SearchResultsViewModel
    {
        public SearchModel SearchModel { get; set; }
        public RedirectModel RedirectModel { get; set; }

        public IApplicationBrandingModel BrandingModel { get; set; }

        public SearchResultsViewModel(SearchModel searchModel, RedirectModel redirectModel, IApplicationBrandingModel brandingModel)
        {
            if (string.IsNullOrWhiteSpace(searchModel.Search))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrWhiteSpace(searchModel.Url))
            {
                throw new ArgumentNullException();
            }
            if (redirectModel == null)
            {
                throw new ArgumentNullException();
            }
            SearchModel = searchModel;
            RedirectModel = redirectModel;
            BrandingModel = brandingModel;
        }

    }
}