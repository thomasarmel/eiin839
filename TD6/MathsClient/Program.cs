using ServiceReference1;

var client = new ServiceReference1.MathsOperationsClient(MathsOperationsClient.EndpointConfiguration.BasicHttpBinding_IMathsOperations);
Console.WriteLine(client.Multiply(2, 3));