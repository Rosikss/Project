﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentHub.Models
{
    public sealed class User
    {
        public ObjectId _id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("isEmailConfirmed")]
        public bool IsEmailConfirmed { get; set; }
    }
}
