using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Common
    {
        public static readonly string Tran = @"BEGIN TRAN
	                                    BEGIN TRY
                                            {0}
	                                    END TRY
	                                    BEGIN CATCH
		                                    ROLLBACK
                                            RETURN
	                                    END CATCH
                                    COMMIT TRAN";
    }
}
