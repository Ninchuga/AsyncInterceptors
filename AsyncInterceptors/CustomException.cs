using System;

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
