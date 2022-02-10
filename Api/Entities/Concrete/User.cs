using Api.Entities.Abstract;

namespace Api.Entities.Concrete
{
    public class User : MongoDbEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Gsm { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public string Password { get; set; }
        public string[] inDirectoryPerson { get; set; }
        public string[] inDirectoryGsm { get; set; }
    }
}
