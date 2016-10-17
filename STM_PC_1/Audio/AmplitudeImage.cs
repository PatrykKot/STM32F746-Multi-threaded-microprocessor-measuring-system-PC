using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace STM_PC_1.Audio
{
    class AmplitudeImage
    {
        private List<List<float>> ampData = new List<List<float>>();
        private float maxAmpVal = 1;
        private int amplitudeDataLength = 0;
        private float maxVisibleFrequency;
        private float frequencyResolution;

        public AmplitudeImage(float maxVisibleFrequency)
        {
            this.maxVisibleFrequency = maxVisibleFrequency;
        }

        public float FrequencyResolution { get { return frequencyResolution; } }

        public float getStrongestFrequency()
        {
            List<float> data = ampData.ElementAt(ampData.Count() - 1);
            return data.IndexOf(data.Max()) * frequencyResolution;
        }

        public float MaxVisibleFrequency
        {
            get
            {
                return maxVisibleFrequency;
            }
            set
            {
                if (maxVisibleFrequency != value)
                {
                    maxVisibleFrequency = value;
                }
            }
        }

        public float MaximumFrequency
        {
            get
            {
                return ampData.ElementAt(0).Count * frequencyResolution;
            }
        }

        public Bitmap getBitmap(int width, int height)
        {
            if (ampData.Count() == 0 || maxVisibleFrequency == 0 || frequencyResolution == 0) return null;
            Color pixelColor = new Color();

            float foundMax = findMaxAmp(this);
            if (foundMax > maxAmpVal) maxAmpVal = foundMax;

            int visibleDataLength = (int)Math.Round((maxVisibleFrequency / frequencyResolution), 0);

            Bitmap bitmap = new Bitmap(width, visibleDataLength);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;

            unsafe
            {
                byte* dataPtr = (byte*)bitmapData.Scan0;
                float brightness;
                byte red, green, blue;
                for (int w = 0; w < ampData.Count; w++)
                    for (int h = 0; h < visibleDataLength; h++)
                    {
                        brightness = 255 * (ampData.ElementAt(w).ElementAt(h) / maxAmpVal);
                        blue = (byte)brightness;

                        pixelColor = Color.FromArgb(0,0, blue);
                        dataPtr[(w * 3) + h * stride] = pixelColor.B;
                        dataPtr[(w * 3) + h * stride + 1] = pixelColor.G;
                        dataPtr[(w * 3) + h * stride + 2] = pixelColor.R;
                    }
            }
            bitmap.UnlockBits(bitmapData);

            return new Bitmap(bitmap, new Size(width, height));
        }

        static private float findMaxAmp(AmplitudeImage ampImg)
        {
            float max = 0;
            foreach(List<float> list in ampImg.ampData)
                foreach(float val in list)
                {
                    if (val > max) max = val;
                }
            return max;
        }

        public void update(AmplitudeData amplitudeData, int maxLength)
        {
            if (amplitudeDataLength != amplitudeData.DataList.Count())
            {
                amplitudeDataLength = amplitudeData.DataList.Count();
                ampData.Clear();
            }
            if (frequencyResolution != amplitudeData.frequencyResolution)
            {
                frequencyResolution = amplitudeData.frequencyResolution;
                ampData.Clear();
            }

            ampData.Add(amplitudeData.DataList);
            while (ampData.Count > maxLength) ampData.RemoveAt(0);
        }
    }
}
