﻿using Projekt_WPF.models;
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
        [XmlArrayItem(typeof(Income)),
   XmlArrayItem(typeof(Outcome))]
        public ObservableCollection<Entry> entries { get; set; }
        
        [XmlArray]
        [XmlArrayItem(typeof(Summary))]
        public ObservableCollection<Summary> summaryList { get; set; }
        [XmlArray]
        [XmlArrayItem(typeof(Wish))]

        public ObservableCollection<Wish> wishes { get; set; }

  

      

        public MyViewModel()
        {
            //MessageBox.Show("viewmodel created");
            categories = new ObservableCollection<Category>();
            entries = new ObservableCollection<Entry>();
            summaryList = new ObservableCollection<Summary>();
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
        public void deserialize(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(MyViewModel));
            MyViewModel mvm =(MyViewModel)x.Deserialize(fs);
            
            Console.WriteLine("Members:");


            this.categories = mvm.categories;
            this.entries = mvm.entries;
            this.summaryList = mvm.summaryList;
            this.wishes = mvm.wishes;
        }
        
    }
}