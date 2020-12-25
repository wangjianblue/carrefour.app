using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Carrefour.Core
{
    public class MongoEntity
    {
        public MongoEntity()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        
    }
}
