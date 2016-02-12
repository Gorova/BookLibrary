using AutoMapper;
using BookLibrary.Common.DTO;
using BookLibrary.Web.ViewModel;

namespace BookLibrary.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            DtoToViewModel();
            ViewModelToDto();
        }

        public static void DtoToViewModel()
        {
            Mapper.CreateMap<CategoryDto, CategoryViewModel>();
            Mapper.CreateMap<BookDto, BookViewModel>();
            Mapper.CreateMap<ReportDto, ReportViewModel>();
        }

        public static void ViewModelToDto()
        {
            Mapper.CreateMap<BookViewModel, BookDto>();
            Mapper.CreateMap<CategoryViewModel, CategoryDto>();
            Mapper.CreateMap<ReportViewModel, ReportDto>();
        }
    }
}