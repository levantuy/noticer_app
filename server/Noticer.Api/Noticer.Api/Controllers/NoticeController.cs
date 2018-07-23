using Noticer.Api.Filters;
using Noticer.Api.Models;
using Noticer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Noticer.Api.Controllers
{
    [System.Web.Http.RoutePrefix("api/Notice")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NoticeController : BaseController
    {
        [JwtAuthentication]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            try
            {
                NoticeColl notices = NoticeColl.GetNoticeColl();
                List<Noticer.Api.Models.NoticeModel> result = new List<Models.NoticeModel>();
                foreach (var item in notices)
                {
                    result.Add(new Models.NoticeModel
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
            catch(Exception ex)
            {
                return Ok(new
                {
                    data = ex.Message,
                    success = "false",
                    message = "false"
                });
            }            
        }

        [JwtAuthentication]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Search(string searchText)
        {
            NoticeColl notices = NoticeColl.GetNoticeColl(searchText == null ? string.Empty : searchText);
            List<Noticer.Api.Models.NoticeModel> result = new List<Models.NoticeModel>();
            foreach (var item in notices)
            {
                result.Add(new Models.NoticeModel
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

        [JwtAuthentication]
        [System.Web.Http.HttpPost]
        //public IHttpActionResult Add(Int64 noticeId, string title, string content, string url)
        public IHttpActionResult Add(NoticeModel model)
        {
            Notice obj;
            if (model.NoticeId > 0) {
                obj = Notice.GetNotice(model.NoticeId);
                obj.Title = model.Title;
                obj.Content = model.Content;
                obj.Url = model.Url;
                obj.LastUser = "admin";
            } 
            else
            {
                obj = Business.Notice.NewNotice();
                obj.NoticeId = model.NoticeId;
                obj.Title = model.Title;
                obj.Content = model.Content;
                obj.Url = model.Url;
                obj.LastUser = "admin";
            }
             
            obj.ApplyEdit();
            var temp = obj.Clone();
            obj = temp.Save();

            // reload list
            var notices = NoticeColl.GetNoticeColl();
            var result = new List<Models.NoticeModel>();
            foreach (var item in notices)
            {
                result.Add(new Models.NoticeModel
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
        
        [JwtAuthentication]
        [System.Web.Http.HttpDelete]
        //[System.Web.Http.RouteAttribute("api/Notice/Delete?id={id}")]
        public IHttpActionResult Delete(Int64 id)
        {
            try
            {
                Business.Notice.DeleteNotice(id);
                // reload list
                var notices = NoticeColl.GetNoticeColl();
                var result = new List<Models.NoticeModel>();
                foreach (var item in notices)
                {
                    result.Add(new Models.NoticeModel
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
            catch(Exception ex)
            {
                return Ok(new
                {
                    success = "false",
                    message = ex.Message
                });
            }            
        }

        [System.Web.Http.Route("~/api/Notice/GetPosts")]
        [JwtAuthentication]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetPosts()
        {
            try
            {
                var categories = new List<string>();
                categories.Add("abc");
                List<PostModel> posts = new List<PostModel>();
                posts.Add(new PostModel {
                    authorId = "a",
                    authorName = "john",
                    authorUsername = "john le",
                    categories = categories,
                    title = "title 1",
                    _id = "1"
                });

                return Ok(new
                {
                    data = posts,
                    success = "true",
                    message = "success"
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    data = ex.Message,
                    success = "false",
                    message = "false"
                });
            }
        }
    }
}