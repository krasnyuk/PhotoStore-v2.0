using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Abstract
{
    public interface IPhotoTechniqueRepository
    {
        IEnumerable<PhotoTechnique> PhotoTechniques { get; }

        void SavePhotoTechnique(PhotoTechnique photoTechnique);

        PhotoTechnique DeletePhotoTechnique(int photoTechniqueId);

    }
}
