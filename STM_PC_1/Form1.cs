using System;
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

        public Form1()
        {
            InitializeComponent();

            IPAddress defaultIp;
            try
            {
                defaultIp = IPAddress.Parse((networkInterfaceToolStripMenuItem.DropDownItems[0] as ToolStripMenuItem).DropDownItems[0].Text);
            }
            catch (Exception ex)
            {
                defaultIp = IPAddress.Parse("0.0.0.0");
            }
            int defaultPort = 53426;

            stmConnection = new StmConnection(IPAddress.Parse("192.168.1.11"), defaultIp, defaultPort);
            stmConnection.amplitudeDataReceivedEventHandler += new EventHandler<AmplitudeDataEventArgs>(ampUpdate);

            ampImage = new AmplitudeImage(2000);
            ampImage.MaxVisibleFrequency = (float)maximumFrequencyNumericUpDown.Value;
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

                amplitudePictureBox.Image = ampImage.getBitmap(amplitudePictureBox.Width, amplitudePictureBox.Height);
            }
        }

        private void maximumFrequencyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ampImage.MaximumFrequency < (float)maximumFrequencyNumericUpDown.Value)
                maximumFrequencyNumericUpDown.Value = (int)ampImage.MaximumFrequency;
            ampImage.MaxVisibleFrequency = (float)maximumFrequencyNumericUpDown.Value;
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

        private void sTMConfigurationIPToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            stmConfigurationIpTextBox.Text = stmConnection.StmIpAddress.ToString();
        }

        private StmConfig createConfiguration()
        {
            StmConfig configuration = new StmConfig();
            lock (locker)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        configuration.UdpEndpointIP = endpointTextBox.Text;
                        configuration.UdpEndpointPort = Int32.Parse(portTextBox.Text);
                        configuration.WindowType = windowTypeComboBox.Text;
                        configuration.SamplingFrequency = Int32.Parse(freqTextBox.Text);
                        configuration.AmplitudeSamplingDelay = Int32.Parse(delayTextBox.Text);
                    }));
                }
            }
            return configuration;
        }

        private void parseConfiguration(StmConfig configuration)
        {
            lock (locker)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        endpointTextBox.Text = configuration.UdpEndpointIP;
                        portTextBox.Text = configuration.UdpEndpointPort.ToString();
                        windowTypeComboBox.Text = configuration.WindowType;
                        freqTextBox.Text = configuration.SamplingFrequency.ToString();
                        delayTextBox.Text = configuration.AmplitudeSamplingDelay.ToString();
                    }));
                }
            }
        }

        private void setConfigButton_Click(object sender, EventArgs e)
        {
            Thread updateConfigurationThread = new Thread(new ThreadStart(setConfigurationThread));
            updateConfigurationThread.Start();
        }

        private void setConfigurationThread()
        {
            StmConfig config = createConfiguration();
            try
            {
                stmConnection.updateConfiguration(config);
            }
            catch (Exception ex)
            {
                try
                {
                    stmConnection.updateConfiguration(config);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        private void getConfigButton_Click(object sender, EventArgs e)
        {
            Thread downloadConfigurationThread = new Thread(new ThreadStart(getConfigurationThread));
            downloadConfigurationThread.Start();
        }

        async private void getConfigurationThread()
        {
            StmConfig configuration = await stmConnection.getConfiguration();
            parseConfiguration(configuration);
        }

    }

    public class IpJson
    { public String ip { get; set; } }
}
