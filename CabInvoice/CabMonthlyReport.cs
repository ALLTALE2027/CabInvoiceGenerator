using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class CabMonthlyReport
    {
        public double totalFare;
        public int numOfRides;
        public double average;

        public CabMonthlyReport(double totalFare, int numOfRides)
        {
            this.totalFare = totalFare;
            this.numOfRides = numOfRides;
            average = totalFare/numOfRides;
        }

        public override bool Equals(object? obj)
        {
           if(obj == null)
                return false;
           if(obj.GetType() != typeof(CabMonthlyReport))
                return false;

           CabMonthlyReport Invoice = (CabMonthlyReport)obj;
            return this.numOfRides==Invoice.numOfRides &&this.totalFare==Invoice.totalFare && this.average==Invoice.average;
        }
    }
}
