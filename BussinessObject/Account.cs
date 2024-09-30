using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BussinessObject
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public List<ObjectId> Friends { get; set; }
        public List<ObjectId> Followers { get; set; }
        public List<ObjectId> Following { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
