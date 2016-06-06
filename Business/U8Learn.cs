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
        public List<Entity.U8Learn> SearchLearnList(string databaseConnectionString, int currentPage, int pageSize, string category, out int allCount)
        {
            return Da.U8Learn.SearchLearnList(databaseConnectionString, currentPage, pageSize, category, out allCount);
        }

        public List<Entity.U8TechDocCategory> GetCategroy(string databaseConnectionString)
        {
            return Da.U8Learn.GetCategroy(databaseConnectionString);
        }

        public bool UploadDocs(string databaseConnectionString, Entity.U8Learn u8learn)
        {
            return Da.U8Learn.UploadDocs(databaseConnectionString, u8learn);
        }
    }
}
