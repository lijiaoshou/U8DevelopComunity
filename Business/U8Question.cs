using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Da = DataAccess;

namespace Business
{
    public class U8Question
    {
        //提交问题
        public bool SubmitQuestion(string databaseConnectionString, Entity.U8Question question)
        {
            return Da.U8Question.SubmitQuestion(databaseConnectionString,question);
        }

        //将问题设为知识库内容
        public bool PutQuestionIntoKnowledgeLib(string id)
        {
            return Da.U8Question.PutQuestionIntoKnowledgeLib(id);
        }

        //回答问题
        public bool AnswerQuestion(int id, string content)
        {
            return Da.U8Question.AnswerQuestion(id,content);
        }

        //将答案设置为满意答案
        public bool SetAnswerTobeBest(int questionId,int answerId)
        {
            return Da.U8Question.SetAnswerTobeBest(questionId,answerId);
        }

        //修改问题
        public bool AlterQuestion(Entity.U8Question question)
        {
            return Da.U8Question.AlterQuestion(question);
        }

        //删除问题
        public bool DeleteQuestion(int id)
        {
            return Da.U8Question.DeleteQuestion(id);
        }

        //删除某条回复
        public bool DeleteAnAnswer(int questionID, int answerID)
        {
            return Da.U8Question.DeleteAnAnswer(questionID,answerID);
        }

        //修改回复
        public bool AlterAnAnswer(int questionID, int answerID)
        {
            return Da.U8Question.AlterAnAnswer(questionID, answerID);
        }

        //查找出U8产品的版本列表
        public List<Entity.U8ProductEnum> GetU8ProductEnum(string databaseConnectionString)
        {
            return Da.U8Question.GetU8ProductEnum(databaseConnectionString);
        }

        //查出所有专家
        public List<Entity.U8User> GetExpert(string databaseConnectionString)
        {
            return Da.U8Question.GetExpert(databaseConnectionString);
        }

        //查出父级分类
        public List<Entity.U8Category> GetCategroy(string databaseConnectionString)
        {
            return Da.U8Question.GetCategory(databaseConnectionString);
        }

        //查出子级分类
        public List<Entity.U8SonCategory> GetSonCategory(string databaseConnectionString,string categoryid)
        {
            return Da.U8Question.GetSonCategory(databaseConnectionString,categoryid);
        }

        //查出所有问题列表
        public List<Entity.U8Question> SearchQuestionList(string databaseConnectionString, int currentPage, int pageSize,string questionCategory,string knowledgeCategory,string userid, out int allCount)
        {
            return Da.U8Question.SearchQuestionList(databaseConnectionString, currentPage, pageSize, questionCategory, knowledgeCategory, userid, out allCount);
        }

        //查询某个问题的详细信息
        public Entity.U8Question QuestionDetails(string databaseConnectionString, string id)
        {
            return Da.U8Question.QuestionDetails(databaseConnectionString,id);
        }

        //增加某个问题的人气
        public bool IncreasePopularity(string databaseConnectionString, string id)
        {
            return Da.U8Question.IncreasePopularity(databaseConnectionString,id);
        }
    }
}
