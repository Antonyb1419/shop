
namespace Shop.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IProductRepository : IGenericRepository<Product>
    {
        //traeme todos los usuarios
        IQueryable GetAllWithUsers();

    }

}
