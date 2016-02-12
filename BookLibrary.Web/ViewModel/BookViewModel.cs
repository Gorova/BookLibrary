using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookLibrary.Web.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [DisplayName("Title")]
        [Required(ErrorMessage = "field '{0}' should be fill in")]
        [StringLength(20, ErrorMessage = "Max length of field '{0}'- 20 symbols")]
        public string Title { get; set; }

        [DisplayName("International Standard Book Number")]
        [Required(ErrorMessage = "field '{0}' should be fill in")]
        [StringLength(20, ErrorMessage = "Max length of field '{0}'- 20 symbols")]
        public string Isbn { get; set; }

        [DisplayName("Author")]
        [Required(ErrorMessage = "field '{0}' should be fill in")]
        [StringLength(20, ErrorMessage = "Max length of field '{0}'- 20 symbols")]
        public string Author { get; set; }

        [DisplayName("Categories")]
        public int[] SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> AllCategories { get; set; } 
    }
}