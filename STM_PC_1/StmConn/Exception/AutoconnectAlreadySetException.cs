using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_PC_1.StmConn
{
    class AutoconnectAlreadySetException: Exception
    {
        public AutoconnectAlreadySetException()
        {
        }

        public AutoconnectAlreadySetException(string message)
            : base(message)
        {
        }

        public AutoconnectAlreadySetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
