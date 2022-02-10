using Api.Entities.Abstract;

namespace Api.Entities.Concrete
{
    public class Reports: MongoDbEntity
    {
        //The user who made this request
        public string UserId { get; set; }

        public string PersonCount { get; set; }
        public string GsmCount { get; set; }
        public string State { get; set; }
    }
}
