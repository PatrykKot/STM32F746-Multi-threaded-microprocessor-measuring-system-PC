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
using STM_PC_1.StmConn;
using STM_PC_1.Audio;
using STM_PC_1.StmConn.Configuration;

namespace STM_PC_1
{
    public partial class Form1 : Form
    {
        StmConnection stmConnection;
        AmplitudeImage ampImage;
        Timer connectionTimer;

        private delegate void amplitudeDataReceivedMessageCallBack(object sender, AmplitudeDataEventArgs e);

        public Form1()
        {
            InitializeComponent();
            updateNetworkInterfaces();

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

            connectionTimer = new Timer();
            connectionTimer.Interval = 100;
            connectionTimer.Enabled = true;
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
                freqResolutionTextBox.Text = ampImage.FrequencyResolution.ToString();
            }
        }

        private void maximumFrequencyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ampImage.MaximumFrequency < (float)maximumFrequencyNumericUpDown.Value)
                maximumFrequencyNumericUpDown.Value = (int)ampImage.MaximumFrequency;
            ampImage.MaxVisibleFrequency = (float)maximumFrequencyNumericUpDown.Value;
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StmConfig config = await stmConnection.getConfiguration();
                Console.WriteLine(config.toString());
                delayTextBox.Text = config.AmplitudeSamplingDelay.ToString();
                freqTextBox.Text = config.SamplingFrequency.ToString();
                endpointTextBox.Text = config.UdpEndpointIP;
                portTextBox.Text = config.UdpEndpointPort.ToString();
                windowTypeComboBox.Text = config.WindowType;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                stmConnection.updateConfiguration();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void networkInterfaceToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            updateNetworkInterfaces();
        }

        private async void updateNetworkInterfaces()
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
                            ipItem.Click += (s, ea) => { stmConnection.stmConfig.UdpEndpointIP = ip.Address.ToString(); };
                            item.DropDownItems.Add(ipItem);
                        }

                    networkInterfaceToolStripMenuItem.DropDownItems.Add(item);
                }
            }

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("http://api.ipify.org/?format=json");
                response.EnsureSuccessStatusCode();
                string responseString = await response.Content.ReadAsStringAsync();
                client.Dispose();
                string publicIp = (new JavaScriptSerializer().Deserialize(responseString, typeof(IpJson)) as IpJson).ip;

                var publicIpItem = new ToolStripMenuItem("Public IP");
                publicIpItem.DropDownItems.Add(publicIp);
                IPAddress.Parse(publicIp);
                publicIpItem.Click += (s, e) => { stmConnection.stmConfig.UdpEndpointIP = publicIp; };
                networkInterfaceToolStripMenuItem.DropDownItems.Add(publicIpItem);
            }
            catch (Exception) { };
        }

        private void uDPStreamingPortToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            udpStreamingPortTextBox.Text = stmConnection.stmConfig.UdpEndpointPort.ToString();
        }

        private void udpStreamingPortTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    stmConnection.stmConfig.UdpEndpointPort = Int32.Parse(udpStreamingPortTextBox.Text);
                }
                catch (Exception)
                {
                    udpStreamingPortTextBox.Text = stmConnection.stmConfig.UdpEndpointPort.ToString();
                }
            }
        }

        private void stmConfigurationIpTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    IPAddress address = IPAddress.Parse(stmConfigurationIpTextBox.Text);
                    stmConnection.StmIpAddress = address;
                }
                catch (Exception ex)
                {
                    stmConfigurationIpTextBox.Text = stmConnection.StmIpAddress.ToString();
                }
            }
        }

        private void sTMConfigurationIPToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            stmConfigurationIpTextBox.Text = stmConnection.StmIpAddress.ToString();
        }

        private void endpointTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IPAddress.Parse(endpointTextBox.Text);
                stmConnection.stmConfig.UdpEndpointIP = endpointTextBox.Text;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                endpointTextBox.Text = stmConnection.stmConfig.UdpEndpointIP;
            }
        }

        private void delayTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                stmConnection.stmConfig.AmplitudeSamplingDelay = Convert.ToInt64(delayTextBox.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                delayTextBox.Text = stmConnection.stmConfig.AmplitudeSamplingDelay.ToString();
            }
        }

        private void freqTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                stmConnection.stmConfig.SamplingFrequency = Convert.ToInt64(freqTextBox.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                freqTextBox.Text = stmConnection.stmConfig.SamplingFrequency.ToString();
            }
        }

        private void portTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                stmConnection.stmConfig.UdpEndpointPort = Convert.ToInt32(portTextBox.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                portTextBox.Text = stmConnection.stmConfig.UdpEndpointPort.ToString();
            }
        }

        private void sizeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                stmConnection.stmConfig.WindowType = windowTypeComboBox.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class IpJson
    { public String ip { get; set; } }
}
