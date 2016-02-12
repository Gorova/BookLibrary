using System.Collections.Generic;
using BookLibrary.DAL.Entities;

namespace BookLibrary.Common.DTO
{
    public class BookDto 
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Isbn { get; set; }

        public string Author { get; set; }

        public int[] SelectedCategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
