using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookLibrary.Common.DTO;
using BookLibrary.DAL.Entities;

namespace BookLibrary.WebApi.Controllers
{
    public class ReportController : BaseController
    {
        public IEnumerable<ReportDto> Get()
        {
            var categories = repository.Get<Category>().Include(i => i.Books);
            var books = repository.Get<Book>().Include(i => i.Categories).Where(i => !i.Categories.Any());
            
            var result = categories.GroupBy(i => i.Name)
                .Select(
                    i => new ReportDto {Category = i.FirstOrDefault().Name, Quantity = i.FirstOrDefault().Books.Count})
                .ToList();
            if (books.Any())
            {
                result.Add(new ReportDto{Category = "[unknown]", Quantity = books.Count()});
            }

            return result;
        } 
    }
}
