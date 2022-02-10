using Api.DataAccess.Abstract;
using Api.Entities.Concrete;
using Api.Utilities.AppSettings;

using Microsoft.Extensions.Options;

namespace Api.DataAccess.Concrete
{
    public class UserMongoDbDal: MongoDbRepositoryBase<User>, IUserDal
    {
        public UserMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
