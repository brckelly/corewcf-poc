namespace SoapClient
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.SomeCoolServiceClient service = new ServiceReference1.SomeCoolServiceClient();
            var result = service.DoSomethingRealCool("lksjdfl");
            Console.WriteLine(result);
        }
    }
}
