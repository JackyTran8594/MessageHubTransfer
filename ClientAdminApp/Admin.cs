using ClientAdminApp.ConnecToHub;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net;

namespace ClientAdminApp
{
    public partial class Admin : Form
    {
        private HubConnection hubConnection;
        private HubConnection serverHubConnection;
        public Admin()
        {
            InitializeComponent();
           
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            buildConnection();
            receivedMessage();
            receivedServerTime();
        }


        private void buildConnection()
        {
            hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7138/messageBroker").Build();
            //hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.11:5113/messageBroker").Build();

            hubConnection.StartAsync();
        }


        private async Task disConnect()
        {
            await hubConnection.StopAsync();
        }

        private void receivedMessage()
        {
            try
            {
                hubConnection.On<MessageEvent>("serverMessage", message =>
                {
                    Invoke(new Action(() =>
                    {
                        textBoxMessage.Text = message.ipAddress + "-" + message.payload;
                    }));
                    Console.WriteLine("===== message received from Server in Admin " + message);
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("===== Error received message from Hub to Admin ====== " + ex.ToString());
            }
        }

        private void receivedServerTime()
        {
            try
            {

                serverHubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7138/clockData").WithAutomaticReconnect().Build();
                //serverHubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.11:5113/clockData").WithAutomaticReconnect().Build();

                serverHubConnection.StartAsync();

                serverHubConnection.On<DateTime>("broadCastTimeServer", time =>
                {
                    Invoke(new Action(() =>
                    {
                        textBoxTimeServer.Text = time.ToString();
                    }));
                    Console.WriteLine("====== time server ====== " + time.ToString());
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("===== Error get time server at Client App ===== " + ex.Message);
            }
        }
    }
}
