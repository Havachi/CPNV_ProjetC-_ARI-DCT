using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    public class ArgumentNullException : Exception
    {
        public ArgumentNullException()
        {

        }

        public ArgumentNullException(string messageAlert, System.Exception inner) : base(messageAlert, inner) { }


    }
}
