using MathServiceReference;

var client = new MathServiceReference.Service1Client(Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);
Console.WriteLine(client.ChannelFactory.CreateChannel().add(2, 5));