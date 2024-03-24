// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;
using System.Net;

namespace ConsoleAppAdmin
{
    class Program
    {

        private static HubConnection hubConnection;

        static void Main(string[] args)
        {
            buildConnection();

            //receivedMessage();
        }

        private static void buildConnection() 
        {
            hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7138/serverData").WithAutomaticReconnect().Build();
            hubConnection.StartAsync();
        }

        private static async Task disConnect()
        {
            await hubConnection.StopAsync();
        }
        
        private static void sendTriggerData()
        {

        }

        private static void receivedMessage()
        {
            try
            {
                hubConnection.On<MessageEvent>("serverMessage", message =>
                {
                    Console.WriteLine("===== message received from Server in Admin " + message);
                });
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("===== Error received message from Hub to Admin ====== " + ex.ToString());
            }
        }



    }
}



