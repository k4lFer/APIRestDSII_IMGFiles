using _0._0.DataTransferLayer.Generic;
using _5._0.DataAccessLayer.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5._0.DataAccessLayer.Entities
{
    [Table("tgallery")]
    public class Gallery : DtoGeneric
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idGallery { get; set; }
        public string imageValue { get; set; }
        public string name { get; set; }

        public string description { get; set; }
        public string extension { get; set; }



    }
}