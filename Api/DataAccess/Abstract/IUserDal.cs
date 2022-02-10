using Api.Entities.Concrete;

namespace Api.DataAccess.Abstract
{
    public interface IUserDal:IRepository<User, string>
    {
    }
}
