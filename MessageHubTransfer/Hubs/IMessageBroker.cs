namespace MessageHubTransfer.Hubs
{
    public interface IMessageBroker
    {
        Task ReceiveMessage(string user, string message);
    }
}
