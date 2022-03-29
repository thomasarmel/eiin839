using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        int IService1.add(int a, int b)
        {
            return a + b;
        }

        int IService1.div(int a, int b)
        {
            return a / b;
        }

        int IService1.mul(int a, int b)
        {
            return a * b;
        }

        int IService1.sub(int a, int b)
        {
            return a - b;
        }
    }
}
