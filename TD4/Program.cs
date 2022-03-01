using ServiceReference1;

var client = new ServiceReference1.CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
Console.WriteLine(await client.ChannelFactory.CreateChannel().AddAsync(2, 5));