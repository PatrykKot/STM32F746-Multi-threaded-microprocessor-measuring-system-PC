using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_PC_1.StmConn
{
    class StmConnectedException : Exception
    {
        public StmConnectedException()
        {
        }

        public StmConnectedException(string message)
            : base(message)
        {
        }

        public StmConnectedException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
