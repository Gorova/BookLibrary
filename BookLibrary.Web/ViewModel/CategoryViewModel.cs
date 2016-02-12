using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BookLibrary.DAL.Entities;

namespace BookLibrary.Web.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("category`s name")]
        [Required(ErrorMessage = "field '{0}' should be fill in")]
        [StringLength(20, ErrorMessage = "Max length of field '{0}'- 20 symbols")]
        public string Name { get; set; }

        [DisplayName("Date of cteating category")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "field '{0}' should be fill in")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfCreating { get; set; }

        public ICollection<Book> Books { get; set; } 
    }
}