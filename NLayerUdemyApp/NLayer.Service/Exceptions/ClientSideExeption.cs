using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Exceptions
{
    public class ClientSideExeption : Exception
    {
        public ClientSideExeption( string message): base(message)
        {
        }
    }
}
