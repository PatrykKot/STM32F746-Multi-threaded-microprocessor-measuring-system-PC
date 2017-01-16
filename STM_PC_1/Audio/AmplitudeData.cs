using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM_PC_1.Audio
{
    class AmplitudeData
    {
        private List<float> data = new List<float>();

        public AmplitudeData(IEnumerable<float> data)
        {
            foreach (float amplitude in data)
            {
                this.data.Add(amplitude);
            }
        }

        public List<float> DataList
        {
            get { return data; }
        }

        static public AmplitudeData parse(byte[] buffer)
        {
            List<float> data = new List<float>();
            for (int index = 0; index < buffer.Count(); index += 4)
            {
                float ampVal = System.BitConverter.ToSingle(buffer, index);
                data.Add(ampVal);
            }

            AmplitudeData ampData = new AmplitudeData(data);

            return ampData;
        }
    }

    class AmplitudeDataEventArgs : EventArgs
    {
        public AmplitudeData amplitudeInstance;
    }
}
