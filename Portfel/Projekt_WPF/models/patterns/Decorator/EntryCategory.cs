using Projekt_WPF.models.patterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryClass
{
    public class EntryCategory : ICategory
    {
        private ICategoryBase decoree;
        public EntryCategory()
        {

        }
        public int CategoryID { get; set; }
        public Category category { get; set; }
        public EntryCategory(ref Category category, ICategoryBase decoree)
        {
            this.decoree = decoree;
            this.category = category;
            this.CategoryID = category.id;
        }
        public override  Category getCategory()
        {
            return this.category;
        }
       
        public override  Category getWishCategory()
        {
            
                return  getDecoree().getWishCategory();
            
        }

        protected override ICategoryBase getDecoree()
        {
            return decoree;
        }
    }
}
