using Newtonsoft.Json;
using NodaTime;
using System;
using System.Collections.Generic;
using System.IO;

public enum Frequency
{
    jednorazowy = 0,
    comiesieczny = 1
}


namespace Projekt_WPF.models
{
    public abstract class Entry : Element
    {
       
        public static int maxID{get;set;}
        public override string name { get; set; }
        public Frequency frequency { get; set; }
        public decimal amount { get; set; }
        public LocalDate begin { get; set; }
        public LocalDate end { get; set; }
        public int duration { get; set; }
        public int categoryID { get; set; }
        public Category category { get; set; }
        
        public string description { get; set; }
        static Entry()
        {
            maxID = 0;
        }
        public Entry()
        {

        }
        public Entry(string name,decimal amount, ref Category category, Frequency frequency, LocalDate begin, int duration = 0, string desc="")
        {
            this.name = name;
            this.amount = amount;
            this.category = category;
            this.frequency = frequency;
            this.begin = begin;
            this.duration = duration;
            this.description = desc;
            this.categoryID = category.id;
            if (duration == 0) this.frequency = Frequency.jednorazowy;
            this.end = begin.PlusMonths(duration);
            this.id = ++maxID;
        }

        private string getFormatedBeginDate()
        {
            string formatedDate = "";
            if (this.begin.Day < 10)
                formatedDate += "0";
            formatedDate += this.begin.Day.ToString();
            formatedDate += "-";
            if (this.begin.Month < 10)
                formatedDate += "0";
            formatedDate += this.begin.Month.ToString();
            formatedDate += "-";
            formatedDate += this.begin.Year.ToString();
            return formatedDate;
        }

        public override string ToString()
        {
            string returning = "";

            returning += getFormatedBeginDate() + "  ";

            if (this.GetType() == typeof(Income))
                returning += "Wpływ\t  ";
            else
                returning += "Wydatek\t  ";

            returning += "nazwa: " + name + "\t";

            returning += "kwota: " + amount.ToString() + "\t";

            returning += "kategoria: " + category + "\t";

            if(description.Length>0)
                returning += "opis: " + description + "\t";

            if (duration!=0)
                returning += "trwa przez: " + duration + " miesięcy";

            return returning;
            /*
            if (description.Length > 0)
            {
                return "nazwa wpisu:" + name + " kwota wpisu:" + amount.ToString() + " kategoria:" + category.ToString() + " data:" + getFormatedBeginDate() + " opis:'" + description + "'";
            }
            return "nazwa wpisu:" + name + " kwota wpisu:" + amount.ToString() + " kategoria:" + category.ToString() + " data:" + getFormatedBeginDate();
            */
        }

        public static void saveInFile(string filename, List<Entry> list)
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
        public static List<Entry> readFromFile(string filename)
        {

            List<Entry> wpisy;
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = getFromJson(filename);

                wpisy = JsonConvert.DeserializeObject<List<Entry>>(json, settings);

            }
            catch (Exception e)
            {
                wpisy = new List<Entry>();
            }

            return wpisy;
        }
        public decimal getSum(LocalDate begin, LocalDate end )
        {
            if(begin > end)
                throw new ArgumentException("pierwsza data musi być mniejsza od drugiej");
            LocalDate tempBegin;// = a;
            
            //temp = this.poczatek;
            
            if (this.begin > begin)
            {
                tempBegin = this.begin;
            }
            else
            {
                tempBegin = begin;
              
            }
            
            LocalDate tempEnd;
            if(this.end<end)
            {
                tempEnd = this.end;
            }
            else
            {
                tempEnd = end;
            }

            int period = Math.Abs((tempBegin.Month - tempEnd.Month) + 12 * (tempBegin.Year - tempEnd.Year));

            return period * this.amount;

            
                
            //return kwota;
        }

    }
   

}
