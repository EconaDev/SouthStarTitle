using System;

namespace SouthStarTitleDAL.Model
{
    public class Entity
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public int EntityAddressId { get; set; }
        public int EntityDocumentId { get; set; }
        public char ActiveFlag { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }
        public Address Address { get; set; }

    }
}
