using _0._0.DataTransferLayer.Objects;

namespace _3._0.BusinessLayer.Business.User
{
    public partial class BusinessGallery
    {
        private void insertValidation(DtoGallery dtoGallery) 
        {


            if (repoGallery.getByDesc(dtoGallery.description) is not null)
            {
                _mo.addMessage("La descripcion ya existe (Descripcion existente)");
            }
        }

        private void updateValidation(DtoGallery dtoGallery)
        {
            DtoGallery dtoGalleryTempDescription = repoGallery.getByDesc(dtoGallery.description);

            // Verifica si hay un conflicto de descripción
            if (dtoGalleryTempDescription != null)
            {
                // Si el registro existente no es el mismo que estás actualizando, hay un conflicto
                if (!dtoGalleryTempDescription.idGallery.Equals(dtoGallery.idGallery))
                {
                    _mo.addMessage("La descripción ya existe.");
                }
            }
        }
    }
}