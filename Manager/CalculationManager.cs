using MessManagementSystemWebApp.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Manager
{
    public class CalculationManager
    {

        public int CalculateForMonthDay()
        {
            CalculationGateway calculationGateway = new CalculationGateway();

            calculationGateway.CalculateForMonthDay();

            return 0;
        }
    }
}