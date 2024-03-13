using _0._0.DataTransferLayer.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _0._0.DataTransferLayer.Objects
{
    public class DtoGallery 
    {
        [Required(ErrorMessage = "El campo \"idGallery\" es requerido.")]
        public string idGallery { get; set; }

        [Required(ErrorMessage = "El campo \"imageValue\" es requerido.")]
        public string imageValue { get; set; }

        [Required(ErrorMessage = "El campo \"name\" es requerido.")]
        public string name { get; set; }

        [Required(ErrorMessage = "El campo \"description\" es requerido.")]
        public string description { get; set; }

        [Required(ErrorMessage = "El campo \"extension\" es requerido.")]
        public string extension { get; set; }

        [Required(ErrorMessage = "El campo \"files\" es requerido.")]
        public IFormFile files { get; set; }

    }
}