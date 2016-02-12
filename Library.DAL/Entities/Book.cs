using System.Collections.Generic;

namespace BookLibrary.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Isbn { get; set; }

        public string Author { get; set; }

        public virtual ICollection<Category> Categories { get; set; } 
    }
}
