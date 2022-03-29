using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int add(int a, int b);

        [OperationContract]
        int sub(int a, int b);

        [OperationContract]
        int mul(int a, int b);

        [OperationContract]
        int div(int a, int b);
    }
}
