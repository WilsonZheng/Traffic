using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Traffic;

namespace Traffic.Controllers
{
    public class TrafficController : Controller
    {
        
        

        //Page of displaying all the data from Nodes.dat, Street.dat and Traffic.dat
        public ActionResult ShowInfo()
        {

            return View();
        }
        //Read the data from Nodes.dat and return it as json object 
        [HttpGet]
        public ActionResult GetNodes()
        {    
            Reader reader = new DatDocumentReader();
            InputParser<Node> nodeInput = new NodeParser();
            List<string> nodesData = reader.GetData(Server.MapPath("~/DataFiles/nodes.dat"));
            List<Node> result = nodeInput.ParseInput(nodesData);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Read the data from Street.dat and return it as json object 
        [HttpGet]
        public ActionResult GetStreet()
        {
           
            Reader reader = new DatDocumentReader();
            InputParser<Street> streetInput = new StreetParser();
            List<string> streetData = reader.GetData(Server.MapPath("~/DataFiles/streets.dat"));
            List<Street> result = streetInput.ParseInput(streetData);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Read the data from Traffic.dat and return it as json object 
        [HttpGet]
        public ActionResult GetTraffic()
        {
            Reader reader = new DatDocumentReader();
            InputParser<Traffic> trafficInput = new TrafficParser();
            List<string> trafficData = reader.GetData(Server.MapPath("~/DataFiles/traffic.dat"));
            List<Traffic> result = trafficInput.ParseInput(trafficData);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Read the data from streets.dat and node.dat and pass them to the view
        public ActionResult ProcessDrawingData()
        {
            Reader reader = new DatDocumentReader();
            InputParser<Street> streetInput = new StreetParser();
            List<string> streetData = reader.GetData(Server.MapPath("~/DataFiles/streets.dat"));
            List<Street> streetList = streetInput.ParseInput(streetData);

            Reader reader2 = new DatDocumentReader();
            InputParser<Node> nodeInput = new NodeParser();
            List<string> nodesData = reader.GetData(Server.MapPath("~/DataFiles/nodes.dat"));
            List<Node> nodeList = nodeInput.ParseInput(nodesData);

            var lineList = new List<LineViewModel>();
            foreach (var s in streetList)
            {
                var nodeX = nodeList[s.StartNode - 1].X;
                var nodeY = nodeList[s.StartNode - 1].Y;
                var nodeX2 = nodeList[s.EndNode - 1].X;
                var nodeY2 = nodeList[s.EndNode - 1].Y;
                var rules = s.TR;
                LineViewModel line = new LineViewModel();
                line.X = nodeX;
                line.Y = nodeY;
                line.X2 = nodeX2;
                line.Y2 = nodeY2;
                if (rules == 0)
                {
                    line.Rules = 1;
                }
                else
                {
                    line.Rules = 2;
                }
                lineList.Add(line);
            }
            return View(lineList);
            
        }

    }
}