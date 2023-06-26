﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Messagehub.Domain.Models
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
