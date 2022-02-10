using Api.DataAccess.Abstract;
using Api.Entities.Concrete;
using Api.Utilities.AppSettings;

using Microsoft.Extensions.Options;

namespace Api.DataAccess.Concrete
{
    public class ReportsMongoDbDal : MongoDbRepositoryBase<Reports>, IReportsDal
    {
        public ReportsMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
