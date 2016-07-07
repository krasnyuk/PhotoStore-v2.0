using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;
using System.Xml.Linq;

namespace PhotosStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IPhotoTechniqueRepository _repository;

        public NavController(IPhotoTechniqueRepository repo)
        {
            _repository = repo;
        }

        public PartialViewResult Valute()
        {
            XDocument doc = XDocument.Load("http://bank-ua.com/export/currrate.xml");
            var usd = doc.Element("chapter")
                .Elements("item")
                .Select(x => new { Name = x.Element("char3").Value, Value = x.Element("rate").Value })
                .Where(x => x.Name == "USD")
                .FirstOrDefault();
            ViewBag.Name = usd.Name;
            ViewBag.Value = usd.Value;
            return PartialView();
        }
        public PartialViewResult Menu(string category = null, string grid = "list")
        {
            ViewBag.Grid = grid;
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = _repository.PhotoTechniques
                .Select(technique => technique.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
        public PartialViewResult SortPanel()
        {
            return PartialView();
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