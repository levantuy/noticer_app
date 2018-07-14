using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noticer.Api.Models
{
    public class Notice
    {
        public Int64 NoticeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public int LastUser { get; set; }
        public string LastModified { get; set; }
    }
}