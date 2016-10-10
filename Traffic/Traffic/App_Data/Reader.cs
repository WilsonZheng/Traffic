using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    public interface Reader
    {
        List<string> GetData(string fileName);
    }

    public abstract class DocumentReader : Reader
    {
        public abstract List<string> GetData(string fileName);
    }

    public class DatDocumentReader : DocumentReader
    {
        public override List<string> GetData(string fileName)
        {
            if(!File.Exists(fileName))
                throw new FileNotFoundException("Could not find a file with that name...");
            int counter = 0;
            string line;
            List<string> results = new List<string>();
            using (var stream = File.OpenRead(fileName))
            using (var reader = new StreamReader(stream))
            {
                try
                {
                    string totalNodeNumber = reader.ReadLine();
                    int nodeNumber = Int32.Parse(totalNodeNumber);
                    while ((line = reader.ReadLine()) != null)
                    {
                        results.Add(line);
                        counter++;
                    }
                    if (!Utility.TotalNumberMatch(nodeNumber, counter))
                    {
                        //throw exception;
                    }
                }
                catch (Exception e)
                {
                    //System.Console.WriteLine(e);
                }
                // return reader.ReadToEnd();
            }
            return results;
        }
    }

}
