using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ang_blog.Models
{
    public class BlogEntryModel
    {
        [JsonProperty(PropertyName="id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "IsApproved")]
        public bool IsApproved { get; set; }

        [JsonProperty(PropertyName = "ApprovedOn")]
        public DateTime ApprovedOn { get; set; }

    }
}