using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccess
{
    public class U8Question
    {
        //提交问题
        public static bool SubmitQuestion(Entity.U8Question question)
        {
            return true;
        }

        //将问题设为知识库内容
        public static bool PutQuestionIntoKnowledgeLib(string id)
        {
            return true;
        }

        //回答问题
        public static bool AnswerQuestion(int id,string content)
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
        public static bool DeleteAnAnswer(int questionID,int answerID)
        {
            return true;
        }

        //修改回复
        public static bool AlterAnAnswer(int questionID,int answerID)
        {
            return true;
        }
    }
}
