using NetworkService.Utils.Enumerators;

namespace NetworkService.Utils
{
    public class Dictionaries
    {
        public static Dictionary<HttpMethodType, string> HttpMethods = new()
        {
            { HttpMethodType.GET, "GET" },
            { HttpMethodType.POST, "POST" },
            { HttpMethodType.PUT, "PUT" },
            { HttpMethodType.DELETE, "DELETE" }
        };
    }
}
