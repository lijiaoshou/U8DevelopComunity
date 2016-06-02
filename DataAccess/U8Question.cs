using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using U8.Framework.Data;
using U8.Framework;
using System.Data.SqlClient;

namespace DataAccess
{
    public class U8Question
    {
        //提交问题
        public static bool SubmitQuestion(string databaseConnectionString, Entity.U8Question question)
        {
            string sqlQuestion = string.Format(@"INSERT INTO dbo.QuestionTable
                                        ( ProcessStatus ,
                                          Title ,
                                          Category ,
                                          Expert ,
                                          ProductBelong ,
                                          Provility ,
                                          ExpectFixTime ,
                                          SubmitTime ,
                                          Project ,
                                          QuestionContent ,
                                          OfferReward ,
                                          Popularity ,
                                          InKnowledgeLib ,
                                          SonCategory ,
                                          Submiter ,
                                          UpdateTime
                                        )
                                VALUES  ( 
                                          '{0}',
                                          '{1}',
                                          '{2}',
                                          '{3}',
                                          '{4}',
                                          '{5}',
                                          '{6}',
                                          '{7}',
                                          '{8}',
                                          '{9}',
                                          '{10}',
                                          '{11}',
                                          '{12}',
                                          '{13}',
                                          '{14}',
                                          '{15}'
                                        );", "0", question.Title, question.Category, question.Expert, question.ProductBelong, question.Provility, question.ExpectFixTime,
                                        DateTime.Now, question.Project, question.QuestionContent, question.OfferReward, "0", "0", question.SonCategory, question.Submiter, DateTime.Now);

            //提交问题的同时，向选择问题的相关专家发送通知（更新专家的通知数量+写通知日志）
            string sqlCount = string.Format(@"UPDATE dbo.UserTable SET noticecount=noticecount+1 WHERE id ='{0}';",question.Expert);
            string sqlNoticeLog = string.Format(@"
                                                DECLARE @indent BIGINT;
                                                select @indent=@@identity;
                                                INSERT INTO NoticeLog
                                                (Sender,Receiver,NoticeInfo,CreateTime,NoticeCategory,InfoId)
                                                VALUES
                                                ('{0}','{1}','{2}','{3}','{4}',@indent);
                                                ", question.Submiter,question.Expert,question.Title,DateTime.Now,"2");

            string sqlCollect = string.Format(Common.Tran, sqlQuestion+sqlCount+sqlNoticeLog);
            int i = U8.Framework.Data.U8Database.ExecuteNonQuery(databaseConnectionString, sqlCollect, null);
            return i > 0;
        }

        //将问题设为知识库内容
        public static bool PutQuestionIntoKnowledgeLib(string id)
        {
            return true;
        }

        //回答问题
        public static bool AnswerQuestion(int id, string content)
        {
            return true;
        }

        //将答案设置为满意答案
        public static bool SetAnswerTobeBest(int questionId, int answerId)
        {
            return true;
        }

        //修改问题
        public static bool AlterQuestion(Entity.U8Question question)
        {
            return true;
        }

        //删除问题
        public static bool DeleteQuestion(int id)
        {
            return true;
        }

        //删除某条回复
        public static bool DeleteAnAnswer(int questionID, int answerID)
        {
            return true;
        }

        //修改回复
        public static bool AlterAnAnswer(int questionID, int answerID)
        {
            return true;
        }

        //查找出U8产品的版本列表
        public static List<Entity.U8ProductEnum> GetU8ProductEnum(string databaseConnectionString)
        {
            List<Entity.U8ProductEnum> listProduct = new List<Entity.U8ProductEnum>();
            string sql = string.Format(@"select id,Name,CreateTime from ProductEnumTable");
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entity.U8ProductEnum product = new U8ProductEnum();
                    product.id = U8Convert.TryToInt32(dt.Rows[i]["id"]);
                    product.Name = U8Convert.TryToString(dt.Rows[i]["Name"]);
                    product.CreateTime = U8Convert.TryToDateTime(dt.Rows[i]["CreateTime"]);
                    listProduct.Add(product);
                }
                return listProduct;
            }
            else
            {
                return null;
            }

        }

        //查出所有专家
        public static List<Entity.U8User> GetExpert(string databaseConnectionString)
        {
            List<Entity.U8User> listExpert = new List<Entity.U8User>();
            string sql = string.Format(@"select id,RealName,Department from UserTable where role='1'");
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entity.U8User u8user = new Entity.U8User();
                    u8user.UserId = U8Convert.TryToString(dt.Rows[i]["id"]);
                    u8user.RealName = U8Convert.TryToString(dt.Rows[i]["RealName"]);
                    u8user.Department = U8Convert.TryToString(dt.Rows[i]["Department"]);
                    listExpert.Add(u8user);
                }
                return listExpert;
            }
            else
            {
                return null;
            }
        }

        //查出父级分类
        public static List<Entity.U8Category> GetCategory(string databaseConnectionString)
        {
            List<Entity.U8Category> listCategory = new List<U8Category>();
            string sql = string.Format(@"SELECT id,CategoryName FROM dbo.CategoryTable");
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entity.U8Category u8category = new Entity.U8Category();
                    u8category.id = U8Convert.TryToInt32(dt.Rows[i]["id"]);
                    u8category.CategoryName = U8Convert.TryToString(dt.Rows[i]["CategoryName"]);

                    listCategory.Add(u8category);
                }
                return listCategory;
            }
            else
            {
                return null;
            }
        }

        //查出子级分类
        public static List<Entity.U8SonCategory> GetSonCategory(string databaseConnectionString,string categoryid)
        {
            List<Entity.U8SonCategory> listSonCategory = new List<U8SonCategory>();
            string sql = string.Format(@"SELECT id,SonCategoryName FROM dbo.SonCategoryTable where CategoryBelong='{0}'", categoryid);
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entity.U8SonCategory u8soncategory = new Entity.U8SonCategory();
                    u8soncategory.id = U8Convert.TryToInt32(dt.Rows[i]["id"]);
                    u8soncategory.SonCategoryName = U8Convert.TryToString(dt.Rows[i]["SonCategoryName"]);

                    listSonCategory.Add(u8soncategory);
                }
                return listSonCategory;
            }
            else
            {
                return null;
            }
        }

        //查找所有问题列表
        public static List<Entity.U8Question> SearchQuestionList(string databaseConnectionString, int currentPage, int pageSize,string questionCategory,string knowledgeCategory,string userid, out int allCount)
        {
            allCount = 0;
            IList<SqlParameter> parameters = new List<SqlParameter>();

            string sql = @"
                            with Virtual_T as (
                            SELECT Row_number() OVER(order by t.SubmitTime desc) AS RowNumber,t.*  FROM
                            (
	                            SELECT question.id,
	                            process.Content as ProcessStatus,question.Title,category.CategoryName,usertableExp.RealName as Expert,product.name,question.Provility,
	                            question.ExpectFixTime,question.SubmitTime,question.Project,question.QuestionContent,question.OfferReward,question.Popularity,
	                            question.InKnowledgeLib,soncategory.SonCategoryName as SonCategory,usertableSub.RealName AS Submiter,question.UpdateTime,usertableMod.RealName AS Modifiler FROM dbo.QuestionTable as question 
	                            LEFT JOIN dbo.CategoryTable category ON question.Category=category.id
	                            LEFT JOIN dbo.SonCategoryTable soncategory ON question.SonCategory=soncategory.id
	                            LEFT JOIN dbo.UserTable usertableSub ON question.Submiter=usertableSub.id
	                            LEFT JOIN dbo.UserTable usertableExp ON question.Expert=usertableExp.id
	                            LEFT JOIN dbo.UserTable usertableMod ON question.Modifiler=usertableMod.id
	                            LEFT JOIN dbo.ProductEnumTable product ON question.ProductBelong=product.id
	                            LEFT JOIN dbo.ProcessStatusTable process ON question.ProcessStatus=process.id
                                where 1=1 {0}
                            )AS t)
                            SELECT * FROM Virtual_T 
                            WHERE @PageSize * (@CurrentPage - 1) < RowNumber AND RowNumber <= @PageSize * @CurrentPage ORDER BY RowNumber
                          ";

            #region //where
            string where1 = " ";
            string where2 = "";
            parameters.Add(new SqlParameter() { ParameterName = "@CurrentPage", Value = currentPage });
            parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = pageSize });
            if (questionCategory == "3")
            {
                where1 = "  and question.expert='"+userid+"'";
            }
            else if (questionCategory == "2")
            {
                where1 = "  and question.InKnowledgeLib='1'";
            }
            else if (questionCategory == "1")
            {
                where1 = "  and question.Submiter='" + userid + "'";
            }
            if (questionCategory == "2")
            {
                sql.Replace("t.SubmitTime desc", "t.Popularity desc");
            }
            where2 = where1.Replace("question.", "");
            #endregion

            IList<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters.ToList().ForEach((p) => { parameters2.Add(new SqlParameter(p.ParameterName, p.Value)); });
            allCount = U8Convert.TryToInt32(U8Database.ExecuteScalar(
                databaseConnectionString
                , @" SELECT COUNT(1) FROM dbo.QuestionTable where 1=1 " + where2  //select count (*) from MallReturnMoney_Batch as a with(nolock) where 1=1
                , parameters2.ToArray()));
            if (allCount == 0) { return null; }

            DataTable dt = new DataTable();
            U8Database.Fill(
                databaseConnectionString,
                String.Format(sql, where1),
                dt,
                parameters.ToArray());//查出列表

            if (dt.Rows.Count > 0)
            {
                return dt.AsEnumerable().Select(row => new Entity.U8Question()
                {
                    XuHao = U8Convert.TryToInt32(row["RowNumber"]),
                    ID = U8Convert.TryToInt32(row["ID"]),
                    Title = U8Convert.TryToString(row["Title"]),
                    SonCategory = row["SonCategory"].ToString(),
                    Popularity = U8Convert.TryToInt32(row["Popularity"]),
                    Expert = row["Expert"].ToString(),
                    ProcessStatus = U8Convert.TryToString(row["ProcessStatus"]) == "未解决" ? "<span style='color:red;'>("+ U8Convert.TryToString(row["ProcessStatus"]) + ")</span>" : "<span>(" + U8Convert.TryToString(row["ProcessStatus"]) + ")</span>"
                }).ToList();
            }
            else
            {
                return null;
            }
        }

        //查找某个问题的详细信息
        public static Entity.U8Question QuestionDetails(string databaseConnectionString, string id)
        {
            string sql = string.Format(@"SELECT question.id,
                                        process.Content as ProcessStatus,question.Title,category.CategoryName,usertableExp.RealName as Expert,product.name AS ProductBelong,question.Provility,
                                        question.ExpectFixTime,question.SubmitTime,question.Project,question.QuestionContent,question.OfferReward,question.Popularity,
                                        question.InKnowledgeLib,soncategory.SonCategoryName as SonCategory,usertableSub.RealName AS Submiter,question.UpdateTime,usertableMod.RealName AS Modifiler FROM dbo.QuestionTable as question 
                                        LEFT JOIN dbo.CategoryTable category ON question.Category=category.id
                                        LEFT JOIN dbo.SonCategoryTable soncategory ON question.SonCategory=soncategory.id
                                        LEFT JOIN dbo.UserTable usertableSub ON question.Submiter=usertableSub.id
                                        LEFT JOIN dbo.UserTable usertableExp ON question.Expert=usertableExp.id
                                        LEFT JOIN dbo.UserTable usertableMod ON question.Modifiler=usertableMod.id
                                        LEFT JOIN dbo.ProductEnumTable product ON question.ProductBelong=product.id
                                        LEFT JOIN dbo.ProcessStatusTable process ON question.ProcessStatus=process.id
                                        WHERE question.id='{0}'", id);
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            Entity.U8Question u8question = new Entity.U8Question();
            if (dt != null && dt.Rows.Count > 0)
            {
                u8question.ID = U8Convert.TryToInt32(dt.Rows[0]["id"]);
                u8question.ProcessStatus = U8Convert.TryToString(dt.Rows[0]["ProcessStatus"]);
                u8question.Title = U8Convert.TryToString(dt.Rows[0]["Title"]);
                u8question.Category = U8Convert.TryToString(dt.Rows[0]["CategoryName"]);
                u8question.Expert = U8Convert.TryToString(dt.Rows[0]["Expert"]);
                u8question.ProductBelong = U8Convert.TryToString(dt.Rows[0]["ProductBelong"]);
                u8question.Provility = U8Convert.TryToString(dt.Rows[0]["Provility"]);
                u8question.ExpectFixTime = U8Convert.TryToDateTime(dt.Rows[0]["ExpectFixTime"]);
                u8question.SubmitTime = U8Convert.TryToDateTime(dt.Rows[0]["SubmitTime"]);
                u8question.Project = U8Convert.TryToString(dt.Rows[0]["Project"]);
                u8question.QuestionContent = U8Convert.TryToString(dt.Rows[0]["QuestionContent"]);
                u8question.OfferReward = U8Convert.TryToInt32(dt.Rows[0]["OfferReward"]);
                u8question.Popularity = U8Convert.TryToInt32(dt.Rows[0]["Popularity"]);
                u8question.InKnowledgeLib = U8Convert.TryToInt32(dt.Rows[0]["InKnowledgeLib"])==0?false:true;
                u8question.SonCategory = U8Convert.TryToString(dt.Rows[0]["SonCategory"]);
                u8question.Submiter = U8Convert.TryToString(dt.Rows[0]["Submiter"]);
                u8question.UpdateTime = U8Convert.TryToDateTime(dt.Rows[0]["UpdateTime"]);
                u8question.Modifiler = U8Convert.TryToString(dt.Rows[0]["Modifiler"]);
            }

            return u8question;
        }

        //增加问题人气
        public static bool IncreasePopularity(string databaseConnectionString, string id)
        {
            string sql = string.Format(@"UPDATE dbo.QuestionTable SET Popularity=Popularity+1 WHERE id='{0}';",id);
            return U8Database.ExecuteNonQuery(databaseConnectionString, sql, null)>0;
        }
    }
}
