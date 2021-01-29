using Newtonsoft.Json;
using NodaTime;
using Projekt_WPF.models.range;
using Projekt_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_WPF.models
{
    public class SummaryCalculation
    {
        
       
        
        private List<Income> incomes { get; set; }
        private List<Outcome> outcomes { get; set; } 
        private List<Category> categories { get; set; }
        public Range priceRange { get; set; }
        public LocalDate begin { get; set; }
        public LocalDate end { get; set; }
        public List<SummaryItemEntry> income_Summary { get; set; }
        public List<SummaryItemEntry> outcome_summary { get; set; }
        public List<SummaryItemCategory> incomeCategory_summary { get; set; }
        public List<SummaryItemCategory> outncomeCategory_summary { get; set; }
        public decimal maxcategory { get; set; }
        public decimal maxsingle { get; set; }
        public List<SummaryType> summTypes { get; }
        //private List<Wpis> wpisy { get; set; }
      
        public MyViewModel vm {get;set;}
        public SummaryCalculation(List<Category> included, Range priceRange,MyViewModel vm, LocalDate begin, LocalDate end, List<SummaryType> summaries)
        {
            this.summTypes = summaries;
            
            //this.wpisy = wpisy;
            this.vm = vm;
            categories = included;
            this.priceRange = priceRange;
            this.begin = begin;
            this.end = end;
            
            //filter(wpisy);

        }
        public Summary calculate()
        {
            filter();
            calculateByCategories();
            calculateIncome();
            calculateOutcome();
            return new Summary(priceRange,begin,end,income_Summary,outcome_summary,incomeCategory_summary,outncomeCategory_summary,maxcategory,maxsingle);
        }
        public void calculateOutcome()
        {
            outcome_summary = new List<SummaryItemEntry>();
            
            foreach(Outcome w in outcomes)
            {
                MessageBox.Show("wydatki " + w.name);
                decimal sum = w.getSum(begin, end);
                maxsingle = Math.Max(sum, maxsingle);
                SummaryItemEntry outcome = new SummaryItemEntry(w);
                outcome.add(sum);
                outcome_summary.Add(outcome);
            }
        }
        public void calculateIncome()
        {
            income_Summary = new List<SummaryItemEntry>();
            
            foreach (Income w in incomes)
            {
                MessageBox.Show("przychod " + w.name);
                decimal sum = w.getSum(begin, end);
                maxsingle = Math.Max(sum, maxsingle);
                SummaryItemEntry income = new SummaryItemEntry(w);
                income.add(sum);
                income_Summary.Add(income);
            }
        }
        public void calculateByCategories()
        {
            incomeCategory_summary = new List<SummaryItemCategory>();
            outncomeCategory_summary = new List<SummaryItemCategory>();
            foreach(Income p in incomes)
            {
                decimal sum = p.getSum(begin, end);
                try {
                    SummaryItemCategory item = incomeCategory_summary.Where(x => x.getElement().id==p.category.id  ).First();
                    item.add(sum);
                    maxcategory = Math.Max(item.amount, maxcategory);
                }
                catch(Exception e)
                {
                    SummaryItemCategory item = new SummaryItemCategory(p.category);
                    item.add(sum);
                    maxcategory = Math.Max(item.amount, maxcategory);
                    incomeCategory_summary.Add(item);
                }
                
            }
            foreach (Outcome w in outcomes)
            {
                decimal sum = w.getSum(begin, end);
                try
                {
                    SummaryItemCategory item = incomeCategory_summary.Where(x => x.getElement().id == w.category.id).First();
                    item.add(sum);
                    maxcategory = Math.Max(item.amount, maxcategory);
                }
                catch (Exception e)
                {
                    SummaryItemCategory item = new SummaryItemCategory(w.category);
                    item.add(sum);
                    maxcategory = Math.Max(item.amount, maxcategory);
                    incomeCategory_summary.Add(item);
                }

            }

        }
        public void filter()
        {
            

            incomes = new List<Income>();
            outcomes = new List<Outcome>();
            foreach (Entry w in vm.entries)
            {
                //MessageBox.Show("wpis: | " + w.nazwa);
                try
                {
                    decimal min = priceRange.getMin();
                    if (w.amount <=min) continue;

                }
                catch(Exception e)
                {
                   // MessageBox.Show("kwota jest zla CATCH");
                }
                try
                {
                    decimal max = priceRange.getMax();
                    if (w.amount >= max) continue;
                }
                catch(Exception e)
                {
                   // MessageBox.Show("kwota jest zla CATCH");
                }
                if (w.begin > end) 
                {
                  //  MessageBox.Show("zly zakres dat: poczatek > end");
                    continue;
                }
                if (w.end < begin) 
                {
                   // MessageBox.Show("zly zakres dat: koniec < begin");
                    continue; 
                }


                List<Category> klist = categories.Where(x => x.id == w.category.id).ToList();
               
                if (klist.Count>0)
                {
                    if (w is Income)
                        incomes.Add((Income)w);
                    else if (w is Outcome)
                        outcomes.Add((Outcome)w);

                }
            }
        }
       

        
    }
}
