using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public Boolean IsPublished { get; set; }
        public int CategoryId { get; set; }
        
        public SubCategory SubCategory { get;set; }
        public Author Author { get; set; }

        public ICollection<Chapter> Chapters { get; set; }
        public ICollection<BookCover> BookCovers { get; set; }
    }
}
