using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Concrete;
using PhotosStore.Domain.Entities;
using PhotosStore.WebUI.Models;

namespace PhotosStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IPhotoTechniqueRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IPhotoTechniqueRepository repo, IOrderProcessor orderProcessor)
        {
            repository = repo;
            this.orderProcessor = orderProcessor;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (!cart.Lines.Any())
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                //orderProcessor.SendEmail("krasnyuk.photo@gmail.com","Заказ","Some text");
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int photoTechniqueId, string returnUrl)
        {

            PhotoTechnique photoTechnique = repository.PhotoTechniques.FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (photoTechnique != null)
            {
                cart.AddItem(photoTechnique, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int photoTechniqueId, string returnUrl)
        {
            PhotoTechnique photoTechnique = repository.PhotoTechniques.FirstOrDefault(g => g.PhotoTechniqueId == photoTechniqueId);

            if (photoTechnique != null)
            {
                cart.RemoveLine(photoTechnique);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}