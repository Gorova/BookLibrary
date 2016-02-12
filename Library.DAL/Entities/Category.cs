using System;
using System.Collections.Generic;

namespace BookLibrary.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfCreating { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}
