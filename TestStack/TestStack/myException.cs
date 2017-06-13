using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStack
{ //Serializable - превращает объект в поток байтов
    [Serializable]
    public class myException : ApplicationException
    {
        public myException () { }
        public myException (string message) : base(message) { } // base() - обращение к конструтору базового класса
        public myException (string message, Exception ex) : base (message) { }
        protected myException(System.Runtime.Serialization.SerializationInfo info, 
                        System.Runtime.Serialization.StreamingContext contex) : base(info, contex) { }

    }
}
