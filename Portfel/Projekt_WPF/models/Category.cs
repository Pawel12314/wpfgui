using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_WPF.models
{
    public class Category : Element
    {
        public static int maxID { get; set; }
        public override string name {get;set;}
        static Category()
        {
            maxID = 0;
        }
        public Category()
        {

        }
        public Category(string name)
        {
            this.id = ++maxID;
            this.name = name;
        }
        public static void saveToFile(string filename, List<Category> list)
        {


            if (!File.Exists(filename))
            {
                var stream = File.Create(filename);
                stream.Close();
            }
            //File.Copy(filename, filename + ".copy");
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                //FileStream stream = File.OpenWrite(filename);
                string json = JsonConvert.SerializeObject(list, Formatting.Indented, settings);
                File.WriteAllText(filename, json);
            }
            catch (Exception e)
            {
                File.Delete(filename);
                //File.Move(filename + ".copy", filename);
                throw new Exception("nie mozna zapisac do pliku");

            }


        }
        public static List<Category> readFromFile(string filename)
        {

            List<Category> entries;
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = getFromJson(filename);

                entries = JsonConvert.DeserializeObject<List<Category>>(json, settings);

            }
            catch (Exception e)
            {

                entries = new List<Category>();
            }

            return entries;
        }

        public void changeName(string newName)
        {
            name = newName;
        }
    }
}
