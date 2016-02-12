using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using BookLibrary.Common.DTO;
using BookLibrary.DAL.Entities;

namespace BookLibrary.WebApi.Controllers
{
    public class BookController : BaseController
    {
        public IEnumerable<BookDto> GetAll()
        {
            var books = repository.Get<Book>();

            return Mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books);
        }

        public BookDto Get(int id)
        {
            var book = repository.Get<Book>(id);

            return Mapper.Map<Book, BookDto>(book);
        }

        [HttpPost]
        public void Create(BookDto dto)
        {
            var book = Mapper.Map<BookDto, Book>(dto);
            book.Categories = dto.SelectedCategoryId.Select(i => repository.Get<Category>(i)).ToList();
            
            repository.Add(book);
            repository.Save();
        }

        [HttpPut]
        public void Update(BookDto dto)
        {
            var book = repository.Get<Book>(dto.Id);
            Mapper.Map(dto, book);
            book.Categories = dto.SelectedCategoryId.Select(i => repository.Get<Category>(i)).ToList();
            repository.Save();
        }

        public void Delete(int id)
        {
            var book = repository.Get<Book>(id);
            book.Categories.Clear();
            repository.Delete<Book>(book.Id);
            repository.Save();
        }
    }
}
