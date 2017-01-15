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
        private int amplitudeDataLength = 0;
        private float maxVisibleFrequency;
        private float frequencyResolution;

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

        public float MaximumFrequency
        {
            get
            {
                return ampData.ElementAt(0).Count * frequencyResolution;
            }
        }

        public Bitmap getBitmap(int width, int height, float maxAmpValue)
        {
            if (ampData.Count() == 0 || maxVisibleFrequency == 0 || frequencyResolution == 0) return null;
            Color pixelColor = new Color();

            int visibleDataLength = (int)Math.Round((maxVisibleFrequency / frequencyResolution), 0);

            Bitmap bitmap = new Bitmap(width, visibleDataLength);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;

            unsafe
            {
                byte* dataPtr = (byte*)bitmapData.Scan0;
                float brightness;
                float[][] byteArray = ampData.Select(a => a.ToArray()).ToArray();
                for (int w = 0; w < byteArray.Length; w++)
                {
                    for (int h = 0; h < visibleDataLength; h++)
                    {
                        var value = byteArray[w][h];
                        if (value > maxAmpValue)
                        {
                            brightness = 255;
                        }
                        else
                        {
                            brightness = 255 * (value / maxAmpValue);
                        }

                        byte brightnessByte = (byte)brightness;
                        int index = (w * 3) + (visibleDataLength - h - 1) * stride;
                        dataPtr[index++] = brightnessByte;
                        dataPtr[index++] = brightnessByte;
                        dataPtr[index] = brightnessByte;
                    }
                }
            }
            bitmap.UnlockBits(bitmapData);

            var newImage = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(bitmap, 0, 0, width, height);

            return newImage;
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
