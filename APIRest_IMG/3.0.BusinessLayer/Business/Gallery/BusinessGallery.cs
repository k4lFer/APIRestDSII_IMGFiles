using _0._0.DataTransferLayer.Objects;
using _0._0.DataTransferLayer.OtherObjects;
using _1._0.HelpersLayer.Functions.Gallery;
using _3._0.BusinessLayer.Generic;
using System.Linq;
using System.Transactions;

namespace _3._0.BusinessLayer.Business.User
{
    public partial class BusinessGallery : BusinessGeneric
    {
        /* public DtoMessageObject insert(DtoGallery dtoGallery)
         {
             using TransactionScope transactionScope = new();

             // Verificar que el archivo subido sea una imagen y tenga una extensión permitida
             var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" }; // Añade o quita extensiones según sea necesario

             var fileExtension = Path.GetExtension(dtoGallery.files.FileName).ToLowerInvariant();

             if (!allowedExtensions.Contains(fileExtension))
             {
                 _mo.addMessage("El formato de la imagen no es válido. Por favor, sube una imagen con formato .jpg, .jpeg, .png o .gif.");
                 _mo.warning();
                 return _mo;
             }

             // Convertir el archivo a base64
             using var memoryStream = new MemoryStream();
             dtoGallery.files.CopyTo(memoryStream);
             var fileBytes = memoryStream.ToArray();
             var base64String = Convert.ToBase64String(fileBytes);

             // Asignar el valor base64 al DTO
             dtoGallery.imageValue = base64String;

             // Extraer el nombre y la extensión del archivo
             dtoGallery.name = Path.GetFileNameWithoutExtension(dtoGallery.files.FileName);
             dtoGallery.extension = fileExtension;

             insertValidation(dtoGallery);

             if (_mo.exsistsMessage()) 
             {
                 return _mo;
             }

             dtoGallery.idGallery = Guid.NewGuid().ToString();


             repoGallery.insert(dtoGallery);

             transactionScope.Complete();

             _mo.addMessage("Operación realizada correctamente.");
             _mo.success();

             return _mo;
         }


         */
        /*public (DtoMessageObject, DtoGallery) getByPk(string pk) 
        {
            _mo.success();

            return (_mo, repoUser.getByPk(pk));
        }*/

         public (DtoMessageObject, List<DtoGallery>) getAll() 
         {
             _mo.success();

             return (_mo, repoGallery.getAll());
         }

        /*public DtoMessageObject delete(string idUser)
        {
            repoUser.delete(idUser);

            _mo.addMessage("Operación realizada correctamente.");
            _mo.success();

            return _mo;
        }*/

        /*
        public async Task<DtoMessageObject> insert(DtoGallery dtoGallery)
    {
        using TransactionScope transactionScope = new();

        // Verificar que el archivo subido sea una imagen y tenga una extensión permitida
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" }; // Añade o quita extensiones según sea necesario

        var fileExtension = Path.GetExtension(dtoGallery.File.FileName).ToLowerInvariant();

        if (!allowedExtensions.Contains(fileExtension))
        {
            _mo.addMessage("El formato de la imagen no es válido. Por favor, sube una imagen con formato .jpg, .jpeg, .png o .gif.");
            _mo.warning();
            return _mo;
        }

        // Crear una instancia de BusinessFile
        var businessFile = new BusinessFile();

        // Utilizar el método ConvertToBase64Async de BusinessFile
        var base64String = await businessFile.ConvertToBase64Async(dtoGallery.File);

        // Asignar el valor base64 al DTO
        dtoGallery.imageValue = base64String;

        // Extraer el nombre y la extensión del archivo
        dtoGallery.name = Path.GetFileNameWithoutExtension(dtoGallery.File.FileName);
        dtoGallery.extension = fileExtension;

        insertValidation(dtoGallery);

        if (_mo.exsistsMessage()) 
        {
            return _mo;
        }

        dtoGallery.idGallery = Guid.NewGuid().ToString();

        repoGallery.insert(dtoGallery);

        transactionScope.Complete();

        _mo.addMessage("Operación realizada correctamente.");
        _mo.success();

        return _mo;
    }
         */

        public DtoMessageObject insert(DtoGallery dtoGallery)
        {
            using TransactionScope transactionScope = new();

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" }; 

            var fileExtension = Path.GetExtension(dtoGallery.files.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                _mo.addMessage("El formato de la imagen no es válido. Por favor, sube una imagen con formato .jpg, .jpeg, .png");
                _mo.warning();
                return _mo;
            }

            FunctionFile functionFiles = new();
            //var functionFiles = new FunctionFiles();

            var base64String =  functionFiles.ConvertBase64(dtoGallery.files);

            // Asignar el valor base64 al DTO
            dtoGallery.imageValue = base64String;

            dtoGallery.name = Path.GetFileNameWithoutExtension(dtoGallery.files.FileName);
            dtoGallery.extension = fileExtension;

            insertValidation(dtoGallery);

            if (_mo.exsistsMessage())
            {
                return _mo;
            }

            dtoGallery.idGallery = Guid.NewGuid().ToString();

            repoGallery.insert(dtoGallery);

            transactionScope.Complete();

            _mo.addMessage("Operación realizada correctamente.");
            _mo.success();

            return _mo;
        }
        public DtoMessageObject update(DtoGallery dtoGallery) 
        {
            using TransactionScope transactionScope = new();

            updateValidation(dtoGallery);

            if (_mo.exsistsMessage())
            {
                return _mo;
            }

            repoGallery.update(dtoGallery);

            transactionScope.Complete();

            _mo.addMessage("Operación realizada correctamente.");
            _mo.success();

            return _mo;
        }
    }
}