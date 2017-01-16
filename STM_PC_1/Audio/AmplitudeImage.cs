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

        public int DataLength
        {
            get
            {
                return ampData.Count;
            }
        }

        public int AmpDataLength
        {
            get
            {
                if (ampData.Count > 0)
                {
                    return ampData.ElementAt(0).Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Bitmap getBitmap(int width, int height, float maxAmpValue, int maximumFrequency, int samplingFrequency)
        {
            if (ampData.Count() == 0 ||  samplingFrequency == 0) return null;

            int dataLength = ampData.ElementAt(0).Count;
            float windowLength = dataLength / (float)samplingFrequency;
            float frequencyResolution = 1 / windowLength;
            int maxDataLength = (int) Math.Floor(maximumFrequency / frequencyResolution);

            Bitmap bitmap = new Bitmap(width, maxDataLength);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;

            unsafe
            {
                byte* dataPtr = (byte*)bitmapData.Scan0;
                float brightness;
                float[][] byteArray = ampData.Select(a => a.ToArray()).ToArray();
                for (int w = 0; w < byteArray.Length; w++)
                {
                    for (int h = 0; h < maxDataLength; h++)
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
                        int index = (w * 3) + (maxDataLength - h - 1) * stride;
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

            ampData.Add(amplitudeData.DataList);
            while (ampData.Count > maxLength) ampData.RemoveAt(0);
        }
    }
}
