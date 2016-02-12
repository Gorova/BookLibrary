using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BookLibrary.Common.DTO;
using BookLibrary.Web.Clients;
using BookLibrary.Web.ViewModel;

namespace BookLibrary.Web.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        public ActionResult Index()
        {
            var dto = client.Get<IEnumerable<CategoryDto>>(UrlProvider.WebApiCategory);
            var viewModel = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryViewModel>>(dto);

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var dto = client.Get<CategoryDto>(UrlProvider.WebApiCategory + id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);
            
            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new CategoryViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
                client.Create(UrlProvider.WebApiCategory, dto);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            var dto = client.Get<CategoryDto>(UrlProvider.WebApiCategory + id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(CategoryViewModel viewModel)
        {
            client.Delete(UrlProvider.WebApiCategory + viewModel.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dto = client.Get<CategoryDto>(UrlProvider.WebApiCategory + id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
                client.Update<CategoryDto>(UrlProvider.WebApiCategory, dto);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}