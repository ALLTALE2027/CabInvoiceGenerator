using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{

   
    public class CabInvoiceException : Exception
    {
        public enum CabException
        {
            Zero_Distance,
            Zero_Time
        }
        public CabException ExceptionType;
        public CabInvoiceException(CabException exceptionType, string messege) : base(messege)
        {
            this.ExceptionType = exceptionType;
        }
    }
}
