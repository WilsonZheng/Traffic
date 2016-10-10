using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    public interface InputParser<T> where T : class
    {
        List<T> ParseInput(List<string> input);
    }

    public class NodeParser : InputParser<Node>
    {
        public List<Node> ParseInput(List<string> input)
        {
            List<Node> nodes = new List<Node>();
            char[] delimiterChars = { '\t' };
            int counter = 0;
            foreach (var node in input)
            {
                string[] splitnodes = node.Split(delimiterChars);
                Node n = new Node();
                n.NodeNum = ++counter;
                n.X = Int32.Parse(splitnodes[0]);
                n.Y = Int32.Parse(splitnodes[1]);
                nodes.Add(n);
            }
            return nodes;
        }
    }

    public class StreetParser : InputParser<Street>
    {
        public List<Street> ParseInput(List<string> input)
        {
            List<Street> streets = new List<Street>();
            char[] delimiterChars = { '\t' };
            int counter = 0;
            foreach (var street in input)
            {
                string[] splitstreets = street.Split(delimiterChars);
                Street s = new Street();
                s.StreetNum = ++counter;
                s.StartNode = Int32.Parse(splitstreets[0]);
                s.EndNode = Int32.Parse(splitstreets[1]);
                if (splitstreets[2] == "ONEWAY")
                {
                    s.TR = TrafficRule.ONEWAY;
                }
                else
                {
                    s.TR = TrafficRule.TWOWAY;
                }
                streets.Add(s);
            }
            return streets;
        }
    }

    public class TrafficParser : InputParser<Traffic>
    {
        public List<Traffic> ParseInput(List<string> input)
        {
            List<Traffic> traffics = new List<Traffic>();
            char[] delimiterChars = { '\t',' ' };
            foreach (var traffic in input)
            {
                string[] splittraffics = traffic.Split(delimiterChars);
                Traffic t = new Traffic();
                var time = splittraffics[0];
                t.TimeofDay = time;
                t.Entry_Junction = Int32.Parse(splittraffics[1]);
                t.Exit_Junction = Int32.Parse(splittraffics[2]);
                t.Makemodel = splittraffics[3];
                t.Colour = splittraffics[4];
                traffics.Add(t);
            }
            return traffics;
        }
    }
}
