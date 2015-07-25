using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lmltfy.Models
{
    public class SearchModel
    {
        [AllowHtml]
        [StringLength(maximumLength: 2000, ErrorMessage = "No more than 2000 characters", MinimumLength = 1)]
        public string Search { get; set; }
        [Key]
        public string Url { get; set; }
    }
}