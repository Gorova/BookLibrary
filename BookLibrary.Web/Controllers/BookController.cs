using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BookLibrary.Common.DTO;
using BookLibrary.Web.Clients;
using BookLibrary.Web.ViewModel;

namespace BookLibrary.Web.Controllers
{
    [Authorize]
    public class BookController : BaseController
    {
        public ActionResult Index()
        {
            var dto = client.Get<IEnumerable<BookDto>>(UrlProvider.WebApiBook);
            var viewModel = Mapper.Map<IEnumerable<BookDto>, IEnumerable<BookViewModel>>(dto);

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var dto = client.Get<BookDto>(UrlProvider.WebApiBook + id);
            var viewModel = Mapper.Map<BookDto, BookViewModel>(dto);
            viewModel.AllCategories = dto.Categories.Select(i => new SelectListItem { Text = i.Name });

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new BookViewModel();
            InitialazeSelectList(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<BookViewModel, BookDto>(viewModel);
                client.Create(UrlProvider.WebApiBook, dto);

                return RedirectToAction("Index");
            }

            InitialazeSelectList(viewModel);

            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            var dto = client.Get<BookDto>(UrlProvider.WebApiBook + id);
            var viewModel = Mapper.Map<BookDto, BookViewModel>(dto);
            viewModel.AllCategories = dto.Categories.Select(i => new SelectListItem { Text = i.Name });

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(BookViewModel viewMoel)
        {
            client.Delete(UrlProvider.WebApiBook + viewMoel.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dto = client.Get<BookDto>(UrlProvider.WebApiBook + id);
            var viewModel = Mapper.Map<BookDto, BookViewModel>(dto);
            InitialazeSelectList(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<BookViewModel, BookDto>(viewModel);
                client.Update(UrlProvider.WebApiBook, dto);

                return RedirectToAction("Index");
            }
            InitialazeSelectList(viewModel);

            return View(viewModel);
        }

        private void InitialazeSelectList(BookViewModel viewModel)
        {
            var categoriesDto = client.Get<IEnumerable<CategoryDto>>(UrlProvider.WebApiCategory);
            var categoriesVieModel = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryViewModel>>(categoriesDto);
            viewModel.AllCategories = categoriesVieModel
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();
        }
    }
}