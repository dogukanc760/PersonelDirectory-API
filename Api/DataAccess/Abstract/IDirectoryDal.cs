using Api.Entities.Concrete;

namespace Api.DataAccess.Abstract
{
    public interface IDirectoryDal : IRepository<Directory, string>
    {
    }
}
