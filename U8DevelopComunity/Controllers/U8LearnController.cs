using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U8.Framework;
using U8.Framework.Web;
using U8.Framework.Web.Mvc;
using U8DevelopComunity.Common;
using U8DevelopComunity.Filters;

namespace U8DevelopComunity.Controllers
{
    [IdentityAuthorize]
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
            string category= U8Convert.TryToString(Request.Form["category"])=="0"?"": U8Convert.TryToString(Request.Form["category"]);
            string docSort= U8Convert.TryToString(Request.Form["docSort"]);

            Identity identity = Identity.User;
            string userid = identity.UserId;

            var actionResult = default(ContentResult);
            int allCount = 0;
            Business.U8Learn business = new Business.U8Learn();
            IList<Entity.U8Learn> list = business.SearchLearnList(Common.Config.ConnectionString, currentPage, pageSize, category, docSort, out allCount);

            if (list != null)
            {
                var rows = list.Select(e =>
                {
                    return new
                    {
                        XuHao = e.XuHao,
                        Id = e.Id,
                        TechDocCategory = "[" + e.TechDocCategory + "]",
                        DocName = "<a href='/U8Learn/DocDetails?id=" + e.Id + "' > " + e.DocName + " </ a > ",
                        Author = e.Author,
                        DownloadCount = e.DownloadCount,
                        ReadCount = e.ReadCount,
                        CreateTime = e.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")
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
            else
            {
                actionResult = new U8JsonResult()
                {
                    Content = U8Json.ToJson(new
                    {
                        Message = "Success",
                        Total = 0
                    })
                };
            }
            return actionResult;
        }

        public ActionResult UploadDocsIndex()
        {
            Business.U8Learn business = new Business.U8Learn();
            ViewBag.U8TechDocCategory = business.GetCategroy(Common.Config.ConnectionString);

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UploadDocs(Entity.U8Learn u8learn)
        {
            string result = "";
            Identity user = Identity.User;

            u8learn.Author = user.UserId;
            u8learn.CreateTime = DateTime.Now;

            if (string.IsNullOrEmpty(u8learn.DocName))
            {
                return new U8JsonResult()
                {
                    Content = U8Json.ToJson(new { Message = "标题不可为空" })
                };
            }
            if (string.IsNullOrEmpty(u8learn.Summary))
            {
                return new U8JsonResult()
                {
                    Content = U8Json.ToJson(new { Message = "摘要不可为空" })
                };
            }
            if (string.IsNullOrEmpty(u8learn.DocPath))
            {
                return new U8JsonResult()
                {
                    Content = U8Json.ToJson(new { Message = "附件不可为空" })
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

        public ActionResult DocDetails(string id)
        {
            Identity identity = Identity.User;
            Entity.U8Learn u8learn = new Entity.U8Learn();
            Business.U8Learn business = new Business.U8Learn();
            u8learn = business.DocDetails(Common.Config.ConnectionString, id);
            bool incResult = business.IncreaseReadCount(Common.Config.ConnectionString, id,identity.UserId);

            //获取访客
            ViewBag.DocVisitHistory = business.GetVisitHistory(Common.Config.ConnectionString, id);
            //获取所有评论
            ViewBag.DocCommentTable = business.GetComments(Common.Config.ConnectionString, id);

            return View(u8learn);
        }

        public ActionResult IncDownloadCount(string Id)
        {
            string result = "";

            Business.U8Learn business = new Business.U8Learn();
            bool incResult = business.IncDownloadCount(Common.Config.ConnectionString, Id);

            if (incResult)
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

        public ActionResult SubmitComment(Entity.U8DocComment u8DocComment)
        {
            string result = "";
            Identity identity = Identity.User;
            u8DocComment.User = identity.UserId;
            u8DocComment.CommentTime = DateTime.Now;

            Business.U8Learn business = new Business.U8Learn();
            bool incResult = business.SubmitComment(Common.Config.ConnectionString,u8DocComment);

            if (incResult)
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