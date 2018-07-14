﻿using Noticer.Api.Filters;
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
            return Ok(new
            {
                success = "true",
                message = "success"
            });
        }

        [JwtAuthentication]
        [System.Web.Http.HttpDelete]
        //public IHttpActionResult Add(Int64 noticeId, string title, string content, string url)
        public IHttpActionResult Delete(Int64 noticeId)
        {
            try
            {
                Business.Notice.DeleteNotice(noticeId);
                return Ok(new
                {
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
    }
}