using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_PC_1.Audio
{
    class AmplitudeDataParseException : Exception
    {
        public AmplitudeDataParseException()
        {
        }

        public AmplitudeDataParseException(string message)
            : base(message)
        {
        }

        public AmplitudeDataParseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
