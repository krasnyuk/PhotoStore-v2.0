using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;
using PhotosStore.WebUI.Models;

namespace PhotosStore.WebUI.Controllers
{
    public class PhotoTechniqueController : Controller
    {
        private readonly IPhotoTechniqueRepository _repository;
        private readonly IOrdersRepository _ordersRepository;
        public int pageSize = 6;

        public PhotoTechniqueController(IPhotoTechniqueRepository repo, IOrdersRepository _ordersRepository)
        {
            _repository = repo;
            this._ordersRepository = _ordersRepository;
        }

        public ViewResult Mesh(string category, int page = 1)
        {
            PhotoTechniqueListViewModel model = new PhotoTechniqueListViewModel
            {
                PhotoTechniques = _repository.PhotoTechniques
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(game => game.PhotoTechniqueId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        _repository.PhotoTechniques.Count() :
        _repository.PhotoTechniques.Count(game => game.Category == category)
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public ViewResult List(string category, int page = 1)
        {

            PhotoTechniqueListViewModel model = new PhotoTechniqueListViewModel
            {
                PhotoTechniques = _repository.PhotoTechniques
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(game => game.PhotoTechniqueId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        _repository.PhotoTechniques.Count() :
        _repository.PhotoTechniques.Count(game => game.Category == category)
                },
                CurrentCategory = category
            };
            return View(model);
        }
        [HttpPost]
        public ViewResult ListSorted(string price, string category, int page = 1 )
        {
            PhotoTechniqueListViewModel model;
            if (price=="Up")
            {
            model = new PhotoTechniqueListViewModel
            {
                PhotoTechniques = _repository.PhotoTechniques
                    .Where(p => category == null || p.Category == category)
                    .OrderByDescending(t => t.Price)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
            _repository.PhotoTechniques.Count() :
            _repository.PhotoTechniques.Count(game => game.Category == category)
                },
                CurrentCategory = category
            };
            }
            else
            {
                 model = new PhotoTechniqueListViewModel
                {

                    PhotoTechniques = _repository.PhotoTechniques
                   .Where(p => category == null || p.Category == category)
                   .OrderBy(t => t.Price)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = category == null ?
       _repository.PhotoTechniques.Count() :
       _repository.PhotoTechniques.Count(game => game.Category == category)
                    },
                    CurrentCategory = category
                };
            }
            return View("List",model);
        }
        public ViewResult Technique(string category = "", int photoTechniqueId = 1)
        {
            PhotoTechnique technique = _repository.PhotoTechniques
                .FirstOrDefault(x => x.PhotoTechniqueId == photoTechniqueId);
            return View(technique);
        }

        public FileContentResult GetImage(int photoTechniqueId)
        {
            PhotoTechnique technique = _repository.PhotoTechniques
                .FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (technique != null)
            {
                return File(technique.ImageData, technique.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}