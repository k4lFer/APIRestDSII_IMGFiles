using _0._0.DataTransferLayer.Objects;
using _4._0.RepositoryLayer.Generic;
using Microsoft.AspNetCore.Http;

namespace _4._0.RepositoryLayer.Repository
{
    public interface RepoGallery : RepoGeneric<DtoGallery>
    {
        public List<DtoGallery> getAll();
        public DtoGallery getByDesc(string description);
        public DtoGallery getByFile(IFormFile files);
        //public DtoGallery getByDni(string dni);
    }
}