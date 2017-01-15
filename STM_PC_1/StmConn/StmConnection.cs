using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using System.IO;
using STM_PC_1.Audio;
using STM_PC_1.StmConn.Configuration;

namespace STM_PC_1.StmConn
{
    class StmConnection
    {
        private IPAddress stmConfigAddress;
        private IPEndPoint pcHost;

        private UdpClient udpClient;
        private Task receiveTask;
        public event EventHandler<AmplitudeDataEventArgs> amplitudeDataReceivedEventHandler;

        public StmConfig LastConfiguration { get; set; }

        public StmConnection(IPAddress stmConfigAddress, int udpStreamingPort)
        {
            LastConfiguration = new StmConfig();
            this.stmConfigAddress = stmConfigAddress;

            pcHost = new IPEndPoint(IPAddress.Any, udpStreamingPort);
            udpClient = new UdpClient(udpStreamingPort, AddressFamily.InterNetwork);

            receiveTask = Task.Run(() => receiveByUdpAsync());
        }

        public IPAddress StmIpAddress
        {
            get
            {
                return stmConfigAddress;
            }
            set
            {
                stmConfigAddress = value;
            }
        }


        private Task receiveByUdpAsync()
        {
            byte[] data = null;

            while (true)
            {
                try
                {
                    if (udpClient != null)
                        data = udpClient.Receive(ref pcHost);
                    AmplitudeData ampInst = AmplitudeData.parse(data, 23);
                    amplitudeReceivedEventSend(ampInst);
                }
                catch (Exception ex) { }
            }
        }

        private void amplitudeReceivedEventSend(AmplitudeData ampData)
        {
            AmplitudeDataEventArgs args = new AmplitudeDataEventArgs();
            args.amplitudeInstance = ampData;
            EventHandler<AmplitudeDataEventArgs> handler = amplitudeDataReceivedEventHandler;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public async Task<StmConfig> getConfiguration()
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(1);
            HttpResponseMessage responseMsg = await client.GetAsync("http://" + stmConfigAddress.ToString() + "/config");
            responseMsg.EnsureSuccessStatusCode();
            string responseString = await responseMsg.Content.ReadAsStringAsync();
            client.Dispose();

            LastConfiguration = StmConfig.parse(responseString);
            return LastConfiguration;
        }

        public StmConfig updateConfiguration(StmConfig stmConfig)
        {
            WebClient client = new WebClient();
            byte[] response = client.UploadData("http://" + stmConfigAddress.ToString() + "/config", "PUT", Encoding.ASCII.GetBytes(stmConfig.toString()));
            String responseString = System.Text.Encoding.UTF8.GetString(response);

            LastConfiguration = StmConfig.parse(responseString);
            return LastConfiguration;
        }
    }
}
