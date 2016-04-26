using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

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
        //Autocomplete
        public ActionResult Find(string term)
        {
            PhotoTechnique[] photoTechniques = _repository.FindCities(term);
            var projection = from technique in photoTechniques
                             select new
                             {
                                 id = technique.PhotoTechniqueId,
                                 label = technique.Name,
                                 value = technique.Name
                             };
            return Json(projection.ToList(),JsonRequestBehavior.AllowGet);
        }
    }
}