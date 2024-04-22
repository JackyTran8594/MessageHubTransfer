using System.Data;

namespace MessageHubTransfer.Hubs
{
    public interface IClock
    {
       Task broadCastTimeServer(DateTime datetime);
    }
}
