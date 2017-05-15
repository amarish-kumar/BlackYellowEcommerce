using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.MVC.Models
{
    public class ProductReportFilters
    {
        public int? CategoryId { get; set; }

        private static IEnumerable<Domain.Entites.Category> _categories;

        public static IEnumerable<Domain.Entites.Category> Categories
        {
            get
            {

                if (_categories == null)
                {
                    _categories = new Repositories.CategoryRepository().GetAll();
                }

                return _categories;

            }
            set { _categories = value; }
        }



    }
}
