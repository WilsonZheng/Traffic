using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    public static class Utility
    {
        //Helper Class
        //Check if the actual number of data equal to the total number of data claimed in the file
        public static bool TotalNumberMatch(int totalnumber,int counter)
        {
            return totalnumber == counter;
        }
    }
}
