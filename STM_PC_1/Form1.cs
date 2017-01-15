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

        private bool isDisabled;

        private Dictionary<String, String> windowTypeDictionary = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            windowTypeDictionary.Add("Rectangle", "RECTANGLE");
            windowTypeDictionary.Add("Hann","HANN");
            windowTypeDictionary.Add("Flat top", "FLAT_TOP");

            disableAll();

            stmConnection = new StmConnection(IPAddress.Parse("192.168.1.11"), 53426);
            stmConnection.amplitudeDataReceivedEventHandler += new EventHandler<AmplitudeDataEventArgs>(ampUpdate);

            ampImage = new AmplitudeImage((float)maximumFrequencyNumericUpDown.Value);

            Thread connectionCheckThread = new Thread(new ThreadStart(connectionThread));
            connectionCheckThread.Start();
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

                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection check: " + ex.Message);

                    this.Invoke(new Action(() =>
                    {
                        disableAll();
                    }));

                    Thread.Sleep(1000);
                }
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
                getConfigButton.Enabled = false;
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
                getConfigButton.Enabled = true;
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

                float maxAmpValue = maxAmpValScrollBar.Value;
                amplitudePictureBox.Image = ampImage.getBitmap(amplitudePictureBox.Width, amplitudePictureBox.Height, maxAmpValue);
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
                catch(Exception)
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
                catch(Exception)
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

        private void getConfigButton_Click(object sender, EventArgs e)
        {
            Thread downloadConfigurationThread = new Thread(new ThreadStart(getConfigurationThread));
            downloadConfigurationThread.Start();
        }

        async private void getConfigurationThread()
        {
            StmConfig configuration = null;
            try
            {
                configuration = await stmConnection.getConfiguration();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            this.Invoke(new Action(() => { parseConfiguration(configuration); }));
        }
    }

    public class IpJson
    { public String ip { get; set; } }
}
