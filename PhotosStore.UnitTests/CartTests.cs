using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotosStore.Domain.Entities;

namespace PhotosStore.UnitTests
{
    /// <summary>
    /// Сводное описание для CartTests
    /// </summary>
    [TestClass]
    public class CartTests
    {
        
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Организация - создание нескольких тестовых игр
            PhotoTechnique game1 = new PhotoTechnique { PhotoTechniqueId = 1, Name = "Игра1" };
            PhotoTechnique game2 = new PhotoTechnique { PhotoTechniqueId = 2, Name = "Игра2" };
            // Организация - создание корзины
            Cart cart = new Cart();

            cart.AddItem(game1, 1);
            cart.AddItem(game2, 1);
            List<CartLine> results = cart.Lines.ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].PhotoTechnique, game1);
            Assert.AreEqual(results[1].PhotoTechnique, game2);
        }
    }
}
