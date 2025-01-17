﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdus si
//     le code est regénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/MathsLibrary")]
    public partial class CompositeType : object
    {
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue
        {
            get
            {
                return this.BoolValueField;
            }
            set
            {
                this.BoolValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                this.StringValueField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IMathsOperations")]
    public interface IMathsOperations
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IMathsOperations/GetDataUsingDataContractResponse")]
        ServiceReference1.CompositeType GetDataUsingDataContract(ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IMathsOperations/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ServiceReference1.CompositeType> GetDataUsingDataContractAsync(ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Add", ReplyAction="http://tempuri.org/IMathsOperations/AddResponse")]
        int Add(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Add", ReplyAction="http://tempuri.org/IMathsOperations/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Multiply", ReplyAction="http://tempuri.org/IMathsOperations/MultiplyResponse")]
        int Multiply(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Multiply", ReplyAction="http://tempuri.org/IMathsOperations/MultiplyResponse")]
        System.Threading.Tasks.Task<int> MultiplyAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Subtract", ReplyAction="http://tempuri.org/IMathsOperations/SubtractResponse")]
        int Subtract(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Subtract", ReplyAction="http://tempuri.org/IMathsOperations/SubtractResponse")]
        System.Threading.Tasks.Task<int> SubtractAsync(int a, int b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IMathsOperationsChannel : ServiceReference1.IMathsOperations, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class MathsOperationsClient : System.ServiceModel.ClientBase<ServiceReference1.IMathsOperations>, ServiceReference1.IMathsOperations
    {
        
        /// <summary>
        /// Implémentez cette méthode partielle pour configurer le point de terminaison de service.
        /// </summary>
        /// <param name="serviceEndpoint">Point de terminaison à configurer</param>
        /// <param name="clientCredentials">Informations d'identification du client</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public MathsOperationsClient() : 
                base(MathsOperationsClient.GetDefaultBinding(), MathsOperationsClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IMathsOperations.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MathsOperationsClient(EndpointConfiguration endpointConfiguration) : 
                base(MathsOperationsClient.GetBindingForEndpoint(endpointConfiguration), MathsOperationsClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MathsOperationsClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(MathsOperationsClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MathsOperationsClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(MathsOperationsClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MathsOperationsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ServiceReference1.CompositeType GetDataUsingDataContract(ServiceReference1.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.CompositeType> GetDataUsingDataContractAsync(ServiceReference1.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public int Add(int a, int b)
        {
            return base.Channel.Add(a, b);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int a, int b)
        {
            return base.Channel.AddAsync(a, b);
        }
        
        public int Multiply(int a, int b)
        {
            return base.Channel.Multiply(a, b);
        }
        
        public System.Threading.Tasks.Task<int> MultiplyAsync(int a, int b)
        {
            return base.Channel.MultiplyAsync(a, b);
        }
        
        public int Subtract(int a, int b)
        {
            return base.Channel.Subtract(a, b);
        }
        
        public System.Threading.Tasks.Task<int> SubtractAsync(int a, int b)
        {
            return base.Channel.SubtractAsync(a, b);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMathsOperations))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMathsOperations))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/MathsLibrary/Service1/");
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return MathsOperationsClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IMathsOperations);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return MathsOperationsClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IMathsOperations);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IMathsOperations,
        }
    }
}
