namespace MessageHubTransfer.Model
{
    public class MessageEvent
    {
        public int id { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public string messageType { get; set; }
        public string payload { get; set; }
        public string ipAddress {  get; set; }

        public MessageEvent()
        {

        }
    }
}
