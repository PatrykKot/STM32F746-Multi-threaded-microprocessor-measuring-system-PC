﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Net;
using System.Web.Script.Serialization;
using System.Threading;
using STM_PC_1.StmConn;
using STM_PC_1.Audio;
using STM_PC_1.StmConn.Configuration;

namespace STM_PC_1
{
    public partial class Form1 : Form
    {
        private object locker = new object();

        StmConnection stmConnection;
        AmplitudeImage ampImage;

        private delegate void amplitudeDataReceivedMessageCallBack(object sender, AmplitudeDataEventArgs e);

        private bool isDisabled;

        private Dictionary<String, String> windowTypeDictionary = new Dictionary<string, string>();

        private static int maxImageRefreshingDelay = (10);

        private System.Windows.Forms.Timer refreshingTimer;

        public Form1()
        {
            InitializeComponent();
            windowTypeDictionary.Add("Rectangle", "RECTANGLE");
            windowTypeDictionary.Add("Hann", "HANN");
            windowTypeDictionary.Add("Flat top", "FLAT_TOP");

            disableAll();

            stmConnection = new StmConnection(IPAddress.Parse("192.168.1.11"), 53426);
            stmConnection.amplitudeDataReceivedEventHandler += new EventHandler<AmplitudeDataEventArgs>(ampUpdate);

            ampImage = new AmplitudeImage();
            rulerPictureBox.Image = drawRuler(rulerPictureBox.Width, rulerPictureBox.Height, 1, (int)maximumFrequencyNumericUpDown.Value / 1000, 300);

            Thread connectionCheckThread = new Thread(new ThreadStart(connectionThread));
            connectionCheckThread.IsBackground = true;
            connectionCheckThread.Start();

            refreshingTimer = new System.Windows.Forms.Timer();
            refreshingTimer.Interval = maxImageRefreshingDelay;
            refreshingTimer.Tick += refreshingTimer_Tick;
            refreshingTimer.Start();
        }

        void refreshingTimer_Tick(object sender, EventArgs e)
        {
            if (ampImage.DataLength != 0 && startedCheckBox.Checked)
            {
                float maxAmpValue = maxAmpValScrollBar.Value;

                try
                {
                    amplitudePictureBox.Image = ampImage.getBitmap(amplitudePictureBox.Width, amplitudePictureBox.Height, maxAmpValue, (int)maximumFrequencyNumericUpDown.Value, stmConnection.LastConfiguration.SamplingFrequency);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    updateMaximumFrequencyNumericUpDown();
                }
            }
        }

        async private void connectionThread()
        {
            while (true)
            {
                StmConfig configuration;
                try
                {
                    configuration = await stmConnection.getConfiguration();

                    if (isDisabled)
                    {
                        this.Invoke(new Action(() =>
                        {
                            enableAll();
                            parseConfiguration(configuration);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection check: " + ex.Message);

                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            disableAll();
                        }));
                    }
                    catch (Exception) { }
                }

                Thread.Sleep(5000);
            }
        }

        void disableAll()
        {
            lock (locker)
            {
                endpointTextBox.Enabled = false;
                portTextBox.Enabled = false;
                windowTypeComboBox.Enabled = false;
                setConfigButton.Enabled = false;
                freqTextBox.Enabled = false;
                delayTextBox.Enabled = false;
                maximumFrequencyNumericUpDown.Enabled = false;
                maxAmpValScrollBar.Enabled = false;
                isDisabled = true;

                clearAll();
            }
        }

        void enableAll()
        {
            lock (locker)
            {
                endpointTextBox.Enabled = true;
                portTextBox.Enabled = true;
                windowTypeComboBox.Enabled = true;
                setConfigButton.Enabled = true;
                freqTextBox.Enabled = true;
                delayTextBox.Enabled = true;
                maximumFrequencyNumericUpDown.Enabled = true;
                maxAmpValScrollBar.Enabled = true;
                isDisabled = false;

                clearAll();
            }
        }

        void clearAll()
        {
            endpointTextBox.Text = "";
            portTextBox.Text = "";
            windowTypeComboBox.Text = "";
            freqTextBox.Text = "";
            delayTextBox.Text = "";
        }

        private void ampUpdate(object sender, AmplitudeDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new amplitudeDataReceivedMessageCallBack(ampUpdate), new object[] { sender, e });
            }
            else
            {
                ampImage.update(e.amplitudeInstance, amplitudePictureBox.Width);
            }
        }

        private void updateMaximumFrequencyNumericUpDown()
        {
            int maximumUserFrequency = (int)maximumFrequencyNumericUpDown.Value;
            int samplingFrequency = stmConnection.LastConfiguration.SamplingFrequency;
            int windowSize = 2048;
            float windowLength = windowSize / (float)samplingFrequency;
            float frequencyResolution = 1 / windowLength;

            if (ampImage.AmpDataLength == 0) return;
            else
            {
                int dataLength = ampImage.AmpDataLength;
                float maximumVisibleFrequency = frequencyResolution * dataLength;

                if (maximumUserFrequency > maximumVisibleFrequency)
                {
                    maximumFrequencyNumericUpDown.Value = (int)Math.Floor(maximumVisibleFrequency / 1000) * 1000;
                }
            }
        }

        private void maximumFrequencyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int maximumUserFrequency = (int)maximumFrequencyNumericUpDown.Value;
            int samplingFrequency = stmConnection.LastConfiguration.SamplingFrequency;
            int windowSize = 2048;
            float windowLength = windowSize / (float)samplingFrequency;
            float frequencyResolution = 1 / windowLength;

            if (ampImage.AmpDataLength == 0) return;
            else
            {
                int dataLength = ampImage.AmpDataLength;
                float maximumVisibleFrequency = frequencyResolution * dataLength;

                if (maximumUserFrequency > maximumVisibleFrequency)
                {
                    maximumFrequencyNumericUpDown.Value = (int)Math.Floor(maximumVisibleFrequency / 1000) * 1000;
                }

                Thread drawRulerTh = new Thread(new ThreadStart(drawRulerThread));
                drawRulerTh.IsBackground = true;
                drawRulerTh.Start();
            }
        }

        private void networkInterfaceToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            Thread updateNetworkInterfacesThread = new Thread(new ThreadStart(updateNetworkInterfaces));
            updateNetworkInterfacesThread.Start();
        }

        private void updateNetworkInterfaces()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    networkInterfaceToolStripMenuItem.DropDownItems.Clear();

                    foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                    {

                        if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet || ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                        {
                            ToolStripMenuItem item = new ToolStripMenuItem(ni.Name);

                            foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    ToolStripMenuItem ipItem = new ToolStripMenuItem(ip.Address.ToString());
                                    ipItem.Click += (s, ea) => { endpointTextBox.Text = ip.Address.ToString(); };
                                    item.DropDownItems.Add(ipItem);
                                }

                            networkInterfaceToolStripMenuItem.DropDownItems.Add(item);
                        }
                    }
                }));
            }
        }

        private StmConfig createConfiguration()
        {
            StmConfig configuration = new StmConfig();
            lock (locker)
            {
                try
                {
                    IPAddress address = IPAddress.Parse(endpointTextBox.Text);
                    configuration.UdpEndpointIP = address.ToString();
                    endpointTextBox.Text = address.ToString();
                }
                catch (Exception)
                {
                    endpointTextBox.Text = stmConnection.LastConfiguration.UdpEndpointIP;
                    configuration.UdpEndpointIP = stmConnection.LastConfiguration.UdpEndpointIP;
                }

                try
                {
                    int port = Int32.Parse(portTextBox.Text);
                    if (port < 0 || port > 65535) throw new Exception();
                    configuration.UdpEndpointPort = port;
                }
                catch (Exception)
                {
                    portTextBox.Text = stmConnection.LastConfiguration.UdpEndpointPort.ToString();
                    configuration.UdpEndpointPort = stmConnection.LastConfiguration.UdpEndpointPort;
                }

                try
                {
                    int frequency = Int32.Parse(freqTextBox.Text);
                    if (frequency < 0 || frequency > 192000) throw new Exception();
                    configuration.SamplingFrequency = frequency;
                }
                catch (Exception)
                {
                    freqTextBox.Text = stmConnection.LastConfiguration.SamplingFrequency.ToString();
                    configuration.SamplingFrequency = stmConnection.LastConfiguration.SamplingFrequency;
                }

                try
                {
                    int samplpingDelay = Int32.Parse(delayTextBox.Text);
                    if (samplpingDelay <= 0 || samplpingDelay > 10000) throw new Exception();
                    configuration.AmplitudeSamplingDelay = samplpingDelay;
                }
                catch (Exception)
                {
                    delayTextBox.Text = stmConnection.LastConfiguration.AmplitudeSamplingDelay.ToString();
                    configuration.AmplitudeSamplingDelay = stmConnection.LastConfiguration.AmplitudeSamplingDelay;
                }

                try
                {
                    string windowType = "";
                    if (!windowTypeDictionary.TryGetValue(windowTypeComboBox.Text, out windowType))
                        throw new Exception();

                    configuration.WindowType = windowType;
                }
                catch (Exception)
                {
                    configuration.WindowType = stmConnection.LastConfiguration.WindowType;
                    windowTypeComboBox.Text = windowTypeDictionary.FirstOrDefault(x => x.Value == stmConnection.LastConfiguration.WindowType).Key;
                }
            }
            return configuration;
        }

        private void parseConfiguration(StmConfig configuration)
        {
            lock (locker)
            {
                endpointTextBox.Text = configuration.UdpEndpointIP;
                portTextBox.Text = configuration.UdpEndpointPort.ToString();
                windowTypeComboBox.Text = configuration.WindowType;
                freqTextBox.Text = configuration.SamplingFrequency.ToString();
                delayTextBox.Text = configuration.AmplitudeSamplingDelay.ToString();
            }
        }

        private void setConfigButton_Click(object sender, EventArgs e)
        {
            Thread updateConfigurationThread = new Thread(new ThreadStart(setConfigurationThread));
            updateConfigurationThread.Start();
        }

        private void setConfigurationThread()
        {
            StmConfig config = null;
            this.Invoke(new Action(() => { config = createConfiguration(); }));
            try
            {
                config = stmConnection.updateConfiguration(config);
            }
            catch (Exception ex)
            {
                try
                {
                    config = stmConnection.updateConfiguration(config);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    return;
                }
            }
            if (InvokeRequired) { this.Invoke(new Action(() => { parseConfiguration(config); })); }
        }

        private void saveImageStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save image";
            dialog.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            dialog.AddExtension = true;
            dialog.FileName = "screen";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                amplitudePictureBox.Image.Save(dialog.FileName);
            }
        }

        private void amplitudePictureBox_Resize(object sender, EventArgs e)
        {
            Thread drawRulerTh = new Thread(new ThreadStart(drawRulerThread));
            drawRulerTh.IsBackground = true;
            drawRulerTh.Start();
        }

        private void drawRulerThread()
        {
            int maximumValue = (int)maximumFrequencyNumericUpDown.Value / 1000;
            int interval = 1;

            if (maximumValue > 30)
            {
                interval = 10;
            }

            Bitmap bitmap = drawRuler(rulerPictureBox.Width, rulerPictureBox.Height, interval, maximumValue, 300);

            this.Invoke(new Action(() =>
            {
                rulerPictureBox.Image = bitmap;
            }));
        }

        private Bitmap drawRuler(int width, int height, float interval, float maxValue, int scalingHeight)
        {
            Font font = new Font("Arial", 7);
            Bitmap bitmap = new Bitmap(width, scalingHeight);
            Graphics rulerGraphics = Graphics.FromImage(bitmap);

            rulerGraphics.DrawRectangle(Pens.White, ClientRectangle);
            rulerGraphics.FillRectangle(Brushes.Black, 0, 0, Width, scalingHeight);
            int count = 0;
            int maxCount = 1;
            int everyPixels = (int)(scalingHeight / (maxValue / interval));

            for (int pixels = 0; pixels < scalingHeight; pixels++)
            {
                if ((pixels % everyPixels) == 0)
                {
                    maxCount++;
                }
            }

            for (int pixels = scalingHeight; pixels >= 0; pixels--)
            {
                if (((scalingHeight - pixels) % everyPixels) == 0)
                {
                    rulerGraphics.DrawLine(Pens.White, (int)(width / 1.5), pixels, width, pixels);

                    if (count != 0 && count < maxCount - 1)
                        rulerGraphics.DrawString((count * interval).ToString(), font, Brushes.White, 0 + width / 12, pixels - 6, new StringFormat());
                    count++;
                }
                else if (((scalingHeight - pixels) % everyPixels) == (everyPixels / 2))
                {
                    rulerGraphics.DrawLine(Pens.White, (int)(width / 1.2), pixels, width, pixels);
                }
            }

            rulerGraphics.DrawImage(bitmap, width, scalingHeight);

            if (width == 0 || height == 0)
                return null;
            return new Bitmap(bitmap, width, height);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Thread drawRulerTh = new Thread(new ThreadStart(drawRulerThread));
            drawRulerTh.IsBackground = true;
            drawRulerTh.Start();
        }
    }

    public class IpJson
    { public String ip { get; set; } }
}
