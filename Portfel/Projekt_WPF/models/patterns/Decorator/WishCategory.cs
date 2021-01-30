using Projekt_WPF.models.patterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryClass
{
    public class WishCategory : ICategory
    {
        private ICategoryBase decoree;
        public WishCategory()
        {

        }
        
        public int wishCategoryID { get; set; }
        public WishGroup wishCategory { get; set; }
        public WishCategory(ref WishGroup wishCategory,ref ICategoryBase decoree)
        {
            this.decoree = decoree;
       
            this.wishCategory = wishCategory;
            this.wishCategoryID = wishCategoryID;
        }
        public override  Category getCategory()
        {
            
            return  getDecoree().getCategory();
        }

        public override WishGroup getWishCategory()
        {
            return  wishCategory;
        }

        protected override ICategoryBase getDecoree()
        {
            return decoree;
        }
    }
}
