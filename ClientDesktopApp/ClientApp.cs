using ClientDesktopApp.ConnecToHub;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientDesktopApp
{
    public partial class ClientApp : Form
    {
        private HubConnection hubConnection;
        private HubConnection serverHubConnection;
        private static string apiUrl = "https://localhost:7138/api/v1/serverInfomation";
        //private static string apiUrl = "http://192.168.1.11:5113/api/v1/serverInfomation";

        private HttpClient httpClient;
        public ClientApp()
        {
            InitializeComponent();

            //hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.11:5113/messageBroker").WithAutomaticReconnect().Build();
            hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7138/messageBroker").WithAutomaticReconnect().Build();
            hubConnection.StartAsync();
            connectToServerHub();
            receivedServerTime();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
        }

        private async Task connect()
        {
            await hubConnection.StartAsync();
        }

        private async Task disConnect()
        {
            await hubConnection.StopAsync();
        }

        private async Task sendMessage(MessageEvent message)
        {
            await hubConnection.InvokeAsync("clientMessage", message);
        }

        private void connectToServerHub()
        {
            serverHubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7138/clockData").WithAutomaticReconnect().Build();
            //serverHubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.11:5113/clockData").WithAutomaticReconnect().Build();


            serverHubConnection.StartAsync();
        }

        private void receivedServerTime()
        {
            try
            {
                

                serverHubConnection.On<DateTime>("broadCastTimeServer", time =>
                {
                    Invoke(new Action(() =>
                    {
                        textBox_serverTime.Text = time.ToString();
                    }));
                    Console.WriteLine("====== time server ====== " + time.ToString());
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("===== Error get time server at Client App ===== " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string ip = textBox_ip.Text.Trim();
            string message = textBox_message.Text;

            MessageEvent messageEvent = new MessageEvent(ip, message);

            try
            {
                _ = sendMessage(messageEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("=====Error when send message to Hub==== " + ex.Message);
            }


        }

        private void textBox_serverTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkStorage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK) {
                string path = fbd.SelectedPath;
                //httpClient.re
             
            }
        }


        //private async string checkStorageSever(string path)
        //{
        //    try
        //    {
        //       await serverHubConnection.in
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("=====Error when send message to Hub==== " + ex.Message);
        //    }

        //}
    }
}
