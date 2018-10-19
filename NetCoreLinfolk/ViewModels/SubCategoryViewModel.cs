using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.ViewModels
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public Boolean IsEnabled { get; set; }
    }
}
