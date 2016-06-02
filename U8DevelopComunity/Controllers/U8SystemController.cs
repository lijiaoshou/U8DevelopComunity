using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U8.Framework.Web;
using U8.Framework.Web.Mvc;
using U8DevelopComunity.Common;

namespace U8DevelopComunity.Controllers
{
    public class U8SystemController : Controller
    {
        // GET: U8System
        public ActionResult Index()
        {
            return CommonViewHandle();
        }

        public ActionResult Register()
        {
            return CommonViewHandle();
        }

        public ActionResult ForgotPassword()
        {
            return CommonViewHandle();
        }

        public ActionResult CommonViewHandle()
        {
            if (Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "U8Question");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login()
        {
            string validateCode = Session["code_login"] == null ? string.Empty : Session["code_login"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!!");
            }
            Session["code_login"] = null;
            string txtCode = Request["vCode_Login"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            bool autoLogin = string.IsNullOrEmpty(Request["AutoLogin"])?false:true;

            Business.U8User user = new Business.U8User();
            Entity.U8User userInfo = user.GetUserInfo(Common.Config.ConnectionString,userName,userPwd);
            if (userInfo != null)
            {
                //Nginx

                //改成初始化identity的
                //IniIdentity(userInfo);

                //写入缓存
                string cacheName = "Identity_" + userInfo.UserEmail;
                if (autoLogin)
                {
                    Identity.AutoLogin = true;
                    Common.Cache.Instance.Add(cacheName, userInfo, 3600 * 24 * 7);
                }
                else
                {
                    Identity.AutoLogin = false;
                    Common.Cache.Instance.Add(cacheName, userInfo, 3600);
                }

                //写cookie,登录
                Entity.U8User cookieUser = new Entity.U8User() { RealName = userInfo.RealName.ToString(), UserEmail = userInfo.UserEmail };
                Identity.Login(cookieUser, autoLogin);
               

                //记录登陆日志
                //LoginLog(sysUser);
                //更新用户登录时间
                //EC_User_UserInfoService.UpdateByUserID(Config.ConnectionString_channelsales_Writer, sysUser, "Login");

                return Content("ok:登录成功");
            }
            else
            {
                return Content("no:登录失败!!");
            }
        }

        public ActionResult Logout()
        {
            //清空Identity.User缓存
            Common.Cache.Instance.Reset();
            foreach (string key in System.Web.HttpContext.Current.Request.Cookies.AllKeys)
            {
                System.Web.HttpContext.Current.Response.Cookies.Clear();
                //System.Web.HttpContext.Current.Response.Cookies[key].Domain = Common.Config.CookieDomain;
                //System.Web.HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
            }

            return RedirectToAction("Index", "U8System");
        }
        
        [HttpPost]
        public ActionResult Regist()
        {
            //vCode_Regist
            string validateCode = Session["code_regist"] == null ? string.Empty : Session["code_regist"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no;验证码错误!!");
            }
            Session["code_regist"] = null;
            string txtCode = Request["vCode_Regist"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no;验证码错误!!");
            }

            Entity.U8User userInfo = new Entity.U8User();
            userInfo.City = Request["userCity"];
            userInfo.Company = Request["userCompany"];
            userInfo.Gender = Request["userGender"];
            userInfo.Password = Request["userPassword"];
            userInfo.Phone = Request["userPhone"];
            userInfo.Province = Request["userProvince"];
            userInfo.UserEmail = Request["userEmail"];
            userInfo.IsYonyouEmployee =IsInternalUser(userInfo.UserEmail);
            string confirmPassword = Request["userConfirmPassword"];

            #region 验证各输入项不可为空
            if(!infoNotNullOrEmpty(userInfo))
            {
                return Content("no;有必填内容没有填写！");
             }
            #endregion

            #region 验证两次输入的密码必须相同
            if (userInfo.Password != confirmPassword)
            {
                return Content("no;两次输入的密码必须一致");
            }
            #endregion

            Business.U8User user = new Business.U8User();
            bool registResult= user.RegistUser(Common.Config.ConnectionString,userInfo);
            if (registResult)
            {
                return Content("ok;注册成功");
            }
            else
            {
                return Content("no;注册失败!!");
            }
        }

        [HttpPost]
        public ActionResult ForgotPassword(string userEmail)
        {
            string validateCode = Session["code_forgotpassword"] == null ? string.Empty : Session["code_forgotpassword"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!!");
            }
            Session["code_forgotpassword"] = null;
            string txtCode = Request["vCode_ForgotPassword"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }

            if (string.IsNullOrEmpty(userEmail))
            {
                return Content("no:邮箱不可为空!!");
            }

            Business.U8User user = new Business.U8User();
            bool Result = user.SendEmail(Common.Config.ConnectionString, userEmail);
            if (Result)
            {
                //重置密码后，清空缓存，cookie立即过期，在前端控制直接跳转到登录界面重新登录
                string cacheName = "Identity_" + userEmail;
                Common.Cache.Instance.Remove(cacheName);

                System.Web.HttpContext.Current.Response.Cookies.Clear();
                //System.Web.HttpContext.Current.Response.Cookies[Common.Config.LoginName].Expires = DateTime.Now.AddDays(-1);
                //System.Web.HttpContext.Current.Response.Cookies[Common.Config.UserID].Expires = DateTime.Now.AddDays(-1);

                return Content("ok:重置密码已发送到您的邮箱，请注意查收！");
            }
            else
            {
                return Content("no:重置密码失败!!");
            }
        }

        /// <summary>
        /// 返回登录验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        public ActionResult ShowLoginValidateCode()
        {
            byte[] buffer = GetImageBuffer("code_login");
            return File(buffer, "image/jpeg");
        }

        /// <summary>
        /// 返回注册验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        public ActionResult ShowRegistValidateCode()
        {
            byte[] buffer = GetImageBuffer("code_regist");
            return File(buffer, "image/jpeg");
        }

        /// <summary>
        /// 返回忘记密码验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        public ActionResult ShowForgotPasswordValidateCode()
        {
            byte[] buffer = GetImageBuffer("code_forgotpassword");
            return File(buffer, "image/jpeg");
        }

        /// <summary>
        /// 获取图片字节数组
        /// </summary>
        /// <param name="sessionName">session的key值</param>
        /// <returns></returns>
        public byte[] GetImageBuffer(string sessionName)
        {
            U8Common.ValidateCode validateCode = new U8Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);//获取验证码.
            Session[sessionName] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return buffer;
        }

        /// <summary>
        /// 初始化全局identity
        /// </summary>
        /// <param name="user">用户实体</param>
        public void IniIdentity(Entity.U8User user)
        {
            Identity userInfo = new Identity();
            userInfo.City = user.City;
            userInfo.Company = user.Company;
            userInfo.Gender = user.Gender;
            userInfo.IsYonyouEmployee = user.IsYonyouEmployee;
            userInfo.Phone = user.Phone;
            userInfo.Province = user.Province;
            userInfo.Role = user.Role;
            userInfo.UserEmail = user.UserEmail;
            userInfo.CreateTime = user.CreateTime;
            userInfo.UpdateTime = user.UpdateTime;
            userInfo.LastLoginTime = user.LastLoginTime;
            userInfo.RealName = user.RealName;
            userInfo.IsDelete = user.IsDelete;

            Identity.User = userInfo;
        }

        /// <summary>
        /// 通过对用户邮箱的分析，判断是否是公司内部用户
        /// </summary>
        /// <param name="userEmail"></param>
        public bool IsInternalUser(string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                return false;
            }
            string[] emailArray = userEmail.Split('@');
            if (emailArray[1].ToLower() == "yonyou.com")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断用户信息的所有字段是否均是非空
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        public bool infoNotNullOrEmpty(Entity.U8User user)
        {
            if (string.IsNullOrEmpty(user.City) || string.IsNullOrEmpty(user.Company) || string.IsNullOrEmpty(user.Gender) || string.IsNullOrEmpty(user.Password)
                || string.IsNullOrEmpty(user.Phone) || string.IsNullOrEmpty(user.Province) || string.IsNullOrEmpty(user.UserEmail)
                || user.Province=="选择省"||user.City=="选择市"||user.Gender=="选择性别")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ActionResult GetNoticeCount()
        {
            var actionResult = default(ContentResult);
            Identity identity = Identity.User;
            string userid = identity.UserId;
            Business.U8User u8user = new Business.U8User();
            
            int noticeCount= u8user.GetNoticeCount(Common.Config.ConnectionString, userid);

            actionResult = new U8JsonResult()
            {
                Content = U8Json.ToJson(new
                {
                    Message = "Success",
                    Content = noticeCount
                })
            };

            return actionResult;
        }

        /// <summary>
        /// 通知页
        /// </summary>
        /// <returns></returns>
        public ActionResult Notification()
        {
            //清空数据库中该账户的通知数量
            Identity identity = Identity.User;
            Business.U8User u8user = new Business.U8User();
            bool clearResut = u8user.ClearNoticeCount(Common.Config.ConnectionString,identity.UserId);

            //查出关于该通知消息的实体
            List<Entity.U8NoticeLog> listNoticeLog = u8user.GetNoticeLog(Common.Config.ConnectionString, identity.UserId);

            //跳转到通知页
            return View(listNoticeLog);
        }

        /// <summary>
        /// 个人主页
        /// </summary>
        /// <returns></returns>
        public ActionResult PersonalPage()
        {
            ViewBag.userid = Request.QueryString["userid"];
            return View();
        }

        public ActionResult SystemAnnounce()
        {
            return View();
        }
    }
}