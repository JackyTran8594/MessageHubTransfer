using System.Data;

namespace MessageHubTransfer.Hubs
{
    public interface IServerData
    {
       Task getTimeServer(DateTime datetime);
    }
}
