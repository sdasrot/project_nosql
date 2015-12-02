using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project_NoSql
{
    [BsonIgnoreExtraElements]
    class Artwork :IMongoEntity
    {
        [BsonElement("acquisitionYear")]
        public int AcquisitionYear { get; set; }

        [BsonElement("classification")]
        public string Classification { get; set; }

        [BsonElement("height")]
        public int Height { get; set; }

        [BsonElement("width")]
        public int Width { get; set; }

        [BsonElement("title")]
        public string Title { get; set;  }

        [BsonElement("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [BsonElement("url")]
        public string Url { get; set;  }

        [BsonElement("medium")]
        public string Medium { get; set; }

        [BsonElement("subjectCount")]
        public int SubjectCount { get; set; }

        /*
        [BsonElement("children.subject.name")]
        public List<string> SubjectsName();
        */


        public ObjectId Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }


    }
}
