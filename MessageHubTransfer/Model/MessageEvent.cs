﻿namespace MessageHubTransfer.Model
{
    public class MessageEvent
    {
        public string id { get; set; }

        public string type { get; set; }
        public string ipAddress { get; set; }
        public string key { get; set; }
        public string payload { get; set; }
        public string deviceId { get; set; }

        public MessageEvent()
        {

        }

        public MessageEvent(string id, string type, string ipAddress, string key, string payload, string deviceId)
        {
            this.id = id;
            this.type = type;
            this.ipAddress = ipAddress;
            this.key = key;
            this.payload = payload;
            this.deviceId = deviceId;
        }
    }
}
