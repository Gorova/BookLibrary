using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BookLibrary.Common.DTO;
using BookLibrary.DAL.Entities;

namespace BookLibrary.WebApi.Controllers
{
    public class CategoryController : BaseController
    {
        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = repository.Get<Category>();

            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto Get(int id)
        {
            var category = repository.Get<Category>(id);

            return Mapper.Map<Category, CategoryDto>(category);
        }

        [HttpPost]
        public void Create(CategoryDto dto)
        {
            var category = Mapper.Map<CategoryDto, Category>(dto);
            repository.Add(category);
            repository.Save();
        }

        [HttpPut]
        public void Update(CategoryDto dto)
        {
            var category = repository.Get<Category>(dto.Id);
            Mapper.Map(dto, category);
            repository.Save();
        }

        public void Delete(int id)
        {
            var category = repository.Get<Category>(id);
            category.Books.Clear();
            repository.Delete<Category>(category.Id);
            repository.Save();
        }
    }
}
