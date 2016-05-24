using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U8DevelopComunity.Common;

namespace U8DevelopComunity.Controllers
{
    public class U8SystemController : Controller
    {
        // GET: U8System
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
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

            Business.U8User user = new Business.U8User();
            Entity.U8User userInfo = user.GetUserInfo(userName,userPwd);
            if (userInfo != null)
            {
                //Nginx
                //Session["userInfo"] = userInfo;
                //改成初始化identity的
                IniIdentity(userInfo);

                return Content("ok:登录成功");
            }
            else
            {
                return Content("no:登录失败!!");
            }
        }
        
        [HttpPost]
        public ActionResult Regist()
        {
            //vCode_Regist
            string validateCode = Session["code_regist"] == null ? string.Empty : Session["code_regist"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!!");
            }
            Session["code_regist"] = null;
            string txtCode = Request["vCode_Regist"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }

            Entity.U8User userInfo = new Entity.U8User();
            userInfo.City = Request["userCity"];
            userInfo.Company = Request["userCompany"];
            userInfo.Gender = Request["userGender"];
            userInfo.Password = Request["userPassword"];
            userInfo.Phone = Request["userPhone"];
            userInfo.Province = Request["userProvince"];
            userInfo.Role = Request["userRole"];
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
                return Content("ok:注册成功");
            }
            else
            {
                return Content("no:注册失败!!");
            }
        }

        [HttpPost]
        public ActionResult ForgotPassword(string userEmail)
        {
            //vCode_ForgotPassword

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

            //string UserEmail = Request["userEmail"];
            if (string.IsNullOrEmpty(userEmail))
            {
                return Content("no:邮箱不可为空!!");
            }

            Business.U8User user = new Business.U8User();
            bool Result = user.SendEmailToAdmin(userEmail);
            if (Result)
            {
                return Content("ok:已通知管理员修改密码，稍后密码会发送到您填写的邮箱中！");
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
            Identity.City = user.City;
            Identity.Company = user.Company;
            Identity.Gender = user.Gender;
            Identity.IsYonyouEmployee = user.IsYonyouEmployee;
            Identity.Password = user.Password;
            Identity.Phone = user.Phone;
            Identity.Province = user.Province;
            Identity.Role = user.Role;
            Identity.UserEmail = user.UserEmail;
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
                || string.IsNullOrEmpty(user.Phone) || string.IsNullOrEmpty(user.Province) || string.IsNullOrEmpty(user.Role) || string.IsNullOrEmpty(user.UserEmail)
                || user.Province=="选择省"||user.City=="选择市"||user.Gender=="选择性别")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}