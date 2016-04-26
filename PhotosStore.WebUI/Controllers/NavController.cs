using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;

namespace PhotosStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IPhotoTechniqueRepository _repository;

        public NavController(IPhotoTechniqueRepository repo)
        {
            _repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = _repository.PhotoTechniques
                .Select(technique => technique.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}