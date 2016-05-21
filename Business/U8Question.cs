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
        public bool SubmitQuestion(Entity.U8Question question)
        {
            return Da.U8Question.SubmitQuestion(question);
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

    }
}
