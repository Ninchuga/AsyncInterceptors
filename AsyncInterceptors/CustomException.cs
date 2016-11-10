using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncInterceptors
{
    public class CustomException : Exception
    {
        public CustomException(string ex) 
            : base(ex)
        {
                
        }
    }
}
