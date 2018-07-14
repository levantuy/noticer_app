using Noticer.Api.Filters;
using Noticer.Api.Models;
using Noticer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Noticer.Api.Controllers
{
    public class NoticeController : BaseController
    {
        [JwtAuthentication]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            NoticeColl notices = NoticeColl.GetNoticeColl();
            List<Noticer.Api.Models.Notice> result = new List<Models.Notice>();
            foreach (var item in notices)
            {
                result.Add(new Models.Notice
                {
                    NoticeId = item.NoticeId,
                    Content = item.Content,
                    LastModified = item.LastModefied.ToString("yyyy/MM/dd HH:ss"),
                    LastUser = item.LastUser,
                    Title = item.Title,
                    Url = item.Url
                });
            }

            return Ok(new
            {
                data = result,
                success = "true",
                message = "success"
            });
        }
    }
}