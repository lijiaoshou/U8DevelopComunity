using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U8.Framework;
using U8.Framework.Web;
using U8.Framework.Web.Mvc;
using U8DevelopComunity.Common;

namespace U8DevelopComunity.Controllers
{
    public class U8LearnController : Controller
    {
        // GET: U8Learn
        public ActionResult Index()
        {
            Business.U8Learn business = new Business.U8Learn();
            ViewBag.U8TechDocCategory = business.GetCategroy(Common.Config.ConnectionString);
            return View();
        }

        [HttpPost]
        public ActionResult SearchLearnList()
        {
            int currentPage = U8Convert.TryToInt32(Request.Form["currentPage"]);
            int pageSize = U8Convert.TryToInt32(Request.Form["pageSize"]);
            string category= U8Convert.TryToString(Request.Form["category"]);

            Identity identity = Identity.User;
            string userid = identity.UserId;

            var actionResult = default(ContentResult);
            int allCount = 0;
            Business.U8Learn business = new Business.U8Learn();
            IList<Entity.U8Learn> list = business.SearchLearnList(Common.Config.ConnectionString, currentPage, pageSize, category, out allCount);

            if (list != null)
            {
                var rows = list.Select(e =>
                {
                    return new
                    {
                        XuHao = e.XuHao,
                        Id = e.Id,
                        TechDocCategory = "[" + e.TechDocCategory + "]",
                        //"<a href='/U8Question/QuestionDetails?id=" + e.ID + "'>" + e.Title + "</a>",
                        DocName = "<a href='/U8Question/QuestionDetails?id=" + e.Id + "' > " + e.DocName + " </ a > ",
                        Author = e.Author,
                        DownloadCount = e.DownloadCount,
                        ReadCount = e.ReadCount,
                        CreateTime=e.CreateTime
                    };
                }).ToList();
                actionResult = new U8JsonResult()
                {
                    Content = U8Json.ToJson(new
                    {
                        Message = "Success",
                        Rows = rows,
                        Total = allCount
                    })
                };
            }
            return actionResult;
        }

        public ActionResult UploadDocs()
        {
            string result = "";
            Identity user = Identity.User;

            Entity.U8Learn u8learn = new Entity.U8Learn();
            u8learn.Author = user.UserId;
            u8learn.CreateTime = DateTime.Now;
            u8learn.DocName = Request.Form["Title"];
            u8learn.DocPath = Request.Form["DocPath"];
            u8learn.TechDocCategory = Request.Form["Category"];

            if (string.IsNullOrEmpty(u8learn.DocPath))
            {
                return new U8JsonResult()
                {
                    Content = U8Json.ToJson(new { Message = "标题不可为空" })
                };
            }

            Business.U8Learn business = new Business.U8Learn();
            bool submitResult = business.UploadDocs(Common.Config.ConnectionString, u8learn);

            if (submitResult)
            {
                result = Common.U8StandardMessage.Success;
            }
            else
            {
                result = Common.U8StandardMessage.Success;
            }
            return new U8JsonResult()
            {
                Content = U8Json.ToJson(new
                {
                    Message = result
                })
            };
        }
    }
}