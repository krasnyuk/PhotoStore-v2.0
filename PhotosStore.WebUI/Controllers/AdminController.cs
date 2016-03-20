﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        readonly IPhotoTechniqueRepository _repository;

        public AdminController(IPhotoTechniqueRepository repo)
        {
            _repository = repo;
        }
        public ViewResult Edit(int photoTechniqueId)
        {
            TempData["IsNew"] = false;
            PhotoTechnique game = _repository.PhotoTechniques
                .FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);
           
            return View(game);
        }
        [HttpPost]
        public ActionResult Edit(PhotoTechnique photoTechnique, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    photoTechnique.ImageMimeType = image.ContentType;
                    photoTechnique.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(photoTechnique.ImageData, 0, image.ContentLength);
                }
                _repository.SavePhotoTechnique(photoTechnique);
                TempData["message"] = $"Изменения в товаре \"{photoTechnique.Name}\" были сохранены";
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(photoTechnique);
            }
        }

        public ViewResult Create()
        {
            TempData["IsNew"] = true;
            return View("Edit", new PhotoTechnique());
        }

        [HttpPost]
        public ActionResult Delete(int photoTechniqueId)
        {
            PhotoTechnique deletePhotoTechnique = _repository.DeletePhotoTechnique(photoTechniqueId);
            if (deletePhotoTechnique != null)
            {
                TempData["message"] = $"Товар \"{deletePhotoTechnique.Name}\" был удалён";
            }
            return RedirectToAction("Index");
        }
        public PartialViewResult GetTechnique(string selectedCategory = null)
        {
            ViewBag.Category = selectedCategory;
            return PartialView(_repository.PhotoTechniques);
        }
        public ViewResult Index()
        {
            
            return View(_repository.PhotoTechniques);
        }
    }
}