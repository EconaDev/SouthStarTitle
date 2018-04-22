using System;

namespace SouthStarTitleDAL.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int UserAddressId { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public char HasPassword { get; set; }
        public char ActiveFlag { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }
        public Address Address { get; set; }
        public int UserTypeId { get; set; }
    }
}
