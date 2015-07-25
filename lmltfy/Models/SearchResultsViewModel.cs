using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmltfy.Models
{
    public class SearchResultsViewModel
    {
        public SearchModel SearchModel { get; set; }
        public string LycosToken { get; set; }
        public SearchResultsViewModel(SearchModel searchModel, string lycosToken)
        {
            if (string.IsNullOrWhiteSpace(searchModel.Search))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrWhiteSpace(searchModel.Url))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrWhiteSpace(lycosToken))
            {
                throw new ArgumentNullException();
            }
            SearchModel = searchModel;
            LycosToken = lycosToken;
        }
       
    }
}