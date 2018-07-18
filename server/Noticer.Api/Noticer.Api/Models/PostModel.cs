using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noticer.Api.Models
{
    public class PostModel
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string authorName { get; set; }
        public string authorUsername { get; set; }
        public string authorId { get; set; }
        public List<string> categories { get; set; }
    }
}