using _2._0.ServiceLayer.Generic;
using _2._0.ServiceLayer.ServiceObject;
using _3._0.BusinessLayer.Business.User;
using Microsoft.AspNetCore.Mvc;

namespace _2._0.ServiceLayer.Controllers
{
    [Route("[controller]")]
    public class GalleryController : ControllerGeneric<BusinessGallery, SoGallery>
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoGallery> Insert(SoGallery so)
        {

            /*  // Verificar que so y dtoGallery no sean null
              if (so == null || so.dtoGallery == null)
              {
                  return BadRequest("El objeto SoGallery o dtoGallery no puede ser null.");
              }

              // Verificar que el archivo no sea null
              if (so.dtoGallery.ImageFile == null)
              {
                  return BadRequest("No se ha subido ningún archivo.");
              }

              // Convertir el archivo a base64
              using var memoryStream = new MemoryStream();
              so.dtoGallery.ImageFile.CopyTo(memoryStream);
              var fileBytes = memoryStream.ToArray();
              var base64String = Convert.ToBase64String(fileBytes);

              // Asignar el valor base64 al DTO
              so.dtoGallery.imageValue = base64String;

              // Extraer el nombre y la extensión del archivo
              so.dtoGallery.name = Path.GetFileNameWithoutExtension(so.dtoGallery.ImageFile.FileName);
              so.dtoGallery.extension = Path.GetExtension(so.dtoGallery.ImageFile.FileName);
            */
            /*// Validar y continuar con la inserción
            _so.mo = ValidatePartDto(so.dtoGallery, new string[] {
                "imageValue",
                "name",
                "description",
                "extension",
            });

            if (_so.mo.exsistsMessage())
            {
                return BadRequest(_so); // Asegúrate de devolver un valor aquí
            }

            _so.mo = _business.insert(so.dtoGallery);
            return Ok(_so); // Asegúrate de devolver un valor aquí
        }*/

            try
            {
                _so.mo = ValidatePartDto(so.dtoGallery, new string[] {
                    "files",
                    "description",
 
                });

                if (_so.mo.exsistsMessage())
                {
                    return _so;
                }

                _so.mo = _business.insert(so.dtoGallery);
            }
            catch (Exception ex)
            {
                _so.mo.listMessage.Add(ex.Message);
                _so.mo.exception();
            }

            return _so;


        }

        /*public async Task<ActionResult<SoGallery>> Insert(SoGallery so)
{
    try
    {
        _so.mo = await ValidatePartDto(so.dtoGallery, new string[] {
            "description",
        });

        if (_so.mo.exsistsMessage())
        {
            return _so;
        }

        _so.mo = await _business.insert(so.dtoGallery);
    }
    catch (Exception ex)
    {
        _so.mo.listMessage.Add(ex.Message);
        _so.mo.exception();
    }

    return _so;
}
        */
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoGallery> Update(SoGallery so)
        {
            try
            {
                _so.mo = ValidatePartDto(so.dtoGallery, new string[] {
                    "idGallery",
                    "description",
                 });

                if (_so.mo.exsistsMessage())
                {
                    return _so;
                }

                _so.mo = _business.update(so.dtoGallery);
            }
            catch (Exception ex)
            {
                _so.mo.listMessage.Add(ex.Message);
                _so.mo.exception();
            }

            return _so;
        }
    }
}


    
