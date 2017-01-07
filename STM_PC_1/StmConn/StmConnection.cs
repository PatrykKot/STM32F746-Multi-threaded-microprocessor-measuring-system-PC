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
        private Stopwatch receiveStopwatch = new Stopwatch();

        private IPAddress stmConfigAddress;
        public StmConfig stmConfig = new StmConfig();

        private IPEndPoint pcHost;
        private UdpClient udpClient;
        private Task receiveTask;
        public event EventHandler<AmplitudeDataEventArgs> amplitudeDataReceivedEventHandler;

        public StmConnection(IPAddress stmConfigAddress, IPAddress pcIpAddress, int udpStreamingPort)
        {
            this.stmConfigAddress = stmConfigAddress;
            stmConfig.UdpEndpointPort = udpStreamingPort;
            stmConfig.UdpEndpointIP = pcIpAddress.ToString();

            pcHost = new IPEndPoint(IPAddress.Any, udpStreamingPort);
            udpClient = new UdpClient(udpStreamingPort, AddressFamily.InterNetwork);

            receiveStopwatch.Start();

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
                    receiveStopwatch.Stop();
                    amplitudeReceivedEventSend(ampInst, receiveStopwatch.ElapsedMilliseconds);
                    receiveStopwatch.Restart();
                }
                catch (Exception ex) { }
            }
        }

        private void amplitudeReceivedEventSend(AmplitudeData ampData, long delayTime)
        {
            AmplitudeDataEventArgs args = new AmplitudeDataEventArgs();
            args.amplitudeInstance = ampData;
            args.elapsedTime = delayTime;
            EventHandler<AmplitudeDataEventArgs> handler = amplitudeDataReceivedEventHandler;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public async Task<StmConfig> getConfiguration()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMsg = await client.GetAsync("http://" + stmConfigAddress.ToString() + "/config");
            responseMsg.EnsureSuccessStatusCode();
            string responseString = await responseMsg.Content.ReadAsStringAsync();
            client.Dispose();

            return StmConfig.parse(responseString);
        }

        public StmConfig updateConfiguration()
        {
            WebClient client = new WebClient();
            byte[] response = client.UploadData("http://" + stmConfigAddress.ToString() + "/config", "PUT", Encoding.ASCII.GetBytes(stmConfig.toString()));
            String responseString = System.Text.Encoding.UTF8.GetString(response);

            return StmConfig.parse(responseString);
        }
    }
}
