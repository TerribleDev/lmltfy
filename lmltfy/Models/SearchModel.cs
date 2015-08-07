using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.Storage.Table;

namespace lmltfy.Models
{
    public class SearchModel : TableEntity
    {
        public const string ConsPartitionKey = @"SearchModel";
        public SearchModel()
        {
            PartitionKey = ConsPartitionKey;
        }
        [AllowHtml]
        [StringLength(2000, ErrorMessage = "No more than 2000 characters", MinimumLength = 1)]
        public string Search { get; set; }
        string url;

        [Key]
        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                RowKey = value;
                url = value;
            }
        }

        [Required]
        public string Brand { get; set; }

        public SearchModel fixKeys()
        {
            this.RowKey = this.url;
            this.PartitionKey = @"SearchModel";
            return this;
        }
    }
}