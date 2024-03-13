using _0._0.DataTransferLayer.Objects;
using _4._0.RepositoryLayer.Repository;
using _5._0.DataAccessLayer.Connection;
using _5._0.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace _5._0.DataAccessLayer.Query
{
    public class QGallery : RepoGallery
    {
        public List<DtoGallery> getAll()
        {
            throw new NotImplementedException();
        }

        public DtoGallery getByDesc(string description)
        {
            using DataBaseContext dbc = new();

            return InitAutoMapper.mapper.Map<DtoGallery>(dbc.Gallerys.Where(w => w.description == description).FirstOrDefault());
        }

        public DtoGallery getByFile(IFormFile files)
        {
            
            throw new NotImplementedException();
        }

        /* public int delete(string id)
{
    using DataBaseContext dbc = new();

    int quantityRegisterModify = 0;

    Gallery user = dbc.Gallerys.Find(id);

    if (user is not null) 
    {
        dbc.Gallerys.Remove(user);

        quantityRegisterModify = dbc.SaveChanges();
    }

    return quantityRegisterModify;
}

public List<DtoUser> getAll()
{
    using DataBaseContext dbc = new();

    return InitAutoMapper.mapper.Map<List<DtoUser>>(dbc.Users.ToList());   
}

public DtoUser getByDni(string dni)
{
    using DataBaseContext dbc = new();

    return InitAutoMapper.mapper.Map<DtoUser>(dbc.Users.Where(w => w.dni == dni).FirstOrDefault());
}

public DtoUser getByPk(string pk)
{
    using DataBaseContext dbc = new();

    return InitAutoMapper.mapper.Map<DtoUser>(dbc.Users.Find(pk));
}

public DtoUser getByUsername(string username)
{
    using DataBaseContext dbc = new();

    return InitAutoMapper.mapper.Map<DtoUser>(dbc.Users.Where(w => w.username == username).FirstOrDefault());
}
*/
        public int insert(DtoGallery dto)
        {
            using DataBaseContext dbc = new();

            dbc.Add(InitAutoMapper.mapper.Map<Gallery>(dto));

            return dbc.SaveChanges();
        }

        public int update(DtoGallery dto)
        {
            using DataBaseContext dbc = new();

            Gallery gallery = dbc.Gallerys.Find(dto.idGallery);

            gallery.description = dto.description;

            return dbc.SaveChanges();
        }
    }
}