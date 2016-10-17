using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_PC_1.Audio
{
    class NoAmplitudeDataException : Exception
    {
        public NoAmplitudeDataException()
        {
        }

        public NoAmplitudeDataException(string message)
            : base(message)
        {
        }

        public NoAmplitudeDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
