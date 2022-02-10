using Api.DataAccess.Abstract;
using Api.Entities.Concrete;
using Api.Utilities.AppSettings;

using Microsoft.Extensions.Options;

namespace Api.DataAccess.Concrete
{
    public class DirectoryMongoDbDal: MongoDbRepositoryBase<Directory>, IDirectoryDal
    {
        public DirectoryMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
