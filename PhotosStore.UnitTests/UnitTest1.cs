using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;
using PhotosStore.WebUI.Controllers;

namespace PhotosStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<IPhotoTechniqueRepository> mock = new Mock<IPhotoTechniqueRepository>();
            mock.Setup(m => m.PhotoTechniques).Returns(new List<PhotoTechnique>
            {
                new PhotoTechnique { PhotoTechniqueId = 1, Name = "Игра1"},
                new PhotoTechnique { PhotoTechniqueId = 2, Name = "Игра2"},
                new PhotoTechnique { PhotoTechniqueId = 3, Name = "Игра3"},
                new PhotoTechnique { PhotoTechniqueId = 4, Name = "Игра4"},
                new PhotoTechnique { PhotoTechniqueId = 5, Name = "Игра5"}
            });
            PhotoTechniqueController controller = new PhotoTechniqueController(mock.Object,null)
            {
                pageSize = 3
            };

            // Действие (act)
            //IEnumerable<PhotoTechnique> result = (IEnumerable<PhotoTechnique>)controller.List(2).Model;

            //// Утверждение (assert)
            //List<PhotoTechnique> games = result.ToList();
            //Assert.IsTrue(games.Count == 2);
            //Assert.AreEqual(games[0].Name, "Игра4");
            //Assert.AreEqual(games[1].Name, "Игра5");
        }
    }
}
