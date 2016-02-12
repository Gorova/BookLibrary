using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BookLibrary.Common.DTO;
using BookLibrary.Web.Clients;
using BookLibrary.Web.ViewModel;

namespace BookLibrary.Web.Controllers
{
    [Authorize]
    public class ReportController : BaseController
    {
        // GET: Report
        public ActionResult Index()
        {
            var dto = client.Get<IEnumerable<ReportDto>>(UrlProvider.WebApiReport);
            var viewModel = Mapper.Map<IEnumerable<ReportDto>, IEnumerable<ReportViewModel>>(dto);

            return View(viewModel);
        }
    }
}