using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    public class Street
    {
        private int streetNum;
        private int startNodeNO;
        private int endNodeNO;
        private TrafficRule tr;
        public int StartNode { get; set; }
        public int StreetNum { get; set; }
        public int EndNode { get; set; }
        public TrafficRule TR { get; set; }
        
        
    }
}
