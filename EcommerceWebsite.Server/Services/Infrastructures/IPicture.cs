using EcommerceWebsite.Server.Models;

namespace EcommerceWebsite.Server.Services.Infrastructures
{
    public interface IPicture
    {
        Picture GetPicture(int id);

        void Insert(Picture picture);

        void Update(Picture picture);

        void Delete(int id);

        void Save();
    }
}