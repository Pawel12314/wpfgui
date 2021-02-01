using Projekt_WPF.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Projekt_WPF.ViewModel
{
    public class MyViewModel
    {
        [XmlArray]
        [XmlArrayItem(typeof(Category))]
        public ObservableCollection<Category> categories { get; set; }

        [XmlArray]
        [XmlArrayItem(typeof(Entry)),
            XmlArrayItem(typeof(Income)),
   XmlArrayItem(typeof(Outcome))]
        
        public ObservableCollection<Entry> entries { get; set; }
        


        //public List<Income> incomes { get; set; }
        [XmlArray]
        [XmlArrayItem(typeof(Summary))]
        public ObservableCollection<Summary> summaryList { get; set; }
        [XmlArray]
        [XmlArrayItem(typeof(Wish))]

        public ObservableCollection<Entry> wishes { get; set; }

        [XmlArray]
        [XmlArrayItem(typeof(WishGroup))]
        public ObservableCollection<Category>wishgroups { get; set; }
  
        [XmlArray]
        [XmlArrayItem(typeof(Budget))]
        public ObservableCollection<Budget> budget { get; set; }
      

        public MyViewModel()
        {
            //MessageBox.Show("viewmodel created");
            categories = new ObservableCollection<Category>();
            entries = new ObservableCollection<Entry>();
            summaryList = new ObservableCollection<Summary>();
            wishes = new ObservableCollection<Entry>();
            wishgroups = new ObservableCollection<Category>();
            budget = new ObservableCollection<Budget>();
            /*
            categories = new ObservableCollection<Category>( Category.readFromFile("kategorie.json")  );
            entries = new ObservableCollection<Entry>( Entry.readFromFile("wpisy.json") );
            summaryList = new ObservableCollection<Summary>(Summary.readFromFile("summaries.json"));
            */
            //MessageBox.Show(wpisy[0].nazwa);
        }

        public void serialize(string filename)
        {
            // Creates a new XmlSerializer.
            XmlSerializer s = new XmlSerializer(typeof(MyViewModel));

            // Writing the XML file to disk requires a TextWriter.
            TextWriter writer = new StreamWriter(filename);
           

            // Creates an int and a string and assigns to ExtraInfo.
           

            // Serializes the object, and closes the StreamWriter.
            s.Serialize(writer, this);
            writer.Close();
        }
        private ObservableCollection<Entry> addCateogryReference(List<Entry>items, ObservableCollection<Category> categories)
        {
            ObservableCollection<Entry> entries = new ObservableCollection<Entry>();
            for (int i=0;i<items.Count;i++)
            {
                for(int u=0;u<categories.Count;u++)
                {
                    if(items[i].categoryID==categories[u].id)
                    {
                        Entry e = items[i];
                        e.category = categories[u];
                        entries.Add(e);
                    }
                }
            }
            return entries;
           
            
            
        }
        private ObservableCollection<Entry> addCateogryReference(List<Entry> items, ObservableCollection<Category> categories,ObservableCollection<Category> wishgroups)
        {
            ObservableCollection<Entry> entries = new ObservableCollection<Entry>();
            for (int i = 0; i < items.Count; i++)
            {
                for (int u = 0; u < categories.Count; u++)
                {
                    if (items[i].categoryID == categories[u].id)
                    {
                        Entry e = items[i];
                        e.category = categories[u];
                        entries.Add(e);
                    }
                }
            }
            for (int i = 0; i < entries.Count; i++)
            {
                for (int u = 0; u < wishgroups.Count; u++)
                {
                    if (((Wish)items[i]).groupID == wishgroups[u].id)
                    {
                        ((Wish)items[i]).group = (WishGroup)wishgroups[u];
                       
                    }
                }
            }
            return entries;



        }
        public void addBudget(Budget b)
        {
            this.budget.Add(b);
            this.budget.OrderBy(o => o.date);
        }
        public void editBudget(Budget b)
        {
           for(int i=0;i<budget.Count;i++)
            {
                if(budget[i].id==b.id)
                {
                    budget[i] = b;
                    break;
                }
            }
            this.budget.OrderBy(o => o.date);
        }
        public void deleteBudget(Budget b)
        {
            for (int i = 0; i < budget.Count; i++)
            {
                if (budget[i].id == b.id)
                {
                    budget.RemoveAt(i);
                    break;
                }
            }
            this.budget.OrderBy(o => o.date);
        }
        public void deleteWishGroup(WishGroup wishg)
        {
            for (int i = 0; i < wishgroups.Count; i++)
            {
                if (wishgroups[i].id == wishg.id)
                {
                    wishgroups.RemoveAt(i);
                    break;
                }
            }
            this.budget.OrderBy(o => o.date);
        }
        public void deserialize(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(MyViewModel));
            MyViewModel mvm =(MyViewModel)x.Deserialize(fs);
            
            Console.WriteLine("Members:");


            this.categories = mvm.categories;
            this.entries = this.addCateogryReference(mvm.entries.OrderBy(item=>item.categoryID).ToList(),mvm.categories);
            this.wishes = this.addCateogryReference(mvm.wishes.OrderBy(item=>item.categoryID).ToList(),mvm.categories,mvm.wishgroups);
            this.wishgroups = mvm.wishgroups;
            this.summaryList = mvm.summaryList;
            //this.wishes = mvm.wishes;
            this.budget = mvm.budget;
        }
        
    }
}
