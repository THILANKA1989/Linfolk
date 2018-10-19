using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string CategoryName { get; set; }
        [Required]
        [MinLength(4)]
        public string Description { get; set; }
        public Boolean IsEnabled { get; set; }

        public ICollection<SubCategoryViewModel> SubCategories { get; set; }
    }

}
