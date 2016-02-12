using System;
using System.Collections.Generic;
using BookLibrary.DAL.Entities;

namespace BookLibrary.Common.DTO
{
    public class CategoryDto 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfCreating { get; set; }

        public ICollection<Book> Books { get; set; } 
    }
}
