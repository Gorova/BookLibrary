using AutoMapper;
using BookLibrary.Common.DTO;
using BookLibrary.DAL.Entities;

namespace BookLibrary.Bootstrap
{
    public class AutoMapperEntityDtoConfig
    {
        public static void RegisterMapping()
        {
            EntityToDto();
            DtoToEntity();
        }

        private static void EntityToDto()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Book, BookDto>();
        }

        private static void DtoToEntity()
        {
            Mapper.CreateMap<CategoryDto, Category>();
            Mapper.CreateMap<BookDto, Book>();
        }
    }
}
