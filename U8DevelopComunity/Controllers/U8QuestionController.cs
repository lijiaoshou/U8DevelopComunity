using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace U8DevelopComunity.Controllers
{
    public class U8QuestionController : Controller
    {
        // GET: U8Question
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 提交新的问题
        /// </summary>
        /// <param name="question">问题实体</param>
        /// <returns></returns>
        public ActionResult AddNewQuestion(U8Question question)
        {
            return View();
        }
    }
}