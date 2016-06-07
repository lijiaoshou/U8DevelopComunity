using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Da = DataAccess;

namespace Business
{
    public class U8System
    {
        public bool SubmitSystemNotice(string databaseConnectionString, Entity.U8SystemNotice u8systemNotice,string IsEdit)
        {
            return Da.U8System.SubmitSystemNotice(databaseConnectionString,u8systemNotice, IsEdit);
        }

        public Entity.U8SystemNotice GetSystemNoticeById(string databaseConnectionString, string id)
        {
            return Da.U8System.GetSystemNoticeById(databaseConnectionString,id);
        }

        public List<Entity.U8SystemNotice> GetSystemNoticeList(string databaseConnectionString, int currentPage, int pageSize, out int allCount)
        {
            return Da.U8System.GetSystemNoticeList(databaseConnectionString,currentPage,pageSize,out allCount);
        }

        public bool PublishNoticeFromDraft(string databaseConnectionString, string id,string userid)
        {
            return Da.U8System.PublishNoticeFromDraft(databaseConnectionString,id,userid);
        }

        public bool DeleteNoticeFromDraft(string databaseConnectionString,string id)
        {
            return Da.U8System.DeleteNoticeFromDraft(databaseConnectionString,id);
        }

        public bool HasAdminLimit(string databaseConnectionString, string userid)
        {
            return Da.U8System.HasAdminLimit(databaseConnectionString, userid);
        }
    }
}
