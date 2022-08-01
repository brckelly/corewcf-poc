namespace CoreWcfTesting;

using CoreWCF;

[ServiceContract]
public interface ISomeCoolService
{
    [OperationContract]
    string DoSomethingRealCool(string someArg);
}
