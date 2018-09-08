using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class SceneException : Exception
    {
        public SceneException() : base()
        {

        }

        public SceneException(string message): base(message)
        {

        }

        public SceneException(string message, Exception innerException) : base(message, innerException)
        {

        }
        
    }
}
