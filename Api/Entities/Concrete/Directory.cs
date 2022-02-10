using Api.Entities.Abstract;

namespace Api.Entities.Concrete
{
    public class Directory: MongoDbEntity
    {
        //Id of the directory owner
        public string UserId { get; set; }
        public string[] inDirectory { get; set; }
    }
}
