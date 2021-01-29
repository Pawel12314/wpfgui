using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public abstract class Element
    {
        public int id { get; set; }
        public abstract string name { get; set; }
        
        public Element() { }
        protected static string getFromJson(string filename)
        {
            if(!File.Exists(filename))
            {
                throw new FileNotFoundException("nie znaleziono pliku z danymi");
            }

            StreamReader stream = File.OpenText(filename);
            

                StringBuilder json = new StringBuilder();
                string temp = "";
                while ((temp = stream.ReadLine()) != null)
                {
                    json.Append(temp);
                }
            

           // List<Element> lista = parseJson(json.ToString());
           // List<Element> lista =JsonConvert.DeserializeObject<List<Element>>(json.ToString());
            return json.ToString();
        }
       
        public override string ToString()
        {
            return name;
        }

        
    }
}
