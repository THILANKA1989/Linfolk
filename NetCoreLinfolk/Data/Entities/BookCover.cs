using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class BookCover
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ModifiedBy { get; set; }
        
        public Book Book { get; set; }
    }
}
