namespace CoreWcfTesting;

using CoreWCF.Web;

public class SomeCoolService : ISomeCoolService
{
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
    public string DoSomethingRealCool(string someArg)
    {
        return $"Received: {someArg}";
    }
}
