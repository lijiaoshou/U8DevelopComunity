using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Da = DataAccess;

namespace Business
{
    public class U8Learn
    {
        public List<Entity.U8Learn> SearchLearnList(string databaseConnectionString, int currentPage, int pageSize, string category,string docSort, out int allCount)
        {
            return Da.U8Learn.SearchLearnList(databaseConnectionString, currentPage, pageSize, category, docSort, out allCount);
        }

        public List<Entity.U8TechDocCategory> GetCategroy(string databaseConnectionString)
        {
            return Da.U8Learn.GetCategroy(databaseConnectionString);
        }

        public bool UploadDocs(string databaseConnectionString, Entity.U8Learn u8learn)
        {
            return Da.U8Learn.UploadDocs(databaseConnectionString, u8learn);
        }

        public Entity.U8Learn DocDetails(string databaseConnectionString, string id)
        {
            return Da.U8Learn.DocDetails(databaseConnectionString, id);
        }

        public bool IncreaseReadCount(string databaseConnectionString, string id,string userid)
        {
            return Da.U8Learn.IncreaseReadCount(databaseConnectionString,id,userid);
        }

        public bool IncDownloadCount(string databaseConnectionString, string id)
        {
            return Da.U8Learn.IncDownloadCount(databaseConnectionString, id);
        }

        public bool SubmitComment(string databaseConnectionString, Entity.U8DocComment u8DocComment)
        {
            return Da.U8Learn.SubmitComment(databaseConnectionString,u8DocComment);
        }

        public List<Entity.U8DocVisitHistory> GetVisitHistory(string databaseConnectionString, string docId)
        {
            return Da.U8Learn.GetVisitHistory(databaseConnectionString,docId);
        }

        public List<Entity.U8DocComment> GetComments(string databaseConectionString, string docId)
        {
            return Da.U8Learn.GetComments(databaseConectionString, docId);
        }
    }
}
