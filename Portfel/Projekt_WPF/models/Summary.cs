using Newtonsoft.Json;
using NodaTime;
using Projekt_WPF.models.range;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_WPF.models
{
    public class Summary:Element
    {
        public Range priceRange { get; set; }
        public LocalDate begin { get; set; }
        public LocalDate end { get; set; }
        public List<SummaryItemEntry> income_summary { get; set; }
        public List<SummaryItemEntry> outcome_summary { get; set; }
        public List<SummaryItemCategory> incomeCategory_summary { get; set; }
        public List<SummaryItemCategory> outncomeCategory_summary { get; set; }
        public List<SummaryType> summTypes { get; }
        public decimal maxsingle { get; set; }
        public decimal maxcategory { get; set; }
        public override string name { get; set; }
       
        public static int maxID { get; set; }
        public Summary()
        {

        }
        public Summary(Range range,LocalDate begin,LocalDate end,List<SummaryItemEntry>income_summ,List<SummaryItemEntry>outcome_summ,List<SummaryItemCategory>inc_cat_summ,List<SummaryItemCategory>out_cat_summ ,decimal maxcat,decimal maxsingle)
        {
            this.income_summary = income_summ;
            this.outcome_summary = outcome_summ;
            this.incomeCategory_summary = inc_cat_summ;
            this.outncomeCategory_summary = out_cat_summ;
            this.id = ++maxID;
            this.name = "podsumowanie nr: " + id;
            this.maxsingle = maxsingle;
            this.maxcategory = maxcategory;
        }

        public override string ToString()
        {
            return name;
        }
        public static void saveToFile(string filename, List<Summary> list)
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
                MessageBox.Show(e.Message);
                throw new Exception("nie mozna zapisac do pliku");

            }


        }
        public static List<Summary> readFromFile(string filename)
        {

            List<Summary> summaries;
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = getFromJson(filename);

                summaries = JsonConvert.DeserializeObject<List<Summary>>(json, settings);

            }
            catch 
            {

                summaries = new List<Summary>();
            }

            return summaries;
        }
    }
}
