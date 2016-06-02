using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U8DevelopComunity.Common;
using U8.Framework.Web.Mvc;
using U8.Framework.Web;
using U8.Framework;

namespace U8DevelopComunity.Controllers
{
    public class U8QuestionController : Controller
    {
        // GET: U8Question
        public ActionResult Index()
        {
            ViewBag.questionCategory = Request.QueryString["questionCategory"];
            ViewBag.knowledgeCategory = Request.QueryString["knowledgeCategory"];
            if (Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "U8System");    
            }
        }

        [HttpPost]
        public ActionResult SearchQuestionList()
        {
            int currentPage = U8Convert.TryToInt32(Request.Form["currentPage"]);
            int pageSize = U8Convert.TryToInt32(Request.Form["pageSize"]);
            string questionCategory = U8Convert.TryToString(Request.Form["questionCategory"]);
            string knowledgeCategory = U8Convert.TryToString(Request.Form["knowledgeCategory"]);
            Identity identity = Identity.User;
            string userid = identity.UserId;
            if (string.IsNullOrEmpty(questionCategory))
            {
                questionCategory = "4";
            }
            if (string.IsNullOrEmpty(knowledgeCategory))
            {
                knowledgeCategory = "3";
            }
            else
            {
                questionCategory = "2";
            }

            var actionResult = default(ContentResult);
            int allCount = 0;
            Business.U8Question business = new Business.U8Question();
            IList<Entity.U8Question> list = business.SearchQuestionList(Common.Config.ConnectionString, currentPage,pageSize,questionCategory, knowledgeCategory, userid, out allCount);

            if (list != null)
            {
                var rows = list.Select(e =>
                {
                    return new
                    {
                        XuHao = e.XuHao,
                        Id = e.ID,
                        Title = "<a href='/U8Question/QuestionDetails?id="+e.ID+"'>" + e.Title + "</a>",
                        SonCategoryName = "["+e.SonCategory+"]",
                        Popularity = e.Popularity,
                        ExpertName = e.Expert,
                        ProcessStatus=e.ProcessStatus
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

        [HttpPost]
        [ValidateInput(false)]
        /// <summary>
        /// 提交新的问题
        /// </summary>
        /// <param name="question">问题实体</param>
        /// <returns></returns>
        public ActionResult AddNewQuestion(U8Question question)
        {
            string result = "";
            string errorMsg = "";

            question.SubmitTime = DateTime.Now;
            Identity identity = Identity.User;
            question.Submiter = identity.UserId;

            bool verifyPassed = VerifyUserInput(question, out errorMsg);
            if (!verifyPassed)
            {
                return new U8JsonResult()
                {
                    Content = U8Json.ToJson(new { Message = errorMsg })
                };
            }

            Business.U8Question u8question = new Business.U8Question();
            bool submitResult = u8question.SubmitQuestion(Common.Config.ConnectionString,question);

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

        public bool VerifyUserInput(Entity.U8Question question,out string errorMsg)
        {
            if (string.IsNullOrEmpty(question.Title))
            {
                errorMsg = "请填写标题！";
                return false;
            }
            if (string.IsNullOrEmpty(question.Category))
            {
                errorMsg = "请选择分类！";
                return false;
            }
            if (string.IsNullOrEmpty(question.Expert))
            {
                errorMsg = "请选择专家！";
                return false;
            }
            if (string.IsNullOrEmpty(question.SonCategory))
            {
                errorMsg = "请选择所属产品！";
                return false;
            }
            if (string.IsNullOrEmpty(question.Provility))
            {
                errorMsg = "请选择优先级！";
                return false;
            }
            if (question.ExpectFixTime == null)
            {
                errorMsg = "请选择期望解决时间！";
                return false;
            }
            if (string.IsNullOrEmpty(question.Project))
            {
                errorMsg = "请填写项目！";
                return false;
            }
            if (string.IsNullOrEmpty(question.QuestionContent))
            {
                errorMsg = "请填写内容！";
                return false;
            }
            errorMsg = "";
            return true;
        }

        public ActionResult AddNewQuestion()
        {
            //界面加载时就查出专家，产品，并填充到界面上
            //对于分类和子分类，通过ajax来加载，有联动效果。
            Business.U8Question business = new Business.U8Question();
            ViewBag.U8ProductEnum = business.GetU8ProductEnum(Common.Config.ConnectionString);
            ViewBag.Expert = business.GetExpert(Common.Config.ConnectionString);
            ViewBag.U8Category = business.GetCategroy(Common.Config.ConnectionString);

            return View();
        }

        [HttpPost]
        public ActionResult GetSonCategory(string categoryid)
        {
            var actionResult = default(ContentResult);
            string sonCategoryStr = "";
            Business.U8Question business = new Business.U8Question();
            List<Entity.U8SonCategory> listSonCategories = new List<U8SonCategory>();
            listSonCategories = business.GetSonCategory(Common.Config.ConnectionString, categoryid);
            if (listSonCategories != null)
            {
                foreach (Entity.U8SonCategory sonCategory in listSonCategories)
                {
                    sonCategoryStr += "<option value='" + sonCategory.id + "'" + ">" + sonCategory.SonCategoryName + "</option>";
                }
            }
            else
            {

            }

            actionResult = new U8JsonResult()
            {
                Content = U8Json.ToJson(new
                {
                    Message = "Success",
                    Content = sonCategoryStr
                })
            };

            return actionResult;
        }

        public ActionResult QuestionDetails(string id)
        {
            Business.U8Question u8question = new Business.U8Question();
            Entity.U8Question question = u8question.QuestionDetails(Common.Config.ConnectionString,id);

            //每点击一次，给人气指数加一
            bool incResult = u8question.IncreasePopularity(Common.Config.ConnectionString,id);

            return View(question);
        }
    }
}