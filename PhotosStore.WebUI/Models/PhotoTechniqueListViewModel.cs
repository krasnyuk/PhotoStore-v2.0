using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotosStore.Domain.Entities;

namespace PhotosStore.WebUI.Models
{
    public class PhotoTechniqueListViewModel
    {
        public IEnumerable<PhotoTechnique> PhotoTechniques { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}