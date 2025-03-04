using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.DataAccess.Entities
{
    public class Instructor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InstructorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }
    }
}
